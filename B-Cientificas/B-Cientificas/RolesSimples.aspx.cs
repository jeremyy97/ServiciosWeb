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
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
            
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
            this.CargarRoles();
        }

        private void CargarRoles()
        {
            cbx1.Checked = false;
            cbx2.Checked = false;
            cbx3.Checked = false;
            cbx4.Checked = false;
            cbx5.Checked = false;
            DataSet ds = new DataSet();
            ds = roles.CargarRoles(lbxUsuarios.SelectedValue);
            List<RolUsuarioLogica> usuarioRoles = new List<RolUsuarioLogica>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                usuarioRoles.Add(new RolUsuarioLogica { RolUsuarioID = Convert.ToInt32(dr["RolUsuario_id"]), UsuarioID = Convert.ToString(dr["Usuario_id"]) });
            }

            for (int i = 0; i < usuarioRoles.Count; i++)
            {
                switch (usuarioRoles[i].RolUsuarioID)
                {
                    case 1:
                        cbx1.Checked = true;
                        break;
                    case 2:
                        cbx2.Checked = true;
                        break;
                    case 3:
                        cbx3.Checked = true;
                        break;
                    case 4:
                        cbx4.Checked = true;
                        break;
                    case 5:
                        cbx5.Checked = true;
                        break;
                    default:
                        break;
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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            roles.EliminarRoles(lbxUsuarios.SelectedValue.ToString());

            if (cbx1.Checked == true)
            {
                roles.InsertaRol(1, lbxUsuarios.SelectedValue.ToString());
            }
            if (cbx2.Checked == true)
            {
                roles.InsertaRol(2, lbxUsuarios.SelectedValue.ToString());
            }
            if (cbx3.Checked == true)
            {
                roles.InsertaRol(3, lbxUsuarios.SelectedValue.ToString());
            }
            if (cbx4.Checked == true)
            {
                roles.InsertaRol(4, lbxUsuarios.SelectedValue.ToString());
            }
            if (cbx5.Checked == true)
            {
                roles.InsertaRol(5, lbxUsuarios.SelectedValue.ToString());
            }
        }
    }
}