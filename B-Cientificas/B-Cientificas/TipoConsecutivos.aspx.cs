using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class TipoConsecutivos : System.Web.UI.Page
    {
        TipoConsecutivoLogica logica = new TipoConsecutivoLogica();
        static int id = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrid();
            UsuarioLogica usuarioactual = (UsuarioLogica)Session["usuario"];
            RolUsuarioLogica roles = new RolUsuarioLogica();
            if (roles.RolAdministrador(usuarioactual.Usuario_id) || roles.RolConsecutivos(usuarioactual.Usuario_id))
            {

            }
            else
            {
                Response.Write("<script>alert('No cuenta con los permisos necesarios');</script>");
                Response.Redirect("Default.aspx");
            }
        }

        protected void gvTiposConsecutivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvTiposConsecutivos.Rows[index];
            TipoConsecutivoLogica tipoConsecutivo = new TipoConsecutivoLogica();
            tipoConsecutivo = logica.BuscarTipoConsecutivo(index + 1);

            txtID.Text = tipoConsecutivo.TipoConsecutivoID.ToString();
            txtNombre.Text = tipoConsecutivo.Nombre;


        }

        private void CargarGrid()
        {
            gvTiposConsecutivos.DataSource = logica.CargarTiposConsecutivos().Tables[0];
            gvTiposConsecutivos.DataBind();
        }

        protected void gvTiposConsecutivos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTiposConsecutivos.PageIndex = e.NewPageIndex;
            this.CargarGrid();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TipoConsecutivoLogica tipoConsecutivo = new TipoConsecutivoLogica();
                tipoConsecutivo.TipoConsecutivoID = Convert.ToInt32(txtID.Text);
                tipoConsecutivo.Nombre = txtNombre.Text;

                if (tipoConsecutivo.ActualizarTipoConsecutivo(tipoConsecutivo))
                {
                    lblMensaje.Text = "Tipo Consecutivo " + txtNombre.Text + " actualizado correctamente";
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearTipoConsecutivo.aspx");
        }
    }
}