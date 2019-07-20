using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class Puestos : System.Web.UI.Page
    {
        PuestoLogica logica = new PuestoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarPuestos();
        }

        private void CargarPuestos()
        {
            
        }
    }
}