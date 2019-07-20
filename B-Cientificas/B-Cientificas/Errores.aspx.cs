using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class Errores : System.Web.UI.Page
    {
        ErroresLogica logica = new ErroresLogica();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            gvErrores.DataSource =  logica.CargarErrores(txtFechaInicio.Text,txtFechaFinal.Text);
            gvErrores.DataBind();
            panelResultados.Visible = true;

        }
    }
}