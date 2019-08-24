using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class Consecutivos : System.Web.UI.Page
    {
        ConsecutivoLogica logica = new ConsecutivoLogica();
        static int id = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            gvConsecutivos.DataSource = logica.CargarConsecutivos().Tables[0];
            gvConsecutivos.DataBind();

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

        protected void gvConsecutivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvConsecutivos.Rows[index];
            ConsecutivoLogica consecutivo = new ConsecutivoLogica();
            consecutivo = logica.BuscarConsecutivo(index +1);

            id = consecutivo.Consecutivo_id;
            txtDescripcion.Text = consecutivo.Nombre;
            txtConsecutivo.Text = consecutivo.Consecutivo;
            chkBoxPrefijo.Checked = Convert.ToBoolean(consecutivo.PoseePrefijo);
            if(chkBoxPrefijo.Checked)
            {
                txtPrefijo.ReadOnly = false;
                txtPrefijo.Text = consecutivo.Prefijo;
            }
            else
            {
                txtPrefijo.ReadOnly = true;
                txtPrefijo.Text = "";
            }

            chkBoxRango.Checked = Convert.ToBoolean(consecutivo.PoseeRango);
            if (chkBoxRango.Checked)
            {
                txtInicio.ReadOnly = false;
                txtInicio.Text = consecutivo.Inicio;
                txtFinal.ReadOnly = false;
                txtFinal.Text = consecutivo.Fin;
            }
            else
            {
                txtInicio.ReadOnly = true;
                txtInicio.Text = "";
                txtFinal.ReadOnly = true;
                txtFinal.Text = "";
            }
        }

        protected void chkBoxPrefijo_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBoxPrefijo.Checked == true)
            {
                txtPrefijo.ReadOnly = false;
            }
            else
            {
                txtPrefijo.ReadOnly = true;
            }
        }

        protected void chkBoxRango_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxRango.Checked == true)
            {
                txtInicio.ReadOnly = false;
                txtFinal.ReadOnly = false;
            }
            else
            {
                txtInicio.ReadOnly = true;
                txtFinal.ReadOnly = true;
            }
        }

        protected void chkBoxPrefijo_Load(object sender, EventArgs e)
        {
           
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ConsecutivoLogica consecutivo = new ConsecutivoLogica();
                consecutivo.Consecutivo_id = id;
                consecutivo.Nombre = txtDescripcion.Text;
                consecutivo.Consecutivo = txtConsecutivo.Text;
                if (chkBoxPrefijo.Checked)
                {
                    consecutivo.PoseePrefijo = "true";
                    consecutivo.Prefijo = txtPrefijo.Text; 
                }
                else
                {
                    consecutivo.PoseePrefijo = "false";
                    consecutivo.Prefijo = "";
                }
                if (chkBoxRango.Checked)
                {
                    consecutivo.PoseeRango = "true";
                    consecutivo.Inicio = txtInicio.Text;
                    consecutivo.Fin = txtFinal.Text;
                }
                else
                {
                    consecutivo.PoseeRango = "false";
                    consecutivo.Inicio = "0";
                    consecutivo.Fin = "0";
                }
                consecutivo.TipoConsecutivo_Id = logica.BuscarConsecutivo(id).TipoConsecutivo_Id;
                if (logica.ActualizarConsecutivo(consecutivo))
                {

                    lblMensaje.Text = "Consecutivo " + txtDescripcion.Text + " actualizado correctamente";
                }
            }    
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
        }

        protected void txtConsecutivo_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtConsecutivo_Unload(object sender, EventArgs e)
        {
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void nuevobtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InformacionConsecutivo.aspx");
        }
    }
}