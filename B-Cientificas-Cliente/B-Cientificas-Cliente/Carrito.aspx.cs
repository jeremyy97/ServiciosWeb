using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
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
            if (!IsPostBack)
            {
                GenerarCaptcha();
            }
            DataColumn column;
            column = new DataColumn("Codigo", Type.GetType("System.String"));
            dt.Columns.Add(column);
            column = new DataColumn("Proyecto", Type.GetType("System.String"));
            dt.Columns.Add(column);
            column = new DataColumn("Precio", Type.GetType("System.String"));
            dt.Columns.Add(column);
            cargarCarrito();
            if (gvCarrito.Rows.Count <= 0)
            {
                lblmonto.Text = "No hay productos en el carrito";
                btnProceder.Enabled = false;
            }
            else
            {
                btnProceder.Enabled = true;
            }
        }

        private void GenerarCaptcha()
        {
            int longitud = 7;
            const string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder token = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int indice = rnd.Next(alfabeto.Length);
                token.Append(alfabeto[indice]);
            }

            lblCaptcha.Text = token.ToString();
        }


        public void cargarCarrito()
        {
            decimal monto = 0;
            foreach (var item in BLL.Carrito.carritoLista)
            {
                string[] items = { item.proyecto_id, item.nombre, item.precio };
                monto = monto + Convert.ToDecimal(item.precio);
                dt.Rows.Add(items);
            }
            gvCarrito.DataSource = dt;
            gvCarrito.DataBind();
            Session["montoFinal"] = monto;
            lblmonto.Text = monto.ToString();
        }
        protected void btnProceder_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string opcion = ddlMetodoPago.SelectedValue;

                if (lblCaptcha.Text.Equals(txtCaptcha.Text))
                {
                    if (opcion.Equals("Easy Pay"))
                    {
                        Response.Redirect("PagarEasyPay.aspx"); //Hay que mandar el monto
                    }
                    else
                    {
                        Response.Redirect("PagarTarjeta.aspx"); //Hay que mandar el monto
                    }

                }
                else
                {
                    Response.Write("<script>alert('Captcha Incorrecto');</script>");
                    GenerarCaptcha();
                }
            }
              
        }

        
        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            try
            {
                GridViewRow row = gvCarrito.Rows[index];
                BLL.Carrito.carritoLista.RemoveAt(index);
                Response.Write("<script>alert('Proyecto eliminado del carrito');</script>");
            }
            catch (Exception v)
            {
                Response.Write("<script>alert('Error al remover proyecto del carrito');</script>");
            }
            Response.Clear();
            gvCarrito.DeleteRow(index);
            Response.Redirect("Carrito.aspx");
        }

        protected void gvCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}