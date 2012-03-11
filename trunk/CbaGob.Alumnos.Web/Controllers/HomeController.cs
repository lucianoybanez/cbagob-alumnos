using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CbaGob.Alumnos.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            
            return View();
        }

        public ActionResult About()
        {
            throw new Exception("Ooops Error");
            return View();
        }

        public ActionResult Error()
        {
            return View("Error");
        }


        public ActionResult AccesoDenegado(string error)
        {
            ViewBag.Error = error;
            return View("AccesoDenegado");
        }

    }
}
