using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebForm.Controllers
{
  public class RazorController : Controller
  {
    public ActionResult RazorView(String viewName, Object model)
    {
      // pass the viewname to RazorView.aspx
      // the view will be rendered as partial view
      ViewBag.ViewName = viewName;

      return View("RazorView", model);
    }
    
    public ActionResult RazorView(Object model)
    {
      return RazorView(GetCurrentViewName(), model);
    }
    
    public ActionResult RazorView(String viewName)
    {
      return RazorView(viewName, null);
    }

    public ActionResult RazorView()
    {
      return RazorView(GetCurrentViewName(), null);
    }

    private String GetCurrentViewName()
    {
      var result = $"{Url.RequestContext.RouteData.Values["action"]}";

      return result;
    }
  }
}