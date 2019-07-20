using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class Descargas : System.Web.UI.Page
    {
        DescargasLogica logica = new DescargasLogica();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            gvDescargas.DataSource = logica.CargarDescargas(txtFechaInicio.Text, txtFechaFinal.Text);
            gvDescargas.DataBind();
            panelResultados.Visible = true;
        }
    }
}