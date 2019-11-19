using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
  public partial class SiteMaster : System.Web.UI.MasterPage //System.Web.Mvc.ViewMasterPage
  {
     

    protected void Page_Load(Object sender, EventArgs e)
    {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
    }
  }
}