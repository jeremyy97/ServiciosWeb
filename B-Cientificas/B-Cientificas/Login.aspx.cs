using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace B_Cientificas
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioLogica logica = new UsuarioLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPassword.Attributes["type"] = "password";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (logica.Login(txtUsuario.Text, txtPassword.Text))
            {
                Menu.usuario = txtUsuario.Text;
                UsuarioLogica usuarioActual = logica.BuscarUsuarioXUserName(txtUsuario.Text);
                Session["usuario"] = usuarioActual;
                Response.Redirect("Default.aspx");
            }
        }
    }
}