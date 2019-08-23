using BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//PDF
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace B_Cientificas_Cliente
{
    public partial class PagarTarjetaSeleccionada : System.Web.UI.Page
    {
        #region Var

        TarjetasLogica tarjeta = new TarjetasLogica();

        #endregion

        #region Methods

        private void CrearOrden(decimal monto, string cliente, int tarjetacredito)
        {
            OrdenLogica logica = new OrdenLogica();
            OrdenLogica nuevaOrden = new OrdenLogica()
            {
                Montofinal = monto.ToString(),
                Cliente_id = cliente,
                Fecha = DateTime.Now,
                TarjetaCredito_id = tarjetacredito
            };
            logica.CrearOrden(nuevaOrden);
            int ordenCreada = logica.BuscarIDOrden(tarjetacredito, monto.ToString(), nuevaOrden.Fecha);
            OrdenProyectoLogica carritoLogica = new OrdenProyectoLogica();
            foreach (var item in BLL.Carrito.carritoLista)
            {
                carritoLogica.CrearOrdenProyecto(ordenCreada, item.proyecto_id);
            }
        }

        private string EncriptarTarjeta(string tarjeta)
        {
            StringBuilder duplicado = new StringBuilder(tarjeta);
            int tam = duplicado.Length;
            if (tam == 15)
            {
                duplicado.Remove(0, 11);
                duplicado.Insert(0, "XXXXXXXXXXX");
            }
            if (tam == 16)
            {
                duplicado.Remove(0, 12);
                duplicado.Insert(0, "XXXXXXXXXXXX");
            }
            return duplicado.ToString();
        }

        private void CargarTarjeta()
        {
            tarjeta = (TarjetasLogica)Session["seleccion"];
            btnDescargar.Visible = false;
            if (tarjeta != null)
            {
                txtNumeroTarjeta.Text = EncriptarTarjeta(tarjeta.NumeroTarjeta);
                txtNombre.Text = tarjeta.NombreTarjeta;
                if (tarjeta.TipoTarjeta_Id == 1)
                {
                    txtTipoTarjeta.Text = "MasterCard";
                }
                else
                {
                    if (tarjeta.TipoTarjeta_Id == 2)
                    {
                        txtTipoTarjeta.Text = "VISA";
                    }
                    else
                    {
                        if (tarjeta.TipoTarjeta_Id == 3)
                        {
                            txtTipoTarjeta.Text = "American Express";
                        }
                    }
                }
                if (tarjeta.DebitoCredito.Equals("Debito"))
                {
                    chkBoxDebito.Checked = true;
                }
            }
            

        }

        private void Pagar()
        {
            try
            {
                string Num_Tarjeta = tarjeta.NumeroTarjeta;
                string Mes_Exp = txtMes.Text;
                int Anno_Exp = Convert.ToInt32(txtAnno.Text);
                int CVV = Convert.ToInt32(txtCVV.Text);
                string tipo = tarjeta.TipoTarjeta_Id.ToString();
                string debitoCredito = tarjeta.DebitoCredito;
                decimal monto = Convert.ToDecimal(lblMonto.Text);

                var json = new WebClient().DownloadString("http://localhost:52081/api/Tarjetas?Num_Tarjeta=" + Num_Tarjeta + "&Mes_Exp=" + Mes_Exp + "&Anno_Exp=" + Anno_Exp + "&CVV=" + CVV + "&monto=" + monto + "&tipo=" + tipo + "&debitoCredito=" + debitoCredito);
                dynamic m = JsonConvert.DeserializeObject(json);
                int resultado = Convert.ToInt32(m);
                switch (resultado)
                {
                    case -1:
                        lblResultado.Text = "Número de Tarjeta Inválido";
                        break;
                    case -2:
                        lblResultado.Text = "Fecha de expiración inválida o la tarjeta expiro";
                        break;
                    case -3:
                        lblResultado.Text = "CVV incorrecto";
                        break;
                    case -4:
                        lblResultado.Text = "Fondos insuficientes";
                        break;
                    case 0:
                        lblResultado.Text = "Transacción Exitosa";
                        btnPagar.Visible = false;
                        //ASIGNAR LA DESCARGA A DESCARGAR
                        btnDescargar.Visible = true;
                        CrearOrden(monto, "1", tarjeta.TarjetaCredito_id);
                        break;
                    default:
                        lblResultado.Text = "Error";
                        break;
                }

            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Valores erróneos');</script>");


            }
        }


        private void GenerarPDF()
        {
            Document oDoc = new Document(PageSize.LETTER, 0, 0, 0, 0);
            iTextSharp.text.pdf.PdfWriter pdfw;
            PdfContentByte cb;
            String sNombreArchivo = @"C:\Users\Josue\Desktop\iTextSharpDemo \pruebaColumnas.pdf";
            ColumnText ct;
            stColumna[] arrColumnas = new stColumna[2];
            for (int i = 0; i < arrColumnas.Length; i++)
            {
                arrColumnas[i] = new stColumna();
            }
            int iEstado = 0;
            int iColumna = 0;

            int INTERLINEADO = 20;
            int MARGEN_INFERIOR = 80;

            try
            {
                pdfw = PdfWriter.GetInstance(oDoc, new FileStream(sNombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None));
                oDoc.Open();
                oDoc.NewPage();
                cb = pdfw.DirectContent;
                ct = new ColumnText(cb);

                arrColumnas[0].MargenIzquierdo = 60;
                arrColumnas[0].MargenDerecho = 280;
                arrColumnas[1].MargenIzquierdo = 320;
                arrColumnas[1].MargenDerecho = 530;

                ct.AddText(new Phrase("TITULO\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)));
                ct.AddText(new Phrase("PDF (del inglés Portable Document Format, Formato de Documento Portátil) es un formato de almacenamiento de documentos, desarrollado por la empresa Adobe Systems. Está especialmente ideado para documentos susceptibles de ser impresos, ya que especifica toda la información necesaria para la presentación final del documento, determinando todos los detalles de cómo va a quedar, no requiriéndose procesos anteriores de ajuste ni de maquetación.", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                ct.AddText(new Phrase("\n\nObjetivo General\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
                ct.AddText(new Phrase("PDF (del inglés Portable Document Format, Formato de Documento Portátil) es un formato de almacenamiento de documentos, desarrollado por la empresa Adobe Systems. Está especialmente ideado para documentos susceptibles de ser impresos, ya que especifica toda la información necesaria para la presentación final del documento, determinando todos los detalles de cómo va a quedar, no requiriéndose procesos anteriores de ajuste ni de maquetación.", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                ct.AddText(new Phrase("PDF (del inglés Portable Document Format, Formato de Documento Portátil) es un formato de almacenamiento de documentos, desarrollado por la empresa Adobe Systems. Está especialmente ideado para documentos susceptibles de ser impresos, ya que especifica toda la información necesaria para la presentación final del documento, determinando todos los detalles de cómo va a quedar, no requiriéndose procesos anteriores de ajuste ni de maquetación.", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                ct.AddText(new Phrase("\n\nObjetivos Especificos\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
                ct.AddText(new Phrase("PDF (del inglés Portable Document Format, Formato de Documento Portátil) es un formato de almacenamiento de documentos, desarrollado por la empresa Adobe Systems. Está especialmente ideado para documentos susceptibles de ser impresos, ya que especifica toda la información necesaria para la presentación final del documento, determinando todos los detalles de cómo va a quedar, no requiriéndose procesos anteriores de ajuste ni de maquetación.", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                ct.AddText(new Phrase("PDF (del inglés Portable Document Format, Formato de Documento Portátil) es un formato de almacenamiento de documentos, desarrollado por la empresa Adobe Systems. Está especialmente ideado para documentos susceptibles de ser impresos, ya que especifica toda la información necesaria para la presentación final del documento, determinando todos los detalles de cómo va a quedar, no requiriéndose procesos anteriores de ajuste ni de maquetación.", FontFactory.GetFont(FontFactory.HELVETICA, 12)));

                while (iEstado != ColumnText.NO_MORE_TEXT)
                {
                    ct.SetSimpleColumn(arrColumnas[iColumna].MargenDerecho, MARGEN_INFERIOR, arrColumnas[iColumna].MargenIzquierdo, oDoc.PageSize.Height, INTERLINEADO, Element.ALIGN_JUSTIFIED);
                    iEstado = ct.Go();
                    if (iEstado == ColumnText.NO_MORE_COLUMN)
                    {
                        iColumna = iColumna + 1;

                        if (iColumna > (arrColumnas.Length - 1))
                        {
                            oDoc.NewPage();
                            iColumna = 0;
                        }
                    }
                }

                oDoc.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Archivo Generado Exitosamente');</script>");

            }
            catch (Exception exj)
            {
                if (oDoc.IsOpen())
                {
                    oDoc.Close();
                }
            }
            finally
            {
                cb = null;
                pdfw = null;
                oDoc = null;
            }
        }


        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTarjeta();
            decimal monto = (decimal)Session["montoFinal"];
            lblMonto.Text = monto.ToString(); //Insertar el monto final

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Pagar();
        }

        #endregion

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            GenerarPDF();
        }
    }
}