using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class ProgramerPage : System.Web.UI.MasterPage
    {
        public string noNotifications { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            noNotifications = "2";
            Page.DataBind();

           
        }
    }
}