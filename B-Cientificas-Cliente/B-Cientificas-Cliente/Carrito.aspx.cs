using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas_Cliente
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProceder_Click(object sender, EventArgs e)
        {
            string opcion = ddlMetodoPago.SelectedValue;
            if (opcion.Equals("Easy Pay"))
            {
                Response.Redirect("PagarEasyPay.aspx"); //Hay que mandar el monto
            }
            else
            {
                Response.Redirect("PagarTarjeta.aspx"); //Hay que mandar el monto
            }
          
        }
    }
}