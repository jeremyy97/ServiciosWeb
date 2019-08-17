using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Data;

namespace B_Cientificas_Cliente
{
    public partial class PagarEasyPay : System.Web.UI.Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            int pagar = 0;
            txtCodSeguridad.Attributes["type"] = "password";
            txtContrasenna.Attributes["type"] = "password";
            foreach (BLL.Carrito row in BLL.Carrito.carritoLista)
            {
                pagar += Convert.ToInt16(row.precio);
            }
            lblMonto.Text = pagar.ToString(); //AGREGAR MONTO 
            btnDescargar.Visible = false;
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Pagar();
        }

        #endregion

        #region Methods

        private void Limpiar()
        {
            txtCodSeguridad.Text = "";
            txtContrasenna.Text = "";
            txtNumCuenta.Text = "";
        }

        private void Pagar()
        {
            try
            {
                int Num_Cuenta = Convert.ToInt32(txtNumCuenta.Text);
                int Codigo_Seguridad = Convert.ToInt32(txtCodSeguridad.Text);
                string Contrasena = txtContrasenna.Text;
                decimal monto = Convert.ToDecimal(lblMonto.Text);

                var json = new WebClient().DownloadString("http://localhost:52081/api/EasyPay?Num_Cuenta=" + Num_Cuenta + "&Codigo_Seguridad=" + Codigo_Seguridad + "&Contrasena=" + Contrasena + "&monto=" + monto);
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
                Limpiar();

            }
        }

        #endregion
    }
}