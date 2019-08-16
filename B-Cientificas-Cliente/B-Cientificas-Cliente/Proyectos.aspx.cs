using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas_Cliente
{
    public partial class Proyectos : System.Web.UI.Page
    {
        BLL.Carrito carrito = new BLL.Carrito();
        ProyectosLogica logica = new ProyectosLogica();
        RamasCientificasLogica ramas = new RamasCientificasLogica();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = ramas.CargarRamas();
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem item = new ListItem();
                    item.Value = dr[0].ToString();
                    item.Text = dr[1].ToString();
                    ddlRamas.Items.Add(item);
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvProyectos.DataSource = logica.BuscarProyectos(ddlRamas.SelectedItem.Value, txtPrecio.Text,txtNombreProyecto.Text, txtIdioma.Text);
            gvProyectos.DataBind();
        }

        protected void gvProyectos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvProyectos.Rows[index];
            BLL.Carrito item = new BLL.Carrito();
            item.proyecto_id = row.Cells[1].Text;
            item.nombre = row.Cells[2].Text;
            item.precio = row.Cells[3].Text;
            if (carrito.agregar(item))
            {
                Response.Write("<script>alert('Proyecto agregado al carrito');</script>");
            }
            else
            {
                Response.Write("<script>alert('El proyecto que desea agregar ya se encuentra en el carrito');</script>");
            }
        }
    }
}