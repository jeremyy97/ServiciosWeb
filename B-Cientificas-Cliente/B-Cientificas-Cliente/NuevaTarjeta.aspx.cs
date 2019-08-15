using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas_Cliente
{
    public partial class NuevaTarjeta : System.Web.UI.Page
    {

        TarjetasLogica logica = new TarjetasLogica();
        Random r = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tarjetas.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            CrearTarjeta();
        }

        private void CrearTarjeta()
        {
            try
            {
                string num = txtNumeroTarjeta.Text;
                if (num.Length == 16  || num.Length == 15)
                {
                    if (Page.IsValid)
                    {
                        TarjetasLogica tarjeta = new TarjetasLogica();

                        tarjeta.NumeroTarjeta = txtNumeroTarjeta.Text;
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
                            AsignarTarjeta("1",logica.BuscarIDTarjeta(tarjeta.NumeroTarjeta));
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarjeta Actualizada correctamente');</script>");
                            Response.Redirect("Tarjetas.aspx");
                        }
                    }
                }
                else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Número Tarjeta Erróneo');</script>");
                        txtNumeroTarjeta.Text = "";
                    }

                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AsignarTarjeta(string cliente, int tarjetaid)
        {
            TarjetaClienteLogica l = new TarjetaClienteLogica();
            l.CrearTarjetaCliente(cliente, tarjetaid);
        }

        private int ActualizarTipoTarjeta()
        {
            String num = txtNumeroTarjeta.Text;
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

        protected void txtNumeroTarjeta_TextChanged(object sender, EventArgs e)
        {
            var x = ActualizarTipoTarjeta();
        }
    }
}