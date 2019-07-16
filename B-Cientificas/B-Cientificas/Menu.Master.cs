using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        public static string usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(usuario!= null)
            {
                lblUsuario.Text = usuario;
            }
            
        }
    }
}