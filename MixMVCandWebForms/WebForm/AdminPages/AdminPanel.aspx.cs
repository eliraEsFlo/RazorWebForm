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
        string userLoggedIcon = "<i class='fas fa-sign-out-alt '></i>";
        string userLogged = "Jorge Cano";
        protected void Page_Load(object sender, EventArgs e)
        {
           /* HyperLink userIconOnMaster = (HyperLink)Master.FindControl("UserLoggedText");
            if (userIconOnMaster != null)
                userIconOnMaster.Text = $"{userLoggedIcon} {userLogged}";
                */


            CheckBoxList1.DataSource = new List<string> { "Permiso", "asldkjfkj", "asdf", "d", "sddd", "ee", "d", "dfd", "sddd",
                "ee", "d", "dfd", "sddd", "ee", "d", "dfd", "ee", "d", "dfd", "sddd", "ee", "d", "dfd" };
            CheckBoxList1.DataBind();

            CheckBoxList2.DataSource = new List<string> { "Permiso", "asldkjfkj", "asdf", "d", "sddd", "ee", "d", "dfd",
                "sddd", "ee", "d", "dfd", "sddd", "ee", "d", "dfd", "ee", "d", "dfd", "sddd", "ee", "d", "dfd" };
            CheckBoxList2.DataBind();


        }
    }
}