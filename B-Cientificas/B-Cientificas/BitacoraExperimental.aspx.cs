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
    public partial class BitacoraExperimental : System.Web.UI.Page
    {
        BitacoraExperimentalLogica logica = new BitacoraExperimentalLogica();
        ProyectosLogica proyectos = new ProyectosLogica();
        UsuarioLogica usuarios = new UsuarioLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvExperimentos.DataSource = logica.CargarBitacora();
            gvExperimentos.DataBind();

            if (!IsPostBack)
            {
                foreach (DataRow dr in proyectos.CargarProyectos().Rows)
                {
                    ListItem item = new ListItem();
                    item.Value = dr[0].ToString();
                    item.Text = dr[1].ToString();
                    ddlProyectos.Items.Add(item);
                }

                foreach (DataRow dr in usuarios.CargarUsuarios().Tables[0].Rows)
                {
                    ListItem item = new ListItem();
                    item.Value = dr[0].ToString();
                    item.Text = dr[1].ToString() + " " +  dr[2].ToString() + " " + dr[3].ToString();
                    ddlFirmaTestigos.Items.Add(item);
                    ddlResponsables.Items.Add(item);
                    ddlUsuariosTestigos.Items.Add(item);
                }
            }

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

        protected void ddlProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlProyectos.SelectedValue != "-8")
            {
                txtCodProyecto.Text = ddlProyectos.SelectedValue;
                ConsecutivoLogica consecutivo = logica.GenerarID();
                if (consecutivo != null)
                {
                    txtCodExperimento.Text = (Convert.ToInt16(consecutivo.Consecutivo) + 1).ToString();
                }
            }        
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (ddlResponsables.SelectedItem.Value != "-8" && ddlUsuariosTestigos.SelectedItem.Value != "-8")
                {
                    ConsecutivoLogica consecutivo = logica.GenerarID();
                    BitacoraExperimentalLogica experimento = new BitacoraExperimentalLogica();
                    experimento.Experimento_id = txtCodExperimento.Text;
                    experimento.Proyecto_Id = txtCodProyecto.Text;
                    experimento.Nombre = txtNombre.Text;
                    experimento.Usuario_Crea = ddlResponsables.SelectedItem.Value;
                    experimento.FechaFin = fechaFinal.SelectedDate.ToString();
                    experimento.FechaInicio = fechaInicio.SelectedDate.ToString();
                    experimento.urlMuestra1 = GuardarImagen(fileupMuestra1, "usuarios/firmas");
                    experimento.urlMuestra2 = GuardarImagen(fileupMuestra2, "usuarios/firmas");
                    experimento.urlMuestra3 = GuardarImagen(fileupMuestra3, "usuarios/firmas");
                    experimento.urlMuestra4 = GuardarImagen(fileupMuestra4, "usuarios/firmas");
                    experimento.urlMuestra5 = GuardarImagen(fileupMuestra5, "usuarios/firmas");
                    experimento.Usuario_Testigo = ddlUsuariosTestigos.SelectedItem.Value;
                    string detalle = txtObjGen.Text + "><" + txtObjEsp.Text + "><" + txtEquipoUsado.Text + "><" + txtProcedimientos.Text;
                    if (detalle.Length < 8000)
                    {
                        experimento.Detalle1 = detalle;
                        experimento.Detalle2 = "";
                    }
                    if (logica.CrearExperimento(experimento))
                    {
                        lblMensaje.Text = "Proyecto creado con exito";
                        consecutivo.ActualizarConsecutivo(consecutivo);
                    }
                }
                else
                {
                    lblMensaje.Text = "Debe completar todos los campos para crear el experimento";
                }
            }
            else
            {
                lblMensaje.Text = "Debe completar todos los campos para crear el experimento";
            }
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

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodExperimento.Text = "";
            txtCodProyecto.Text = "";
            txtEquipoUsado.Text = "";
            txtNombre.Text = "";
            txtObjEsp.Text = "";
            txtObjGen.Text = "";
            txtProcedimientos.Text = ""; 
        }
    }
}