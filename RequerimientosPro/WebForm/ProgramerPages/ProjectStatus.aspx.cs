using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Frontend.ProgramerPages
{
    public partial class ProjectStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            inicioAnalisisDatetimePicker.Text = data;

            InitComponents();
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


        protected void SeguirButton_Click(object sender, EventArgs e)
        {
            ShowViewComponent(DercasProcess, show: true);
            SeguirButton.Enabled = false;
            ShowControl(SeguirButton, show: false);
            SetTextToControl(FechaEntregaDatetimePicker, DateTime.Now.ToString("yyyy-MM-dd"));
        }


    }
}