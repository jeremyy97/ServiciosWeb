using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas_Cliente
{
    public partial class Carrito : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataColumn column;
            column = new DataColumn("Codigo", Type.GetType("System.String"));
            dt.Columns.Add(column);
            column = new DataColumn("Proyecto", Type.GetType("System.String"));
            dt.Columns.Add(column);
            column = new DataColumn("Precio", Type.GetType("System.String"));
            dt.Columns.Add(column);
            foreach (var item in BLL.Carrito.carritoLista)
            {
                string[] items = { item.proyecto_id, item.nombre, item.precio };
                dt.Rows.Add(items);
            }
            gvCarrito.DataSource = dt;
            gvCarrito.DataBind();
        }

        protected void btnProceder_Click(object sender, EventArgs e)
        {
            string opcion = ddlMetodoPago.SelectedValue;
            if (opcion.Equals("Easy Pay"))
            {
                Response.Redirect("PagarEasyPay.aspx"); //Hay que mandar el monto
            }
            else
            {
                Response.Redirect("PagarTarjeta.aspx"); //Hay que mandar el monto
            }
          
        }

        public DataTable ConvertListToDataTable(List<Carrito[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }

    }
}