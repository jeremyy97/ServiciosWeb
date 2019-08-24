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
    public partial class Bitacora : System.Web.UI.Page
    {
        static Boolean mostrarResultados = false;
        static Boolean existenResultados = true;
        BitacoraLogica logica = new BitacoraLogica();
        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (existenResultados)
                {
                    panelResultados.Visible = true;
                }
            }

            UsuarioLogica usuarioactual = (UsuarioLogica)Session["usuario"];
            RolUsuarioLogica roles = new RolUsuarioLogica();
            if (roles.RolAdministrador(usuarioactual.Usuario_id) || roles.RolConsulta(usuarioactual.Usuario_id))
            {
                
            }
            else
            {
                Response.Write("<script>alert('No cuenta con los permisos necesarios');</script>");
                Response.Redirect("Default.aspx");
            }

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            panelResultados.Visible = true;
            DataTable bitacora = new DataTable();
            bitacora = logica.CargarBitacora(txtUsuario.Text, txtFechaInicio.Text, txtFechaFinal.Text, ddlTipo.SelectedItem.Text);
            gvBitacora.DataSource = bitacora;
            gvBitacora.DataBind();
        }

        protected void gvBitacora_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvBitacora.Rows[index];
            BitacoraLogica bitacora = new BitacoraLogica();
            bitacora = logica.BuscarRegistroBitacora(row.Cells[0].Text);


        }
    }
}