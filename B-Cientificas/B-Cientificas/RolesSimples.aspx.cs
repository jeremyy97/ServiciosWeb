using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class RolesSimples : System.Web.UI.Page
    {
        UsuarioLogica logica = new UsuarioLogica();
        RolUsuarioLogica roles = new RolUsuarioLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            DataSet ds = new DataSet();
            ds = logica.CargarUsuarios();
            lbxUsuarios.DataSource = ds.Tables[0];
            lbxUsuarios.DataTextField = ds.Tables[0].Columns["Usuario"].ColumnName.ToString();
            lbxUsuarios.DataValueField = ds.Tables[0].Columns["ID"].ColumnName.ToString();
            lbxUsuarios.DataBind();
        }

        protected void lbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            DataSet ds = new DataSet();
            ds = roles.CargarRoles(lbxUsuarios.SelectedValue);
           

        }
    }
}