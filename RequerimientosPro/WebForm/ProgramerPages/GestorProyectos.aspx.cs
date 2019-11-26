using Backend.Infrastructura;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Frontend.ProgramerPages
{
    public partial class GestorProyectos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string data = DateTime.Now.ToString("yyyy-MM-dd");
                inicioAnalisisDatetimePicker.Text = data;

                InitComponents();
            }

            string id = Request.QueryString["id"];

            idRequerimiento.Text = id;
            string nombre = Cache["name"] as string;
            NombreProyecto.Text = nombre;
 
            userLogout.NavigateUrl = "~/Login.aspx";
            userLogout.CssClass = "text-white";
            string name = Cache["Usuario"] as string;
            userLogout.Text = $"<i class='fas fa-arrow-left'></i> {name}";



        }

        protected void ShowViewComponent(HtmlGenericControl control, bool show)
        {
            control.Visible = show;
        }

        protected void ShowControl(WebControl control, bool show)
        {
            control.Visible = show;
        }

        public void SetTextToControl(IEditableTextControl control, string text)
        {
            control.Text = text;
        }

        public void InitComponents()
        {
            ShowViewComponent(DercasProcess, show: false);
            ShowViewComponent(DesarrolloProcess, show: false);
            ShowViewComponent(EntregaPUProcess, show: false);
            ShowViewComponent(ProduccionProcess, show: false);
        }


        protected void AvanzarToDercas(object sender, EventArgs e)
        {
            FechaEntregaDatetimePicker.Text = string.Format($"{DateTime.Now}");
            ShowViewComponent(DercasProcess, show: true);
            ShowControl(SeguirButton, show: false);

            SqlCommand cmd = new SqlCommand("usp_InsertarActividadPorProceso"
                ,SQLConfiguration.GetConnection());

            //cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //cmd.Parameters.Add("@idProcesoProyecto",System.Data.SqlDbType.Int).Value = 1;
            //cmd.Parameters.Add("@idInfoAdicional", System.Data.SqlDbType.Int).Value = DBNull.Value;
            //cmd.Parameters.Add("@fechaPromesa", System.Data.SqlDbType.DateTime).Value = FechaPromesaAnalisis.Text;
            //cmd.Parameters.Add("@fechaEntrega", System.Data.SqlDbType.DateTime).Value = FechaEntregaDatetimePicker.Text;
            //cmd.Parameters.Add("@estadoActividad", System.Data.SqlDbType.Bit);

            //cmd.ExecuteNonQuery();
            
        }

        protected void AvanzarToDesarrollo(object sender, EventArgs e)
        {
            ShowViewComponent(DesarrolloProcess, show: true);

            ShowControl(ValidarDercas, show: false);
           
        }

        protected void AvanzarToCertificacion(object sender, EventArgs e)
        {
            ShowViewComponent(EntregaPUProcess, show: true);
            ShowControl(ValidarDesarrollo, show: false);
        }

        protected void AvanzarAProduccion(object sender, EventArgs e)
        {
            ShowViewComponent(ProduccionProcess, show: true);

            ShowControl(ValidarEntregaPU, show: false);
           
            
        }

        protected void TerminarProyectoEvent(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void AsignarButton_Click(object sender, EventArgs e)
        {

            string ruta = Cache["Ruta"] as string;
            Response.Redirect($"~/ProgramerPages/PdfViewer.aspx?");
        }
    }
}