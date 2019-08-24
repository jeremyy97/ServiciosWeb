using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas_Cliente
{
    public partial class VerCompras : System.Web.UI.Page
    {
        ComprasLogica logica = new ComprasLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvCompras.DataSource = logica.cargarCompras();
            gvCompras.DataBind();
        }
    }
}