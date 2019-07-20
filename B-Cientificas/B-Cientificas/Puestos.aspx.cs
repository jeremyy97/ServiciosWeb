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
    public partial class Puestos : System.Web.UI.Page
    {
        PuestoLogica logica = new PuestoLogica();
        RolLaboratorioLogica rolesLogica = new RolLaboratorioLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRoles();
                CargarPuestos();
            }
            
           
        }

        private void CargarPuestos()
        {
            gvPuestos.DataSource = logica.CargarPuestos().Tables[0];
            gvPuestos.DataBind();
            btnActualizar.Visible = false;
            btnLimpiar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void CargarRoles()
        {
            DataSet ds = new DataSet();
            ds = rolesLogica.CargasRolesLaboratorio();
            ddlRoles.DataSource = ds.Tables[0];
            ddlRoles.DataTextField = ds.Tables[0].Columns["Nombre"].ColumnName.ToString();
            ddlRoles.DataValueField = ds.Tables[0].Columns["ID"].ColumnName.ToString();
            ddlRoles.DataBind();
        }

        private void Limpiar()
        {
            txtID.Text = "";
            txtNombre.Text = "";
        }

        protected void gvPuestos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPuestos.Rows[index];
            string id=row.Cells[1].Text;
          
            

            PuestoLogica puesto = new PuestoLogica();
            puesto = logica.BuscarPuesto(id);

            txtID.Text = puesto.Puesto_Id;
            txtNombre.Text = puesto.Nombre;
            ddlRoles.SelectedValue = puesto.RolLaboratorio_ID;

            btnActualizar.Visible = true;
            btnLimpiar.Visible = true;
            btnEliminar.Visible = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                PuestoLogica puesto = new PuestoLogica();
                puesto.Puesto_Id = txtID.Text;
                puesto.Nombre = txtNombre.Text;
                puesto.RolLaboratorio_ID = ddlRoles.SelectedValue;

                if (logica.ActualizarPuesto(puesto))
                {
                    lblMensaje.Text = "Puesto  " + txtNombre.Text + " actualizado correctamente";
                    this.CargarRoles();
                    this.CargarPuestos();
                    Limpiar();
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearPuesto.aspx");
        }
    }
}