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
    public partial class InformacionConsecutivo : System.Web.UI.Page
    {

        ConsecutivoLogica logica = new ConsecutivoLogica();
        TipoConsecutivoLogica tipoconsecutivo = new TipoConsecutivoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTiposConsecutivo();
        }

        private void cargarTiposConsecutivo()
        {
            DataSet ds = new DataSet();
            ds = tipoconsecutivo.CargarTiposConsecutivos();
            ddlTipoConsecutivo.DataSource = ds.Tables[0];
            ddlTipoConsecutivo.DataTextField = ds.Tables[0].Columns["Nombre"].ColumnName.ToString();
            ddlTipoConsecutivo.DataValueField = ds.Tables[0].Columns["Codigo"].ColumnName.ToString();
            ddlTipoConsecutivo.DataBind();
        }

        protected void chkBoxPrefijo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxPrefijo.Checked == true)
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

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CrearConsecutivo();
        }

        private void CrearConsecutivo()
        {
            if (Page.IsValid)
            {
                ConsecutivoLogica consecutivo = new ConsecutivoLogica();
                consecutivo.Consecutivo_id = Convert.ToInt32(txtID.Text);
                consecutivo.Nombre = txtNombre.Text;
                consecutivo.TipoConsecutivo_Id = Convert.ToInt32(ddlTipoConsecutivo.SelectedValue);
                consecutivo.Consecutivo = txtConsecutivo.Text;
                if (chkBoxPrefijo.Checked)
                {
                    consecutivo.PoseePrefijo = "true";
                    consecutivo.Prefijo = txtPrefijo.Text ;
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
                if (logica.InsertarConsecutivo(consecutivo))
                {

                    lblMensaje.Text = "Consecutivo " + txtNombre.Text + " creado correctamente";
                }
            }
        }
    }
}