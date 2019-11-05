using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MixingWebFormsMVC.AdminPages
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        string iconAsignados = "<i class='fas fa-address-card'></i>";
        string iconAdd = "<i class='fas fa-plus'></i>";
        string iconTeam = "<i class='fas fa-users'></i>";
        string iconReport = "<i class='fas fa-print'></i>";

        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink agregarRequerimientoLink = (HyperLink)Master.FindControl("HyperLink1");
            agregarRequerimientoLink.Text = $"{iconAdd} Agregar requerimiento";
            
            agregarRequerimientoLink.NavigateUrl = "~/AdminPages/AgregarRequerimiento.aspx";

            HyperLink requerimientosAsignadosLink = (HyperLink)Master.FindControl("HyperLink2");


            requerimientosAsignadosLink.Text = $"{iconAsignados} Requerimientos asignados";

            HyperLink programadoresLink = (HyperLink)Master.FindControl("HyperLink3");
            programadoresLink.Text = $"{iconTeam} Programadores";

            HyperLink reporteLink = (HyperLink)Master.FindControl("HyperLink4");
            reporteLink.Text = $"{iconReport} Reportes";

        }
    }
}