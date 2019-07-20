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
    public partial class BitacoraExperimental : System.Web.UI.Page
    {
        BitacoraExperimentalLogica logica = new BitacoraExperimentalLogica();
        ProyectosLogica proyectos = new ProyectosLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvExperimentos.DataSource = logica.CargarBitacora();
            gvExperimentos.DataBind();

            if (!IsPostBack)
            {
                foreach (DataRow dr in proyectos.CargarProyectos().Rows)
                {
                    ListItem item = new ListItem();
                    item.Value = dr[0].ToString();
                    item.Text = dr[1].ToString();
                    ddlProyectos.Items.Add(item);
                }
            }
            
            
        }

        protected void ddlProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlProyectos.SelectedValue != "-8")
            {
                txtCodProyecto.Text = ddlProyectos.SelectedValue;
                ConsecutivoLogica consecutivo = logica.GenerarID();
                if (consecutivo != null)
                {
                    txtCodExperimento.Text = consecutivo.Consecutivo;
                }
            }        
        }
    }
}