using Backend.Infrastructura;
using Backend.Infrastructura.ProcedimientosAlmacenados;
using Core.Entities;
using ServiciosAplicacion.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.ProgramerPages
{
    public partial class ProgrammerPanel : System.Web.UI.Page
    {

        public ProgrammerPanel()
        {

        }

        IGlobalServices services;

        IStoredProcedureRepository procedures;
        public ProgrammerPanel(IGlobalServices service,IStoredProcedureRepository stored)
        {
            services = service;
            procedures = stored;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios us = new Usuarios();
            if (!Page.IsPostBack)
            {
               
                
            }

            int id = int.Parse(Request.QueryString["id"]);

            us = new UnitOfWork().Programadores.GetById(id);
            userLogout.NavigateUrl = "~/Login.aspx";
            userLogout.CssClass = "text-white";
            userLogout.Text = $"<i class='fas fa-arrow-left'></i> {us.NombreUsuario}";




            idProgramador.Text = us.idUsuario + "";
            NombreProgramador.Text = us.NombreUsuario;
            ProyectosEnEquipo.DataSource = procedures.userStoredProcedures.GetDataSetConStoredProcedure(us.idUsuario);
            ProyectosEnEquipo.DataBind();
        }

        public void BindData()
        {
           

            /*
            ProyectosIndividuales.DataSource = ;
            */
        }

        protected void boton_Click(object sender, EventArgs e)
        {
            

            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "showPopup()", true);
       }

        protected void ProyectosEnEquipo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string ruta = ProyectosEnEquipo.SelectedRow.Cells[3].Text;
            Cache["Ruta"] = ruta;
            Response.Redirect($"~/ProgramerPages/PdfViewer.aspx");

        }

        protected void ProyectosEnEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            string ideRequerimiento = ProyectosEnEquipo.SelectedRow.Cells[1].Text;
            string ruta = ProyectosEnEquipo.SelectedRow.Cells[3].Text;
            Cache["name"] = ProyectosEnEquipo.SelectedRow.Cells[2].Text;
            Cache["Ruta"] = ruta;
            Response.Redirect($"~/ProgramerPages/GestorProyectos.aspx?id={ideRequerimiento}");

        }
    }
}
