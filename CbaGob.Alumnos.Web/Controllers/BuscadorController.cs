﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;


namespace CbaGob.Alumnos.Web.Controllers
{
    public class BuscadorController : Controller
    {
        private IPersonaServicio personaservicio;
        private IEquipoServicio equiposervicio;
        private ISupervisoresServicio supervisoresservicio;
        private IInstitucionServicio institucionservicio;
        private IEstablecimientoServicio establecimientoservicio;


        public BuscadorController(IPersonaServicio personaservicio, IEquipoServicio equiposervicio, ISupervisoresServicio supervisoresservicio, IInstitucionServicio institucionservicio, IEstablecimientoServicio establecimientoservicio)
        {
            this.personaservicio = personaservicio;
            this.equiposervicio = equiposervicio;
            this.supervisoresservicio = supervisoresservicio;
            this.institucionservicio = institucionservicio;
            this.establecimientoservicio = establecimientoservicio;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Personas(string busqueda, string IdRelacionado)
        {
            IList<IPersona> lista = personaservicio.GetTodas();

            return Json(lista.ToArray());
        }

        [HttpPost]
        public ActionResult Equipos(string busqueda, string IdRelacionado)
        {
            IList<IEquipo> lista = equiposervicio.GetEquipos().ListaEquipos.Where(c => c.N_Equipos.StartsWith(busqueda) && c.Id_Estado_Equipo != 2).ToList();

            return Json(lista.ToArray());
        }

        [HttpPost]
        public ActionResult PersonasJuridica(string busqueda, string IdRelacionado)
        {
            IPersonaJuridicaServicio personajuridicaServicio = new PersonaJuridicaServicio();
            IList<IPersonaJuridica> lista = personajuridicaServicio.GetTodasByRazonSocial(busqueda);

            return Json(lista.ToArray());
        }

        [HttpPost]
        public ActionResult Supervisores(string busqueda, string IdRelacionado)
        {

            IList<ISupervisores> lista = supervisoresservicio.GetSupervisoresByRazonSocial(busqueda).ListaSupervisores;

            return Json(lista.ToArray());
        }

        [HttpPost]
        public ActionResult Domicilios(string busqueda, string IdRelacionado)
        {
            IDomiciliosServicios domiciliosservicios = new DomiciliosServicios();
            IList<IDomicilios> lista = domiciliosservicios.GetTodosDomicilios();

            lista = lista.Where(c => (c.Barrio.ToLower().Contains(busqueda.ToLower()) || c.Calle.ToLower().Contains(busqueda.ToLower()) || c.Localidad.ToLower().Contains(busqueda.ToLower()) || c.Nro.ToLower().Contains(busqueda.ToLower()) || c.Provincia.ToLower().Contains(busqueda.ToLower()))).ToList();

            return Json(lista.ToArray());
        }


        [HttpPost]
        public ActionResult Instituciones(string busqueda, string IdRelacionado)
        {

            IList<IInstitucion> lista = institucionservicio.GetTodas();

            lista = lista.Where(c => (c.Nombre_Institucion.ToLower().Contains(busqueda.ToLower()))).ToList();

            return Json(lista.ToArray());
        }


        [HttpPost]
        public ActionResult Estableciminetos(string busqueda, string IdRelacionado)
        {

            IList<IEstablecimiento> lista = establecimientoservicio.GetAllEstableciminetoByInstitucion(Convert.ToInt32(IdRelacionado)).ListaEstablecimiento;

            lista = lista.Where(c => (c.NombreEstablecimiento.ToLower().Contains(busqueda.ToLower()))).ToList();

            return Json(lista.ToArray());
        }

    }
}
