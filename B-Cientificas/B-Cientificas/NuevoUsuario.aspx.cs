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
    public partial class NuevoUsuario : System.Web.UI.Page
    {
        UsuarioLogica logica = new UsuarioLogica();
        RolLaboratorioLogica rolLogica = new RolLaboratorioLogica();
        ConsecutivoLogica consecutivoLogica = new ConsecutivoLogica();
        ConsecutivoLogica consecutivo = new ConsecutivoLogica();
        PuestoLogica puestos = new PuestoLogica();
        NivelAcademicoLogica niveles = new NivelAcademicoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarNiveles();
                CargarPuestos();
                txtPassword.Attributes["type"] = "password";
                txtConfirmarPassword.Attributes["type"] = "password";
            }

            txtCodigo.Text = GenerarID();
            if (txtCodigo.Text == "")
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

        private void CargarNiveles()
        {
            DataSet ds = new DataSet();
            ds = niveles.CargarNivelesAcademicos();
            ddlNivelesAcademicos.DataSource = ds.Tables[0];
            ddlNivelesAcademicos.DataTextField = ds.Tables[0].Columns["Detalle"].ColumnName.ToString();
            ddlNivelesAcademicos.DataValueField = ds.Tables[0].Columns["Nivel Academico"].ColumnName.ToString();
            ddlNivelesAcademicos.DataBind();
        }

        private void CargarPuestos()
        {
            DataSet ds = new DataSet();
            ds = puestos.CargarPuestos();
            ddlPuestos.DataSource = ds.Tables[0];
            ddlPuestos.DataTextField = ds.Tables[0].Columns["Nombre"].ColumnName.ToString();
            ddlPuestos.DataValueField = ds.Tables[0].Columns["ID"].ColumnName.ToString();
            ddlPuestos.DataBind();
        }

        private string GenerarID()
        {
            consecutivo = consecutivoLogica.BuscarConsecutivo(9);
            int codigo = Convert.ToInt32(consecutivo.Consecutivo) + 1;
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
                    return "USU-" + codigo.ToString();
                }

            }
            else
            {
                return null;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UsuarioLogica usuario = new UsuarioLogica();
                if (txtPassword.Text == txtConfirmarPassword.Text)
                {
                    usuario.Usuario_id = txtCodigo.Text;
                    usuario.Usuario = txtNombreUsuario.Text;
                    usuario.UrlFirma = GuardarImagen(fileupFirma, "usuarios/firmas");
                   
                    usuario.UrlFoto = GuardarImagen(fileupFoto, "usuarios/fotos");
                   
                    usuario.Segundo_Apellido = txtSegundoApellido.Text;
                    usuario.Puesto_Id = ddlPuestos.SelectedValue;
                    usuario.Primer_Apellido = txtPrimerApellido.Text;
                    usuario.Password = txtPassword.Text;
                    usuario.Nombre = txtNombre.Text;
                    usuario.NivelAcademico_Id = ddlNivelesAcademicos.SelectedValue;
                    usuario.Celular = txtCelular.Text;

                    if (logica.CrearUsuario(usuario))
                    {
                        lblMensaje.Text = "Usuario  " + txtNombre.Text + " creado correctamente";
                        consecutivoLogica.ActualizarConsecutivo(consecutivo);
                        Response.Redirect("CrearUsuarios.aspx");
                    }
                }
                else
                {
                    lblMensaje.Text = "Contraseñas no coinciden";
                }
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearUsuarios.aspx");
        }

        private string GuardarImagen(FileUpload file, string directorio)
        {
            string path = String.Empty;
            if (file.HasFile)
            {
                string ext = System.IO.Path.GetExtension(file.FileName);
                ext = ext.ToLower();

                if (ext == ".png" || ext == ".jpg")
                {
                    file.SaveAs(Server.MapPath(directorio + "/" + file.FileName));
                    path = directorio + "/" + file.FileName;

                }
            }
            return path;
        }
    }
}