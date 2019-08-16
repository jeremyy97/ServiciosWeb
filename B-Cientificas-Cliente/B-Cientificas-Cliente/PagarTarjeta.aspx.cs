using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas_Cliente
{
    public partial class PagarTarjeta : System.Web.UI.Page
    {

        TarjetasLogica logica = new TarjetasLogica();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTarjetas();
            btnDescargar.Visible = false;
            lblMonto.Text = "20000"; //Insertar el monto final
        }

        private void CargarTarjetas()
        {
            gvTarjetas.DataSource = logica.CargarTarjetasXCliente("1");
            gvTarjetas.DataBind();
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {

        }

        protected void gvTarjetas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvTarjetas.Rows[index];
            int id = Convert.ToInt32(row.Cells[1].Text);

            Session["seleccion"] = logica.CargarTarjeta(id);
            Response.Redirect("PagarTarjetaSeleccionada.aspx");
            

        }
    }
}