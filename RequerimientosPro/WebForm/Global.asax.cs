using Backend.Infrastructura;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
namespace WebForm
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = this.AddUnity();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
           
        }
    }
}