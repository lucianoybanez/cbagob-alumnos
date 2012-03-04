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
    public class PersonasController : Controller
    {
        //
        // GET: /Personas/

        private IAlumnosServicios alumnosservicio;
        private IPersonaServicio personaservice;


        public PersonasController()
        {
            alumnosservicio = new AlumnosServicios();
            personaservice = new PersonaServicio();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar()
        {
            IAlumnosVista model = new AlumnosVista();

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

        [HttpPost]
        public ActionResult Agregar_Persona(AlumnosVista model)
        {
            IPersona persona = new Persona();
            persona.Nro_Documento = model.Nro_Documento;
            persona.Cuil = model.Cuil;
            persona.Nov_Apellido = model.Nov_Apellido;
            persona.Nov_Nombre = model.Nov_Nombre;
            persona.Id_Estado_Civil = model.EstadoCivil.Selected.ToString();
            persona.Id_Sexo = model.Sexo.Selected.ToString();
            persona.Id_Tipo_Documento = model.TipoDocumento.Selected.ToString();

            bool mret = personaservice.AgregarPersona(persona);

            return RedirectToAction("Agregar", "Alumnos");
        }

    }
}
