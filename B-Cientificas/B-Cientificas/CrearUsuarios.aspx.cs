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
    public partial class CrearUsuarios : System.Web.UI.Page
    {
        UsuarioLogica logica = new UsuarioLogica();
        PuestoLogica puestos = new PuestoLogica();
        NivelAcademicoLogica niveles = new NivelAcademicoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarNiveles();
                CargarPuestos();
                CargarUsuarios();
                imgFirma.Visible = false;
                imgFoto.Visible = false;
                txtPassword.ReadOnly = true;
                txtConfirmarPassword.ReadOnly = true;
                txtPassword.Attributes["type"] = "password";
                txtConfirmarPassword.Attributes["type"] = "password";
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

        private void CargarUsuarios()
        {
           
            gvUsuarios.DataSource = logica.CargarUsuariosResu();
            
            gvUsuarios.DataBind();
            btnActualizar.Visible = false;
            btnLimpiar.Visible = false;
          
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

        private void Limpiar()
        {
            txtCelular.Text="";
            txtCodigo.Text = "";
            txtConfirmarPassword.Text = "";
            txtNombre.Text = "";
            txtNombreUsuario.Text = "";
            txtPassword.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            imgFirma.Visible = false;
            imgFoto.Visible = false;
          
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvUsuarios.Rows[index];
            string id = row.Cells[1].Text;

            UsuarioLogica usuario = new UsuarioLogica();
            usuario = logica.BuscarUsuario(id);

            txtCelular.Text = usuario.Celular;
            txtCodigo.Text = usuario.Usuario_id;
            txtConfirmarPassword.Text = usuario.Password;
            txtNombre.Text = usuario.Nombre;
            txtNombreUsuario.Text = usuario.Usuario;
            txtPassword.Text = usuario.Password;
            txtPrimerApellido.Text = usuario.Primer_Apellido;
            txtSegundoApellido.Text = usuario.Segundo_Apellido;
            ddlPuestos.SelectedValue = usuario.Puesto_Id;
            ddlNivelesAcademicos.SelectedValue = usuario.NivelAcademico_Id;
            imgFirma.Visible = true;
            imgFoto.Visible = true;
            imgFirma.ImageUrl = usuario.UrlFirma;
            imgFoto.ImageUrl = usuario.UrlFoto;

            btnActualizar.Visible = true;
            btnLimpiar.Visible = true;
            

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
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
                    if (fileupFirma.HasFile)
                    {
                        usuario.UrlFirma = GuardarImagen(fileupFirma, "usuarios/firmas");
                    }
                    else
                    {
                        usuario.UrlFirma = imgFirma.ImageUrl;
                    }
                    if (fileupFoto.HasFile)
                    {
                        usuario.UrlFoto = GuardarImagen(fileupFoto, "usuarios/fotos");
                    }
                    else
                    {
                        usuario.UrlFoto = imgFoto.ImageUrl;
                    }

                    usuario.Segundo_Apellido = txtSegundoApellido.Text;
                    usuario.Puesto_Id = ddlPuestos.SelectedValue;
                    usuario.Primer_Apellido = txtPrimerApellido.Text;
                    usuario.Password = txtPassword.Text;
                    usuario.Nombre = txtNombre.Text;
                    usuario.NivelAcademico_Id = ddlNivelesAcademicos.SelectedValue;
                    usuario.Celular = txtCelular.Text;

                    if (logica.ActualizarUsuario(usuario))
                    {
                        lblMensaje.Text = "Usuario  " + txtNombre.Text + " actualizado correctamente";
                        this.CargarUsuarios();
                        Limpiar();
                    }
                }
                else
                {
                    lblMensaje.Text = "Contraseñas no coinciden";
                }
               
            }
        }

        private string GuardarImagen(FileUpload file,string directorio)
        {
            string path = String.Empty;
            if (file.HasFile)
            {
                string ext = System.IO.Path.GetExtension(file.FileName);
                ext = ext.ToLower();

                if (ext == ".png" || ext == ".jpg")
                {
                    file.SaveAs(Server.MapPath(directorio+"/" + file.FileName));
                     path = directorio+"/" + file.FileName;
                    
                }
            }
            return path;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoUsuario.aspx");
        }

        protected void chkBoxCambiarContrasenna_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxCambiarContrasenna.Checked == true)
            {
                txtPassword.ReadOnly = false;
                txtConfirmarPassword.ReadOnly = false;
            }
            else
            {
                txtPassword.ReadOnly = true;
                txtConfirmarPassword.ReadOnly = true;
            }
        }
    }
}