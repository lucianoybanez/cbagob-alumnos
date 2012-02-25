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
            IAlumnosVista model = new AlumnosVista();

            model.ListaAlumno = alumnosservicios.GetTodos();

            return View(model);
        }

        public ActionResult Agregar()
        {
            IAlumnosVista model = new AlumnosVista();

            model.ListaPersona = personaservicio.GetTodas();

            var comboSexo = new List<IComboItem>();
            comboSexo.Add(new ComboItem() { description = "Masculino", id = 1 });
            comboSexo.Add(new ComboItem() { description = "Femenino", id = 2 });
            model.Sexo.Combo = comboSexo;

            var comboTipoDocumento = new List<IComboItem>();
            comboTipoDocumento.Add(new ComboItem() { description = "Dni", id = 1 });
            comboTipoDocumento.Add(new ComboItem() { description = "Libreta", id = 2 });
            model.TipoDocumento.Combo = comboTipoDocumento;


            var comboEstadoCivil = new List<IComboItem>();
            comboEstadoCivil.Add(new ComboItem() { description = "Soltero", id = 1 });
            comboEstadoCivil.Add(new ComboItem() { description = "Casado", id = 2 });
            model.EstadoCivil.Combo = comboEstadoCivil;

            return View(model);
        }

        public ActionResult Modificar(Int32 id_alumno)
        {
            IAlumnos alumno = alumnosservicios.GetUno(id_alumno);

            IPersona persona = personaservicio.GetUno(alumno.Id_Persona);

            IAlumnosVista model = new AlumnosVista();

            model.ListaPersona = personaservicio.GetTodas();

            model.Id_Alumno = alumno.Id_Alumno;

            model.Cuil = persona.Cuil;

            model.Fecha_Nacimiento = persona.Fecha_Nacimiento;

            model.Nov_Nombre = persona.Nov_Nombre;

            model.Nov_Apellido = persona.Nov_Apellido;

            model.Nro_Documento = persona.Nro_Documento;

             var comboSexo = new List<IComboItem>();
            comboSexo.Add(new ComboItem() { description = "Masculino", id = 1 });
            comboSexo.Add(new ComboItem() { description = "Femenino", id = 2 });
            model.Sexo.Combo = comboSexo;
            model.Sexo.Selected = persona.Id_Sexo.ToString(); 


            var comboTipoDocumento = new List<IComboItem>();
            comboTipoDocumento.Add(new ComboItem() { description = "Dni", id = 1 });
            comboTipoDocumento.Add(new ComboItem() { description = "Libreta", id = 2 });
            model.TipoDocumento.Combo = comboTipoDocumento;
            model.TipoDocumento.Selected = persona.Id_Tipo_Documento.ToString();

            var comboEstadoCivil = new List<IComboItem>();
            comboEstadoCivil.Add(new ComboItem() { description = "Soltero", id = 1 });
            comboEstadoCivil.Add(new ComboItem() { description = "Casado", id = 2 });
            model.EstadoCivil.Combo = comboEstadoCivil;
            model.EstadoCivil.Selected = persona.Id_Estado_Civil.ToString(); 


            model.Id_Persona = alumno.Id_Persona;



            return View("Modificar", model);
        }

        public ActionResult Eliminar(Int32 id_alumno)
        {
            IAlumnos alumno = alumnosservicios.GetUno(id_alumno);

            IPersona persona = personaservicio.GetUno(alumno.Id_Persona);

            IAlumnosVista model = new AlumnosVista();

            model.ListaPersona = personaservicio.GetTodas();

            model.Id_Alumno = alumno.Id_Alumno;

            model.Cuil = persona.Cuil;

            model.Fecha_Nacimiento = persona.Fecha_Nacimiento;

            model.Nov_Nombre = persona.Nov_Nombre;

            model.Nov_Apellido = persona.Nov_Apellido;

            model.Nro_Documento = persona.Nro_Documento;

            var comboSexo = new List<IComboItem>();
            comboSexo.Add(new ComboItem() { description = "Masculino", id = 1 });
            comboSexo.Add(new ComboItem() { description = "Femenino", id = 2 });
            model.Sexo.Combo = comboSexo;
            model.Sexo.Selected = persona.Id_Sexo.ToString();


            var comboTipoDocumento = new List<IComboItem>();
            comboTipoDocumento.Add(new ComboItem() { description = "Dni", id = 1 });
            comboTipoDocumento.Add(new ComboItem() { description = "Libreta", id = 2 });
            model.TipoDocumento.Combo = comboTipoDocumento;
            model.TipoDocumento.Selected = persona.Id_Tipo_Documento.ToString();

            var comboEstadoCivil = new List<IComboItem>();
            comboEstadoCivil.Add(new ComboItem() { description = "Soltero", id = 1 });
            comboEstadoCivil.Add(new ComboItem() { description = "Casado", id = 2 });
            model.EstadoCivil.Combo = comboEstadoCivil;
            model.EstadoCivil.Selected = persona.Id_Estado_Civil.ToString();


            model.Id_Persona = alumno.Id_Persona;



            return View("Eliminar", model);
        }

        [HttpPost]
        public ActionResult Agregar_Alumno(AlumnosVista model)
        {
            IAlumnos alumno = new Alumno();

            alumno.Id_Persona = model.Id_Persona;

            bool mret = alumnosservicios.Agregar(alumno);

            model.ListaAlumno = alumnosservicios.GetTodos();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Modificar_Alumno(AlumnosVista model)
        {
            IAlumnos alumno = new Alumno();

            alumno.Id_Persona = model.Id_Persona;
            alumno.Id_Alumno = model.Id_Alumno;

            bool mret = alumnosservicios.Modificar(alumno);

            model.ListaAlumno = alumnosservicios.GetTodos();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Eliminar_Alumno(AlumnosVista model)
        {
           
            bool mret = alumnosservicios.Eliminar(model.Id_Alumno);

            model.ListaAlumno = alumnosservicios.GetTodos();

            return View("Index", model);
        }

        
    }
}
