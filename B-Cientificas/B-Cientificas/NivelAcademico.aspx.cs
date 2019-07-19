using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B_Cientificas
{
    public partial class NivelAcademico : System.Web.UI.Page
    {
        NivelAcademicoLogica logica = new NivelAcademicoLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvNivelAcademico.DataSource = logica.CargarNivelesAcademicos().Tables[0];
            gvNivelAcademico.DataBind();
        }
    }
}