using BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas_Cliente
{
    public partial class PagarTarjetaNueva : System.Web.UI.Page
    {

        #region Var

        TarjetasLogica logica = new TarjetasLogica();
        Random r = new Random();

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

        private TarjetasLogica CrearTarjeta()
        {
            try
            {
                string num = txtNum.Text;
                if (num.Length == 16 || num.Length == 15)
                {
                    if (Page.IsValid)
                    {
                        TarjetasLogica tarjeta = new TarjetasLogica();

                        tarjeta.NumeroTarjeta = txtNum.Text;
                        tarjeta.NombreTarjeta = txtNombre.Text;
                        tarjeta.MesVencimiento = txtMes.Text;
                        tarjeta.AnnoVencimiento = txtAnno.Text;
                        tarjeta.CVV = txtCVV.Text;
                        tarjeta.TipoTarjeta_Id = ActualizarTipoTarjeta();

                        if (chkBoxDebito.Checked)
                        {
                            tarjeta.Saldo = r.Next(10000, 800000).ToString();
                            tarjeta.Limite = String.Empty;
                            tarjeta.DebitoCredito = "Debito";
                        }
                        else
                        {
                            tarjeta.Saldo = r.Next(10000, 100000).ToString();
                            tarjeta.Limite = r.Next(500000, 2000000).ToString();
                            tarjeta.DebitoCredito = "Credito";
                        }


                        if (logica.CrearTarjeta(tarjeta))
                        {
                            lblResultado.Text = "Tarjeta Válida";
                            return tarjeta;
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Número Tarjeta Erróneo');</script>");
                    txtNum.Text = "";
                    return null;
                }
                return null;


            }
            catch (Exception)
            {

                throw;
            }
        }

        private TarjetasLogica CrearTarjetaGuardar()
        {
            try
            {
                string num = txtNum.Text;
                if (num.Length == 16 || num.Length == 15)
                {
                    if (Page.IsValid)
                    {
                        TarjetasLogica tarjeta = new TarjetasLogica();

                        tarjeta.NumeroTarjeta = txtNum.Text;
                        tarjeta.NombreTarjeta = txtNombre.Text;
                        tarjeta.MesVencimiento = txtMes.Text;
                        tarjeta.AnnoVencimiento = txtAnno.Text;
                        tarjeta.CVV = txtCVV.Text;
                        tarjeta.TipoTarjeta_Id = ActualizarTipoTarjeta();

                        if (chkBoxDebito.Checked)
                        {
                            tarjeta.Saldo = r.Next(10000, 800000).ToString();
                            tarjeta.Limite = String.Empty;
                            tarjeta.DebitoCredito = "Debito";
                        }
                        else
                        {
                            tarjeta.Saldo = r.Next(10000, 100000).ToString();
                            tarjeta.Limite = r.Next(500000, 2000000).ToString();
                            tarjeta.DebitoCredito = "Credito";
                        }


                        if (logica.CrearTarjeta(tarjeta))
                        {
                            lblResultado.Text = "Tarjeta Válida";
                            AsignarTarjeta("1", logica.BuscarIDTarjeta(tarjeta.NumeroTarjeta)); //AGREGAR AQUI EL ID DEL USUARIO
                            return tarjeta;
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Número Tarjeta Erróneo');</script>");
                    txtNum.Text = "";
                    return null;
                }
                return null;


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Pagar(TarjetasLogica tarjeta)
        {
            try
            {
                string Num_Tarjeta = tarjeta.NumeroTarjeta;
                string Mes_Exp = tarjeta.MesVencimiento;
                int Anno_Exp = Convert.ToInt32(tarjeta.AnnoVencimiento);
                int CVV = Convert.ToInt32(tarjeta.CVV);
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
                        btnSoloPagar.Visible = false;
                        btnPagarGuardar.Visible = false;
                        //ASIGNAR LA DESCARGA A DESCARGAR
                        btnDescargar.Visible = true;
                        TarjetasLogica buscar = new TarjetasLogica();
                        CrearOrden(monto, "1", buscar.BuscarIDTarjeta(Num_Tarjeta));
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

        private void AsignarTarjeta(string cliente, int tarjetaid)
        {
            TarjetaClienteLogica l = new TarjetaClienteLogica();
            l.CrearTarjetaCliente(cliente, tarjetaid);
        }

        private int ActualizarTipoTarjeta()
        {
            String num = txtNum.Text;
            char c = num[0];
            if (c.Equals('5'))
            {
                txtTipoTarjeta.Text = "MasterCard";
                return 1;
            }
            else
            {
                if (c.Equals('3'))
                {
                    txtTipoTarjeta.Text = "AmericanExpress";
                    return 3;
                }
                else
                {
                    if (c.Equals('4'))
                    {
                        txtTipoTarjeta.Text = "VISA";
                        return 2;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }


        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            decimal monto = (decimal)Session["montoFinal"];
            lblMonto.Text = monto.ToString(); //Insertar el monto final
            btnDescargar.Visible = false;
        }

        protected void txtNum_TextChanged(object sender, EventArgs e)
        {
            var x = ActualizarTipoTarjeta();
        }

        protected void btnSoloPagar_Click(object sender, EventArgs e)
        {
            TarjetasLogica t = CrearTarjeta();
            if (t != null)
            {
                Pagar(t);
            }
            else
            {
                lblResultado.Text = "Tarjeta inválida";
            }
        }

        protected void btnPagarGuardar_Click(object sender, EventArgs e)
        {
            TarjetasLogica t = CrearTarjetaGuardar();
            if (t != null)
            {
                Pagar(t);
            }
            else
            {
                lblResultado.Text = "Tarjeta inválida";
            }
        }

        #endregion
    }
}