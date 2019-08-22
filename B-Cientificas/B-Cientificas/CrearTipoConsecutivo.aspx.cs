﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class CrearTipoConsecutivo : System.Web.UI.Page
    {
        TipoConsecutivoLogica logica = new TipoConsecutivoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TipoConsecutivoLogica tipoConsecutivo = new TipoConsecutivoLogica();
                tipoConsecutivo.TipoConsecutivoID = Convert.ToInt32(txtID.Text);
                tipoConsecutivo.Nombre = txtNombre.Text;

                if (logica.InsertarTipoConsecutivo(tipoConsecutivo))
                {
                    lblMensaje.Text = "Tipo Consecutivo " + txtNombre.Text + " creado correctamente";
                }
            }

            UsuarioLogica usuarioactual = (UsuarioLogica)Session["usuario"];
            RolUsuarioLogica roles = new RolUsuarioLogica();
            if (roles.RolAdministrador(usuarioactual.Usuario_id) || roles.RolConsecutivos(usuarioactual.Usuario_id))
            {

            }
            else
            {
                Response.Write("<script>alert('No cuenta con los permisos necesarios');</script>");
                Response.Redirect("Default.aspx");
            }
        }
    }
}