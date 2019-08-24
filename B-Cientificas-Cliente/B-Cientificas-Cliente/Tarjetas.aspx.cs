using System;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas_Cliente
{
    public partial class Tarjetas : System.Web.UI.Page
    {

        #region Var

        TarjetasLogica logica = new TarjetasLogica();

        #endregion

        #region Methods

        private void CargarTarjetas()
        {
            gvTarjetas.DataSource = logica.CargarTarjetasXCliente("1");
            gvTarjetas.DataBind();
            btnActualizar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void Limpiar()
        {
            txtAnno.Text = "";
            txtId.Text = "";
            txtCVV.Text = "";
            txtMes.Text = "";
            txtNombre.Text = "";
            txtNumeroTarjeta.Text = "";
            btnActualizar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void Actualizar()
        {
            if (Page.IsValid)
            {
                TarjetasLogica tarjeta = new TarjetasLogica();
                TarjetasLogica tarjetaOld = new TarjetasLogica();
                tarjetaOld = logica.CargarTarjeta(Convert.ToInt32(txtId.Text));

                tarjeta.NumeroTarjeta = txtNumeroTarjeta.Text;
                tarjeta.NombreTarjeta = txtNombre.Text;
                tarjeta.MesVencimiento = txtMes.Text;
                tarjeta.AnnoVencimiento = txtAnno.Text;
                tarjeta.CVV = txtCVV.Text;
                tarjeta.Limite = tarjetaOld.Limite;
                tarjeta.Saldo = tarjetaOld.Saldo;
                tarjeta.DebitoCredito = tarjetaOld.DebitoCredito;
                tarjeta.TipoTarjeta_Id = tarjetaOld.TipoTarjeta_Id;
                tarjeta.TarjetaCredito_id = tarjetaOld.TarjetaCredito_id;


                if (logica.ActualizarTarjeta(tarjeta))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarjeta Actualizada correctamente');</script>");
                    this.CargarTarjetas();
                    Limpiar();
                }
            }
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTarjetas();
        }

        protected void gvTarjetas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvTarjetas.Rows[index];
            int id = Convert.ToInt32(row.Cells[1].Text);


            TarjetasLogica tarjeta = new TarjetasLogica();
            tarjeta = logica.CargarTarjeta(id);

            txtNumeroTarjeta.Text = tarjeta.NumeroTarjeta;
            txtNombre.Text = tarjeta.NombreTarjeta;
            txtMes.Text = tarjeta.MesVencimiento;
            txtAnno.Text = tarjeta.AnnoVencimiento;
            txtCVV.Text = tarjeta.CVV;
            txtId.Text = tarjeta.TarjetaCredito_id.ToString();

            btnActualizar.Visible = true;
          
            btnEliminar.Visible = true;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        protected void btnNuevaTarjeta_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaTarjeta.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            TarjetaClienteLogica c = new TarjetaClienteLogica();
            c.EliminarTarjetaCliente(Convert.ToInt32(txtId.Text), "1"); //AGREGAR AQUI EL ID DEL USUARIO
            logica.EliminarTarjeta(Convert.ToInt32(txtId.Text));
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarjeta Elimanada correctamente');</script>");
            Limpiar();
            this.CargarTarjetas();
        }


        #endregion


    }
}