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
            List<RolUsuarioLogica> usuarioRoles = new List<RolUsuarioLogica>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                usuarioRoles.Add(new RolUsuarioLogica { RolUsuarioID = Convert.ToInt32(dr["RolUsuario_id"]), UsuarioID = Convert.ToString(dr["Usuario_id"]) });
            }

            for (int i = 0; i < usuarioRoles.Count; i++)
            {
                if (usuarioRoles[i].RolUsuarioID == 1)
                {
                    cbx1.Checked = true;
                }
            }



            /*string rol1 = String.Empty;
            string rol2 = String.Empty;
            string[] lista_roles = Roles.GetRolesForUser(usuario);

            for (int i = 0; i <= lista_roles.Length - 1; i++)
            {
                rol1 = lista_roles[i].ToString();
                for (int j = 0; j <= chkl_roles.Items.Count - 1; j++)
                {
                    rol2 = chkl_roles.Items[j].Text;
                    if (rol1.Equals(rol2))
                    {
                        chkl_roles.Items[j].Selected = true;
                    }
                }
            }*/

        }
    }
}