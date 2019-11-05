using Models;
using System;
using System.Web.Mvc;

namespace WebForm.Controllers
{
  public class RazorDemoController : RazorController
  {
    public ActionResult Index()
    {
      return RazorView();
    }


    // Example render some other view
    public ActionResult RenderOtherView()
    {
      return RazorView("Hello");
    }

    // Example Render view with Model
    public ActionResult Customer(Int32 id)
    {
      var model = new Customer()
      {
        Id = id,
        Name = "Company ABC",
        City = "The One that never sleeps"
      };

      return RazorView(model);
    }

    [HttpGet]
    public ActionResult SomeAjaxCall(Int32 id)
    {
      var model = new Customer()
      {
        Id = id,
        Name = "Company ABC",
        City = "The One that never sleeps"
      };

      return View("Customer", model);
    }
  }
}