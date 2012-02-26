using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class ExamenesController : Controller
    {
        private IExamenServicio ExamenServicio;

        private IAlumnosServicios AlumnosServicios;

        public ExamenesController(IExamenServicio examenServicio, IAlumnosServicios alumnosServicios)
        {
            ExamenServicio = examenServicio;
            AlumnosServicios = alumnosServicios;
        }

        public ActionResult Index()
        {
            return View(ExamenServicio.GetExamanes());
        }

        public ActionResult Agregar()
        {
            return View(ExamenServicio.GetExamenVista());
        }

        public ActionResult BuscarAlumno(string term)
        {
            var alumnos = AlumnosServicios.GetTodos()
                          .Where(c => c.Nov_Nombre.ToLower().Contains(term.ToLower()))
                          .Take(10).Select(c => new {label = c.Nov_Nombre});
            return Json(alumnos, JsonRequestBehavior.AllowGet);

        }

    }
}
