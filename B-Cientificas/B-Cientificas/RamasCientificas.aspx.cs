using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class RamasCientificas : System.Web.UI.Page
    {
        RamasCientificasLogica logica = new RamasCientificasLogica();
        ConsecutivoLogica consecutivoLogica = new ConsecutivoLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvRamasCientificas.DataSource = logica.CargarRamasCientificas();
            gvRamasCientificas.DataBind();

            UsuarioLogica usuarioactual = (UsuarioLogica)Session["usuario"];
            RolUsuarioLogica roles = new RolUsuarioLogica();
            if (roles.RolAdministrador(usuarioactual.Usuario_id) || roles.RolMantenimiento(usuarioactual.Usuario_id))
            {

            }
            else
            {
                Response.Write("<script>alert('No cuenta con los permisos necesarios');</script>");
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            gvRamasCientificas.DataSource = logica.CargarRamasCientificas();
            gvRamasCientificas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ConsecutivoLogica consecutivo = logica.GenerarID();
            RamasCientificasLogica rama = new RamasCientificasLogica();
            if (consecutivo.PoseePrefijo == "true")
            {
                rama.RamaCientifica_Id = consecutivo.Prefijo + "-" + consecutivo.Consecutivo;
            }
            else
            {
                rama.RamaCientifica_Id = consecutivo.Consecutivo;
            }
            rama.Nombre = txtNombre.Text;
            logica.CrearRamaCientifica(rama);
            lblMensaje.Text = "Rama cientifica creada con exito";
            consecutivoLogica.ActualizarConsecutivo(consecutivo);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }

        protected void btnEliminarRegistro_Click(object sender, EventArgs e)
        {
            if (logica.EliminarRama(txtCodigo.Text))
            {
                lblMensaje.Text = "Rama cientifica eliminada con exito";
            }
            else
            {
                lblMensaje.Text= "No existe una rama cientifica con el ID ingresado";
            }
        }
    }
}