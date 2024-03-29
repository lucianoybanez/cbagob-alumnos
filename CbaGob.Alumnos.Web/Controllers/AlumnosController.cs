﻿using System;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Web.Controllers
{

    public class AlumnosController : Controller
    {
        //
        // GET: /Alumnos/
        private IAlumnosServicios alumnosservicios;
        private IPersonaServicio personaservicio;


        public AlumnosController(IAlumnosServicios alumnosservicios, IPersonaServicio personaservicio)
        {
            this.alumnosservicios = alumnosservicios;
            this.personaservicio = personaservicio;
        }

        public ActionResult Index()
        {
            return View(alumnosservicios.GetTodos());
        }
        
        public ActionResult Agregar()
        {

            return View(alumnosservicios.GetIndex());
        }
        
        public ActionResult Modificar(Int32 id_alumno)
        {

            IAlumnosVista model = alumnosservicios.GetUno(id_alumno);

            return View(model);
        }
        
        public ActionResult Eliminar(Int32 id_alumno)
        {
            IAlumnosVista model = alumnosservicios.GetUno(id_alumno);

            model.Sexo.Enabled = false;

            model.TipoDocumento.Enabled = false;

            model.EstadoCivil.Enabled = false;

            model.Nro_Resolucion = "";

            return View(model);
        }

        public ActionResult Consultar(Int32 id_alumno)
        {
            IAlumnosVista model = alumnosservicios.GetUno(id_alumno);

            model.Sexo.Enabled = false;

            model.TipoDocumento.Enabled = false;

            model.EstadoCivil.Enabled = false;

            return View(model);
        }

        
        [HttpPost]
        public ActionResult Agregar_Alumno(AlumnosVista model)
        {

            bool mret = alumnosservicios.Agregar(model);

            return View("Index", alumnosservicios.GetTodos());
        }

        
        [HttpPost]
        public ActionResult Modificar_Alumno(AlumnosVista model)
        {
            bool mret = alumnosservicios.Modificar(model);

            return View("Index", alumnosservicios.GetTodos());
        }

        [HttpPost]
        public ActionResult Eliminar_Alumno(AlumnosVista model)
        {

            bool mret = alumnosservicios.Eliminar(model.Id_Alumno, model.Nro_Resolucion);

            return View("Index", alumnosservicios.GetTodos());
        }


        public ActionResult BuscarAlumno(string nombre, string apellido, string dni)
        {
            if (!string.IsNullOrEmpty(dni))
            {
                return PartialView("_BuscadorAlumnoLista", alumnosservicios.GetTodosByDni(dni).ListaAlumno);
            }
            return PartialView("_BuscadorAlumnoLista", alumnosservicios.GetTodosByNombreApellido(nombre, apellido).ListaAlumno);
        }

        [HttpPost]
        public ActionResult Agregar_Persona(AlumnosVista model)
        {

            bool mret = alumnosservicios.Agregar(model);

            return View("Index", alumnosservicios.GetTodos());
        }

        [HttpPost]
        public ActionResult BuscarAlumnos(AlumnosVista model)
        {
            return View("Index", alumnosservicios.BuscarAlumnos(model.NombreBusqueda, model.ApellidoBusqueda, model.DniBusqueda, model.CuilBusqueda));
        }

        public ActionResult IndexPager(Pager pager, string NombreBusqueda, string ApellidoBusqueda, string DniBusqueda)
        {
            if (NombreBusqueda == "" && ApellidoBusqueda == "" && DniBusqueda == "")
            { return View("Index", alumnosservicios.GetIndex(pager)); }
            else
            { return View("Index", alumnosservicios.BuscarAlumnos(NombreBusqueda, ApellidoBusqueda, DniBusqueda, "", pager)); }
        }
    }
}
