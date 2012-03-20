using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.Servicios;
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

        private IGrupoServicio gruposervicio;

        private IAlumnosServicios alumnoservicio;


        public CondicionesCursoController(ICondicionesCursoServicio condicionesCursoServicio, IGrupoServicio gruposervicio, IAlumnosServicios alumnoservicio)
        {
            CondicionesCursoServicio = condicionesCursoServicio;
            this.gruposervicio = gruposervicio;
            this.alumnoservicio = alumnoservicio;
        }

        public ActionResult AgregarCondicionCurso(int idInstitucion)
        {
            ICondicionCursoVista model = CondicionesCursoServicio.GetForAlta(idInstitucion);

            model.IdInstitucion = idInstitucion;

            return View("Agregar", model);
        }

        public ActionResult ModificarCondicionCurso(int idCondicionCurso)
        {
            return View("Agregar", CondicionesCursoServicio.GetForModificacion(idCondicionCurso));
        }

        public ActionResult Eliminar(int idCondicionCurso)
        {
            ICondicionCursoVista vista = CondicionesCursoServicio.GetForModificacion(idCondicionCurso);

            vista.Curso.Enabled = false;

            vista.EstadoCurso.Enabled = false;

            vista.Modalidad.Enabled = false;

            vista.Nro_Resolucion = "";

            vista.Programa.Enabled = false;

            return View(vista);
        }

        public ActionResult VerCondicionCurso(int idCondicionCurso)
        {
            ICondicionCursoVista model = CondicionesCursoServicio.GetForModificacion(idCondicionCurso);

            model.ListaGrupos = gruposervicio.GetAllGrupoByCurso(idCondicionCurso).ListaGrupos;

            model.ListaAlumno = alumnoservicio.GetTodosByCondicionCurso(idCondicionCurso).ListaAlumno;

            model.IdCondicionCurso = idCondicionCurso;

            return View("Ver", model);
        }

        [HttpPost]
        public ActionResult GuardarCondicionCurso(CondicionCursoVista vista)
        {
            if (ModelState.IsValid)
            {
                if (CondicionesCursoServicio.GuardarCondicionCurso(vista))
                {
                    return RedirectToAction("Ver", "Instituciones", new { INST_ID = vista.IdInstitucion });
                }
                base.AddError(CondicionesCursoServicio.GetErrors());
                return View("Agregar", vista);
            }

            ICondicionCursoVista model = CondicionesCursoServicio.GetForAlta(vista.IdInstitucion);

            model.IdInstitucion = vista.IdInstitucion;

            return View("Agregar", model);
        }

        public ActionResult EliminarCondicionCurso(int idCondicionCurso, int IdInstitucion)
        {
            if (CondicionesCursoServicio.EliminarCondicionCurso(idCondicionCurso, "sss"))
            {
                base.AddError(CondicionesCursoServicio.GetErrors());
            }
            return RedirectToAction("Ver", "Instituciones", new { INST_ID = IdInstitucion });
        }

        [HttpPost]
        public ActionResult CambairEstadoCurso(CondicionCursoVista vista)
        {

            bool mret = CondicionesCursoServicio.CambiarEstadoCurso(vista.IdCondicionCurso, Convert.ToInt32(vista.EstadoCurso.Selected));

            return RedirectToAction("VerCondicionCurso", "CondicionesCurso", new { idCondicionCurso = vista.IdCondicionCurso });
        }


        public PartialViewResult BuscarCondicion(string institucion, string nivel, string curso, string programa,string ano)
        {
            return PartialView("_BuscadorCondicionCursoLista", CondicionesCursoServicio.BuscarCondiciones(institucion, nivel, curso,programa,ano).CondicionesCursos);
        }

    }
}
