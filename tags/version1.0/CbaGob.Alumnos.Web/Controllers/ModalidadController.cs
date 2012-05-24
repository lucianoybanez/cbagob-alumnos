using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    [ViewAuthorize(Rol = new RolTipo[] { RolTipo.Supervisor })]
    public class ModalidadController : BaseController
    {
       
        private IModalidadServicio modalidadservicio;


        public ModalidadController(IModalidadServicio modalidadservicio)
        {
            this.modalidadservicio = modalidadservicio;
        }

        public ActionResult Index()
        {
            return View(modalidadservicio.GetModalidades());
        }

        public ActionResult Agregar()
        {
            IModalidadVista model = new ModalidadVista();

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Modalidad(ModalidadVista model)
        {
            bool mreturn = modalidadservicio.AgregarModalidad(model);
            if (mreturn == true)
            {
                return View("Index", modalidadservicio.GetModalidades());
            }
            base.AddError(modalidadservicio.GetErrors());
            return View("Agregar", model);

        }

        public ActionResult Modificar(int idmodalidad)
        {
            IModalidadVista model = modalidadservicio.GetModalidad(idmodalidad);

            return View(model);
        }


        [HttpPost]
        public ActionResult Modificar_Modalidad(ModalidadVista model)
        {
            bool mreturn = modalidadservicio.ModificarModalidad(model);
            if (mreturn == true)
            {
                return View("Index", modalidadservicio.GetModalidades());
            }
            base.AddError(modalidadservicio.GetErrors());
            return View("Agregar", model);

        }

        public ActionResult Eliminar(int idmodalidad)
        {
            IModalidadVista model = modalidadservicio.GetModalidad(idmodalidad);

            model.Nro_Resolucion = "";

            return View(model);
        }


        [HttpPost]
        public ActionResult Eliminar_Modalidad(ModalidadVista model)
        {
            bool mreturn = modalidadservicio.EliminarModalidad(model.IdModalidad, model.Nro_Resolucion);
            if (mreturn == true)
            {
                return View("Index", modalidadservicio.GetModalidades());
            }
            base.AddError(modalidadservicio.GetErrors());
            return View("Agregar", model);

        }


        public ActionResult IndexPager(Pager pager)
        {
            return View("Index", modalidadservicio.GetModalidades(pager));
        }

    }
}
