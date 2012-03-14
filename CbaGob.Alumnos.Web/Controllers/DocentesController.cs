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
    public class DocentesController : Controller
    {
        //
        // GET: /Docentes/

        private IDocentesServicio docentesservicio;


        public DocentesController(IDocentesServicio docentesservicio)
        {
            this.docentesservicio = docentesservicio;
        }

        public ActionResult Index()
        {
            return View(docentesservicio.GetTodos());
        }

        public ActionResult Agregar()
        {

            return View(docentesservicio.GetIndex());
        }

        public ActionResult Modificar(Int32 id_docente)
        {

            IDocentesVista model = new DocentesVista();

            model = docentesservicio.GetUno(id_docente);

            return View(model);
        }

        public ActionResult Eliminar(Int32 id_docente)
        {
            IDocentesVista model = new DocentesVista();

            model = docentesservicio.GetUno(id_docente);

            model.TiposDocentes.Enabled = false;

            model.cargos.Enabled = false;

            model.Nro_Resolucion = "";

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Docente(DocentesVista model)
        {

            bool mret = docentesservicio.Agregar(model);

            IDocentesVista vista = docentesservicio.GetIndex();

            return View("Index", vista);
        }

        [HttpPost]
        public ActionResult Modificar_Docente(DocentesVista model)
        {

            bool mret = docentesservicio.Modificar(model);

            return View("Index", docentesservicio.GetIndex());
        }

        [HttpPost]
        public ActionResult Eliminar_Docente(DocentesVista model)
        {

            bool mret = docentesservicio.Eliminar(model.Id_Docente, model.Nro_Resolucion);

            return View("Index", docentesservicio.GetIndex());
        }

        [HttpPost]
        public ActionResult BuscarDocente(DocentesVista model)
        {
            return View("Index", docentesservicio.BuscarDocente(model.RazonSocialBusqueda, model.CuilCuitBusqueda));
        }

        public ActionResult IndexPager(Pager pager)
        {
            return View("Index", docentesservicio.GetIndex(pager));
        }

    }
}
