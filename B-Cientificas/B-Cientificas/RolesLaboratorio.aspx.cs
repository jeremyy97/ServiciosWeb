﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class RolesLaboratorio : System.Web.UI.Page
    {
        RolLaboratorioLogica logica = new RolLaboratorioLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            gvRolLaboratorio.DataSource = logica.CargasRolesLaboratorio().Tables[0];
            gvRolLaboratorio.DataBind();
        }

        protected void gvRolLaboratorio_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvRolLaboratorio.Rows[index];
            string id = row.Cells[index+1].Text;

            RolLaboratorioLogica rol = new RolLaboratorioLogica();
            rol = logica.BuscarRolLaboratorio(id);

            txtID.Text = rol.RolLaboratorio_id;
            txtNombre.Text = rol.Nombre;
            txtDetalle.Text = rol.Detalle;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtDetalle.Text = "";
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RolLaboratorioLogica rol = new RolLaboratorioLogica();
                rol.RolLaboratorio_id = txtID.Text;
                rol.Nombre = txtNombre.Text;
                rol.Detalle = txtDetalle.Text;

                if (logica.ActualizarRolLaboratorio(rol))
                {
                    lblMensaje.Text = "Rol Laboratorio  " + txtNombre.Text + " actualizado correctamente";
                    this.CargarRoles();
                }
            }
        }
    }
}