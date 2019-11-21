
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Frontend.ProgramerPages.ControlUtilities
{
    public  class ControlManager
    {

        public void GetControls(MasterPage masterpage)
        {
            Label control = (Label) masterpage.FindControl("Label1");
            control.Text = "Hola amigos";

            HyperLink hiperlink = (HyperLink)masterpage.FindControl("HyperLink1");
            hiperlink.Text = $"< i class='fas fa-tasks'></i>";
            
         }

        public void ShowViewComponent(HtmlGenericControl control, bool show)
        {
            control.Visible = show;
        }

        public void ShowControl(WebControl control, bool show)
        {
            control.Visible = show;
        }

        public void SetTextToControl(IEditableTextControl control, string text)
        {
            control.Text = text;
        }
    }
}