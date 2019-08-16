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

namespace B_Cientificas_Cliente
{
    public partial class PagarTarjetaSeleccionada : System.Web.UI.Page
    {
        #region Var

        TarjetasLogica tarjeta = new TarjetasLogica();

        #endregion

        #region Methods

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
                txtNumeroTarjeta.Text = tarjeta.NumeroTarjeta;
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
            }
            else
            {

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
                        lblResultado.Text = "Número de Cuenta Inválido";
                        break;
                    case -2:
                        lblResultado.Text = "Código Seguridad Inválido";
                        break;
                    case -3:
                        lblResultado.Text = "Contraseña Inválida";
                        break;
                    case -4:
                        lblResultado.Text = "Fondos insuficientes";
                        break;
                    case 0:
                        lblResultado.Text = "Transacción Exitosa";
                        btnPagar.Visible = false;
                        //ASIGNAR LA DESCARGA A DESCARGAR
                        btnDescargar.Visible = true;
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


        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTarjeta();

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Pagar();
        }

        #endregion
    }
}