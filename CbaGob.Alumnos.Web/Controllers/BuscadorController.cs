using System;
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
        //
        // GET: /Buscador/

        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Personas(string busqueda, string IdRelacionado)
        {
            IPersonaServicio personaservicio = new PersonaServicio();
            IList<IPersona> lista = personaservicio.GetTodas();

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
        public ActionResult Instituciones(string busqueda , string IdRelacionado)
        {
            IInstitucionServicio institucionservicio = new InstitucionServicio();
            IList<IInstitucion> lista = institucionservicio.GetTodas();

            lista = lista.Where(c => (c.Nombre_Institucion.ToLower().Contains(busqueda.ToLower()) || c.DireccionCompleta.ToLower().Contains(busqueda.ToLower()))).ToList();

            return Json(lista.ToArray());
        }

    }
}
