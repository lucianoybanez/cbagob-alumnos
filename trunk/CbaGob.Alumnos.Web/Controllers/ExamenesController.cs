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

        public ActionResult Agregar(int IdInscripcion)
        {
            var vista = ExamenServicio.GetExamenVistaByInscripcion(IdInscripcion);
            vista.Accion = "Agregar";
            return View(vista);
        }

        public ActionResult Eliminar(int IdExamen)
        {
            var vista = ExamenServicio.GetExamenVista(IdExamen);
            vista.NroExamen.Enabled = false;
            vista.Accion = "Eliminar";
            return View("Agregar", vista);
        }

        public ActionResult Modificar(int IdExamen)
        {
            var vista = ExamenServicio.GetExamenVista(IdExamen);
            vista.Accion = "Modificar";
            return View("Agregar",vista);
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
                return View("Agregar", ExamenServicio.GetOnlyCombo(vista));
            }
            return RedirectToAction("Ver", "Inscripciones", new { idInscripcion = vista.idInscripcion});
        }


        public ActionResult EliminarExamen(ExamenVista vista)
        {
            bool result = ExamenServicio.EliminarExamen(vista.IdExamen);
            if (!result)
            {
                base.AddError(ExamenServicio.GetErrors());
                return View("Agregar", ExamenServicio.GetOnlyCombo(vista));
            }
            return RedirectToAction("Ver", "Inscripciones", new { idInscripcion = vista.idInscripcion });
        }
      

        public ActionResult BuscarAlumno(string term)
        {
            var alumnos = AlumnosServicios.GetTodos().ListaAlumno
                          .Where(c => c.Nombre.ToLower().Contains(term.ToLower()))
                          .Take(10).Select(c => new { label = c.Nombre });
            return Json(alumnos, JsonRequestBehavior.AllowGet);

        }

    }
}
