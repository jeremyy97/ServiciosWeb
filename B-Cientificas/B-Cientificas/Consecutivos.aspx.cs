using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class Consecutivos : System.Web.UI.Page
    {
        ConsecutivoLogica logica = new ConsecutivoLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvConsecutivos.DataSource = logica.CargarConsecutivos().Tables[0];
            gvConsecutivos.DataBind();
        }
    }
}