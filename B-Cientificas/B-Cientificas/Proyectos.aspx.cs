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
    public partial class Proyectos : System.Web.UI.Page
    {
        RamasCientificasLogica ramas = new RamasCientificasLogica();
        ProyectosLogica logica = new ProyectosLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (DataRow dr in ramas.CargarRamasCientificas().Rows)
            {
                ListItem item = new ListItem();
                item.Text = dr[1].ToString();
                item.Value = dr[0].ToString();
                ddlRamas.Items.Add(item);
                
            }
            gvProyectos.DataSource = logica.CargarProyectos();
            gvProyectos.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtIdioma.Text = "";
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            gvProyectos.DataSource = logica.CargarProyectos();
            gvProyectos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ConsecutivoLogica consecutivo = logica.GenerarID();
            ProyectosLogica proyecto = new ProyectosLogica();
            if (consecutivo.PoseePrefijo == "true")
            {
                proyecto.Proyecto_id = consecutivo.Prefijo + "-" + consecutivo.Consecutivo;
            }
            else
            {
                proyecto.Proyecto_id = consecutivo.Consecutivo;
            }
            proyecto.Nombre = txtNombre.Text;
            proyecto.Precio = txtPrecio.Text;
            proyecto.Idioma = txtIdioma.Text;
            proyecto.RamaCientifica_Id = ddlRamas.SelectedItem.Value;
            if(logica.GuardarProyecto(proyecto))
            {
                lblMensaje.Text = "Proyecto creado con exito";
                consecutivo.ActualizarConsecutivo(consecutivo);
            }
        }

        protected void btnEliminarRegistro_Click(object sender, EventArgs e)
        {
            if (logica.EliminarProyecto(txtCodigo.Text))
            {
                lblMensaje.Text = "Proyecto eliminado con exito";
            }
            else
            {
                lblMensaje.Text = "No existe un proyecto con el ID ingresado";
            }
        }
    }
}