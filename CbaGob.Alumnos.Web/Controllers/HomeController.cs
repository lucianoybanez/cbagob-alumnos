using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IUsuarioServicio UsuarioServicio;

        public HomeController(IUsuarioServicio usuarioServicio)
        {
            UsuarioServicio = usuarioServicio;
        }

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

        public ContentResult IsAdminMode()
        {
            var user = UsuarioServicio.GetCookieData();
            if (user.Rol == RolTipo.Supervisor.ToString())
            {
                return Content("true"); 
            }
            return Content("false"); 
        }


    }
}
