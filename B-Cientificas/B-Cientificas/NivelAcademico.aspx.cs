using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class NivelAcademico : System.Web.UI.Page
    {
        NivelAcademicoLogica logica = new NivelAcademicoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarNiveles();
            }
            UsuarioLogica usuarioactual = (UsuarioLogica)Session["usuario"];
            RolUsuarioLogica roles = new RolUsuarioLogica();
            if (roles.RolAdministrador(usuarioactual.Usuario_id) || roles.RolSeguridad(usuarioactual.Usuario_id))
            {

            }
            else
            {
                Response.Write("<script>alert('No cuenta con los permisos necesarios');</script>");
                Response.Redirect("Default.aspx");
            }
        }

        private void CargarNiveles()
        {
            gvNiveles.DataSource = logica.CargarNivelesAcademicos().Tables[0];
            gvNiveles.DataBind();
            btnActualizar.Visible = false;
            btnLimpiar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtDetalle.Text = "";
        }

        protected void gvNiveles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvNiveles.Rows[index];
            string id = row.Cells[1].Text;


            NivelAcademicoLogica nivel = new NivelAcademicoLogica();
            nivel = logica.BuscarNivelAcademico(id);

            txtCodigo.Text = nivel.NivelAcademico_id;
            ddlNiveles.SelectedValue = nivel.Nombre;
            txtDetalle.Text = nivel.Detalle;
            chkBoxCompleto.Checked = Convert.ToBoolean(nivel.Completo);

            btnActualizar.Visible = true;
            btnLimpiar.Visible = true;
            btnEliminar.Visible = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                NivelAcademicoLogica nivel = new NivelAcademicoLogica();
                nivel.NivelAcademico_id = txtCodigo.Text;
                nivel.Nombre = ddlNiveles.SelectedValue;
                nivel.Detalle = txtDetalle.Text;
                
                if (chkBoxCompleto.Checked)
                {
                    nivel.Completo = "true";
                }
                else
                {
                    nivel.Completo = "false";
                }

                if (logica.ActualizarNivel(nivel))
                {
                    lblMensaje.Text = "Puesto  " + nivel.Nombre + " actualizado correctamente";
                    this.CargarNiveles();
                    Limpiar();
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearNivelAcademico.aspx");
        }

        protected void chkBoxCompleto_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}