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

    }
}
