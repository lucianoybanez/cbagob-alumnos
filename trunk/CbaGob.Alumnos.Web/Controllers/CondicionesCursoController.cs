using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class CondicionesCursoController : BaseController
    {
        private ICondicionesCursoServicio CondicionesCursoServicio;

        public CondicionesCursoController(ICondicionesCursoServicio condicionesCursoServicio)
        {
            CondicionesCursoServicio = condicionesCursoServicio;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarCondicionCurso(int idInstitucion)
        {
            return View("Agregar", CondicionesCursoServicio.GetForAlta(idInstitucion));
        }

        public ActionResult ModificarCondicionCurso(int idCondicionCurso)
        {
            return View("Agregar", CondicionesCursoServicio.GetForModificacion(idCondicionCurso));
        }

        [HttpPost]
        public ActionResult GuardarCondicionCurso(CondicionCursoVista vista)
        {
            CondicionesCursoServicio.GuardarCondicionCurso(vista);
            return RedirectToAction("CursosAsignados", "Instituciones", new {IdInstitucion = vista.IdInstitucion});
        }

        public ActionResult EliminarCondicionCurso(int idCondicionCurso, int IdInstitucion)
        {
            CondicionesCursoServicio.EliminarCondicionCurso(idCondicionCurso);
            return RedirectToAction("CursosAsignados", "Instituciones", new { IdInstitucion = IdInstitucion });
        }

    }
}
