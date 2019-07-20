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
    public partial class CrearPuesto : System.Web.UI.Page
    {
        PuestoLogica logica = new PuestoLogica();
        RolLaboratorioLogica rolLogica = new RolLaboratorioLogica();
        ConsecutivoLogica consecutivoLogica = new ConsecutivoLogica();
        ConsecutivoLogica consecutivo = new ConsecutivoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRoles();
            }
            
            txtID.Text = GenerarID();
            if (txtID.Text == "")
            {

                Response.Redirect("Default.aspx");

            }
        }

        private void CargarRoles()
        {
            DataSet ds = new DataSet();
            ds = rolLogica.CargasRolesLaboratorio();
            ddlRoles.DataSource = ds.Tables[0];
            ddlRoles.DataTextField = ds.Tables[0].Columns["Nombre"].ColumnName.ToString();
            ddlRoles.DataValueField = ds.Tables[0].Columns["ID"].ColumnName.ToString();
            ddlRoles.DataBind();
        }

        private string GenerarID()
        {
            consecutivo = consecutivoLogica.BuscarConsecutivo(5);
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
                    return  "PUE-" + codigo.ToString();
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
                PuestoLogica puesto = new PuestoLogica();
                puesto.Puesto_Id = txtID.Text;
                puesto.Nombre = txtNombre.Text;
                puesto.RolLaboratorio_ID = ddlRoles.SelectedValue;
                if (logica.InsertarPuesto(puesto))
                {
                    lblMensaje.Text = "Puesto " + txtNombre.Text + " creado correctamente";
                    consecutivoLogica.ActualizarConsecutivo(consecutivo);
                    Response.Redirect("Puestos.aspx");
                }
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Puestos.aspx");
        }
    }
}