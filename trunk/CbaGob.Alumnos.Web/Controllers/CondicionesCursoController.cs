﻿using System;
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

        public CondicionesCursoController(ICondicionesCursoServicio condicionesCursoServicio)
        {
            CondicionesCursoServicio = condicionesCursoServicio;
        }

        public ActionResult AgregarCondicionCurso(int idInstitucion)
        {
            return View("Agregar", CondicionesCursoServicio.GetForAlta(idInstitucion));
        }

        public ActionResult ModificarCondicionCurso(int idCondicionCurso)
        {
            return View("Agregar", CondicionesCursoServicio.GetForModificacion(idCondicionCurso));
        }

        public ActionResult VerCondicionCurso(int idCondicionCurso)
        {
            IGrupoServicio gruposervicio = new GrupoServicio();

            IAlumnosServicios alumnoservicio = new AlumnosServicios();

            ICondicionCursoVista model = CondicionesCursoServicio.GetForModificacion(idCondicionCurso);

            model.ListaGrupos = gruposervicio.GetAllGrupoByCurso(idCondicionCurso).ListaGrupos;

            model.ListaAlumno = alumnoservicio.GetTodosByCondicionCurso(idCondicionCurso);

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
            return View("Agregar", vista);
        }

        public ActionResult EliminarCondicionCurso(int idCondicionCurso, int IdInstitucion)
        {
            if (CondicionesCursoServicio.EliminarCondicionCurso(idCondicionCurso))
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
        

    }
}