using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class CrearRolLaboratorio : System.Web.UI.Page
    {
        RolLaboratorioLogica logica = new RolLaboratorioLogica();
        ConsecutivoLogica consecutivoLogica = new ConsecutivoLogica();
        ConsecutivoLogica consecutivo = new ConsecutivoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Text = GenerarID();
            if(txtID.Text == "")
            {
                
               Response.Redirect("Default.aspx");
               
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

        private string GenerarID()
        {
            consecutivo = consecutivoLogica.BuscarConsecutivo(3);
            int codigo = Convert.ToInt32(consecutivo.Consecutivo)+1;
            int inicio = Convert.ToInt32(consecutivo.Inicio);
            int fin = Convert.ToInt32(consecutivo.Fin);
            if (codigo > inicio && codigo <= fin)
            {
                if (Convert.ToBoolean(consecutivo.PoseePrefijo))
                {
                    consecutivo.Consecutivo = codigo.ToString();
                    return consecutivo.Prefijo + "-" + codigo.ToString();
                }
                else
                {
                    consecutivo.Consecutivo = codigo.ToString();
                    return consecutivo.Prefijo + "-" + codigo.ToString();
                }

            }
            else
            {
                return null;
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RolLaboratorioLogica rol = new RolLaboratorioLogica();
                rol.RolLaboratorio_id = txtID.Text;
                rol.Nombre = txtNombre.Text;
                rol.Detalle = txtDetalle.Text;
                if (logica.InsertarRolLaboratorio(rol))
                {
                    lblMensaje.Text = "Rol Laboratorio " + txtNombre.Text + " creado correctamente";
                    consecutivoLogica.ActualizarConsecutivo(consecutivo);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("RolesLaboratorio.aspx");
        }
    }
}