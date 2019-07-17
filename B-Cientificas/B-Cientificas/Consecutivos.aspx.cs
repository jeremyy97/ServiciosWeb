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
        protected void Page_Load(object sender, EventArgs e)
        {
            gvConsecutivos.DataSource = logica.CargarConsecutivos().Tables[0];
            gvConsecutivos.DataBind();
        }

        protected void gvConsecutivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvConsecutivos.Rows[index];
            ConsecutivoLogica consecutivo = new ConsecutivoLogica();
            consecutivo = logica.BuscarConsecutivo(index +1);

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
                txtFinal.Text = consecutivo.Inicio;
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
    }
}