using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class AlumnosController : Controller
    {
        //
        // GET: /Alumnos/
        private IAlumnosServicios alumnosservicios;
        private IPersonaServicio personaservicio;


        public AlumnosController()
        {
            alumnosservicios = new AlumnosServicios();
            personaservicio = new PersonaServicio();
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


        public PartialViewResult BuscarAlumno(string nombre, string apellido, string dni)
        {
            if (!string.IsNullOrEmpty(dni))
            {
                return PartialView("_BuscadorAlumnoLista", alumnosservicios.GetTodosByDni(dni));
            }
            return PartialView("_BuscadorAlumnoLista", alumnosservicios.GetTodosByNombreApellido(nombre, apellido));
        }


        [HttpPost]
        public ActionResult Agregar_Persona(AlumnosVista model)
        {

            bool mret = alumnosservicios.Agregar(model);

            return View("Index", alumnosservicios.GetTodos());
        }

    }
}
