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
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class SupervicionesController : BaseController
    {
        //
        // GET: /Superviciones/
        private ISupervicionesServicio supervicionesservicio;
        private IInstitucionServicio institucionservicio;
        private ICondicionesCursoServicio condicionescursoservicio;
        private IGrupoServicio gruposservicio;


        public SupervicionesController(ISupervicionesServicio supervicionesservicio, IInstitucionServicio institucionservicio, ICondicionesCursoServicio condicionescursoservicio, IGrupoServicio gruposservicio)
        {
            this.supervicionesservicio = supervicionesservicio;
            this.institucionservicio = institucionservicio;
            this.condicionescursoservicio = condicionescursoservicio;
            this.gruposservicio = gruposservicio;
        }

        public ActionResult Index()
        {

            return View(supervicionesservicio.GetSuperviciones());
        }

        public ActionResult Agregar()
        {
            ISupervicionVista model = new SupervicionVista();

            model.Institucions = institucionservicio.GetInstitucionesForSuperviciones();

            return View(model);
        }

        public ActionResult VerCursos(int IdInstitucion)
        {
            ISupervicionVista model = new SupervicionVista();

            model.Cursos = condicionescursoservicio.GetByInstitucionId(IdInstitucion);

            model.Institucions = institucionservicio.GetInstitucionesForSuperviciones();

            return View("Agregar", model);
        }

        public ActionResult VerGrupos(int idCondicionCurso, int IdInstitucion)
        {
            ISupervicionVista model = new SupervicionVista();

            model.Cursos = condicionescursoservicio.GetByInstitucionId(IdInstitucion);

            model.Grupos = gruposservicio.GetAllGrupoByCurso(idCondicionCurso);

            model.Institucions = institucionservicio.GetInstitucionesForSuperviciones();

            return View("Agregar", model);
        }

        public ActionResult RealizarSupervicionGrupo(int id_grupo)
        {
            ISupervicionVista model = new SupervicionVista();

            model.Grupo = gruposservicio.GetGrupo(id_grupo);

            model.Fec_Supervision = System.DateTime.Now;

            model.supervisor.Name = "BuSupervsores";
            model.supervisor.Tipo = "Supervisores";

            return View("Agregar_2Paso", model);
        }

        public ActionResult Agregar_Supervicion(SupervicionVista model)
        {
            model.Hs_Supervision = model.hora.ToString() + ":" + model.minuto.ToString();

            bool mreturn = supervicionesservicio.AgregarSuperviciones(model);

            return View("Index", supervicionesservicio.GetSuperviciones());
        }

        public ActionResult Modificar(int id_supervisor)
        {
            ISupervicionVista model = new SupervicionVista();

            model = supervicionesservicio.GetSupervicion(id_supervisor);
            model.Grupo = gruposservicio.GetGrupo(model.Id_Grupo);
            model.supervisor.Name = "BuSupervsores";
            model.supervisor.Tipo = "Supervisores";
            model.supervisor.Valor = model.NombrePersonaJuridica;


            return View(model);
        }

        public ActionResult Modificar_Supervicion(SupervicionVista model)
        {
            model.Hs_Supervision = model.hora.ToString() + ":" + model.minuto.ToString();

            bool mreturn = supervicionesservicio.ModificarSuperviciones(model);

            return View("Index", supervicionesservicio.GetSuperviciones());
        }

        public ActionResult Eliminar(int id_supervisor)
        {
            ISupervicionVista model = new SupervicionVista();

            model = supervicionesservicio.GetSupervicion(id_supervisor);
            model.Grupo = gruposservicio.GetGrupo(model.Id_Grupo);
            model.supervisor.Name = "BuSupervsores";
            model.supervisor.Tipo = "Supervisores";
            model.supervisor.Valor = model.NombrePersonaJuridica;
            model.Nro_resolucion = "";

            return View(model);
        }

        public ActionResult Eliminar_Supervicion(SupervicionVista model)
        {

            bool mreturn = supervicionesservicio.EliminarSuperviciones(model.Id_Supervision, model.Nro_resolucion);

            return View("Index", supervicionesservicio.GetSuperviciones());
        }

        public ActionResult IndexPager(Pager pager)
        {
            return View("Index", supervicionesservicio.GetSuperviciones(pager));
        }

        public ActionResult IndexPagerSup(Pager pager)
        {
            ISupervicionVista model = new SupervicionVista();

            model.Institucions = institucionservicio.GetInstitucionesForSuperviciones(pager);

            return View("Agregar", model);
        }

    }
}
