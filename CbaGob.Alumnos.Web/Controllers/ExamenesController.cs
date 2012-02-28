using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class ExamenesController : BaseController
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

        public ActionResult Eliminar(int IdExamen)
        {
            if (!ExamenServicio.EliminarExamen(IdExamen))
            {
                base.AddError(ExamenServicio.GetErrors());
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdExamen)
        {
            return View("Agregar",ExamenServicio.GetExamenVista(IdExamen));
        }

        public ActionResult CambiarCombo(ExamenVista vista)
        {
            return View("Agregar", ExamenServicio.GetExamenVistaCambioComboGrupo(vista));
        }

        public ActionResult GuardarExamen(ExamenVista vista)
        {
            bool result = ExamenServicio.GuardarExamen(vista);
            if (!result)
            {
                base.AddError(ExamenServicio.GetErrors());
                return View("Agregar", CambiarCombo(vista));
            }
            return RedirectToAction("Index");
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
