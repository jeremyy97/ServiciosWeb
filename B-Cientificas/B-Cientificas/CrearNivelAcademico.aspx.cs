using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class CrearNivelAcademico : System.Web.UI.Page
    {
        NivelAcademicoLogica logica = new NivelAcademicoLogica();
        ConsecutivoLogica consecutivoLogica = new ConsecutivoLogica();
        ConsecutivoLogica consecutivo = new ConsecutivoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = GenerarID();
            if (txtCodigo.Text == "")
            {

                Response.Redirect("Default.aspx");

            }
        }

        private string GenerarID()
        {
            consecutivo = consecutivoLogica.BuscarConsecutivo(6);
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
                    return "NIV-" + codigo.ToString();
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
                if (logica.InsertarNivel(nivel))
                {
                    lblMensaje.Text = "Nivel " + nivel.Nombre + " creado correctamente";
                    consecutivoLogica.ActualizarConsecutivo(consecutivo);
                    Response.Redirect("NivelAcademico.aspx");
                }
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NivelAcademico.aspx");
        }
    }
}