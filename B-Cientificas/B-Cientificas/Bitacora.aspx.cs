using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class Bitacora : System.Web.UI.Page
    {
        static Boolean mostrarResultados = false;
        static Boolean existenResultados = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (existenResultados)
                {
                    panelResultados.Visible = true;
                }
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            panelResultados.Visible = true;
        }
    }
}