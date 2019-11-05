using MixingWebFormsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForm.Controllers;

namespace MixingWebFormsMVC.Controllers
{
    [Route("api/[controller]")]
    public class ProgrammerController : RazorController
    {
        // GET: Programmer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Projects() 
        {
            

            List<Requerimiento> requerimientos = new List<Requerimiento>() { 
                new Requerimiento.Builder().ConNombreRequerimiento("Banpa").Build(),
                 new Requerimiento.Builder().ConNombreRequerimiento("Derca").Build()
            };

            return RazorView(requerimientos); 
        }


        // GET: Programmer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Programmer/Create
        public ActionResult Create()
        {
            return View();
        }

      
    }
}
