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
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    [ViewAuthorize(Rol = new RolTipo[] { RolTipo.Supervisor, RolTipo.ResponsableIFP })]
    public class SupervisoresController : BaseController
    {
        //
        // GET: /Supervisores/

        private ISupervisoresServicio supervisoresservicio;

        public SupervisoresController(ISupervisoresServicio supervisoresservicio)
        {
            this.supervisoresservicio = supervisoresservicio;
        }

        public ActionResult Index()
        {

            return View(supervisoresservicio.GetSupervisores());
        }

        public ActionResult Agregar()
        {
            ISupervisorVista model = new SupervisorVista();

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Supervisor(SupervisorVista model)
        {
            bool mret = supervisoresservicio.AgregarSupervisor(model);

            return View("Index", supervisoresservicio.GetSupervisores());
        }

        public ActionResult Modificar(int id_supervisor)
        {
            ISupervisorVista model = supervisoresservicio.GetSupervisor(id_supervisor);



            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar_Supervisor(SupervisorVista model)
        {
            bool mret = supervisoresservicio.ModificarSupervisor(model);

            return View("Index", supervisoresservicio.GetSupervisores());
        }

        public ActionResult Eliminar(int id_supervisor)
        {
            ISupervisorVista model = supervisoresservicio.GetSupervisor(id_supervisor);

            model.Nro_Resolucion = "";

            return View(model);
        }


        [HttpPost]
        public ActionResult Eliminar_Supervisor(SupervisorVista model)
        {
            bool mret = supervisoresservicio.EliminarSupervisor(model.Id_Supervisor, model.Nro_Resolucion);

            return View("Index", supervisoresservicio.GetSupervisores());
        }

        public ActionResult IndexPager(Pager pager)
        {
            return View("Index", supervisoresservicio.GetSupervisores(pager));
        }

    }
}
