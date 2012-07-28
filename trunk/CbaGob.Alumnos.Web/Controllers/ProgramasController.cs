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
    public class ProgramasController : BaseController
    {

        private IProgramaServicio programaservicio;

        public ProgramasController(IProgramaServicio programaservicio)
        {
            this.programaservicio = programaservicio;
        }

        public ActionResult Index()
        {
            return View(programaservicio.GetProgramas());
        }

        public ActionResult Agregar()
        {
            IProgramaVista vista = new ProgramaVista();

            return View(vista);
        }

        public ActionResult IndexPager(Pager pager)
        {
            return View("Index", programaservicio.GetProgramas(pager));
        }

        [HttpPost]
        public ActionResult Agregar_Programa(ProgramaVista model)
        {
            bool mreturn = programaservicio.AgregarPrograma(model);
            if (mreturn == true)
            {
                return View("Index", programaservicio.GetProgramas());
            }
            base.AddError(programaservicio.GetErrors());
            return View("Agregar", model);

        }

        public ActionResult Modificar(int idprograma)
        {
            IProgramaVista vista = programaservicio.GetPrograma(idprograma);

            return View(vista);
        }

        [HttpPost]
        public ActionResult Modificar_Programa(ProgramaVista model)
        {
            bool mreturn = programaservicio.ModificarPrograma(model);
            if (mreturn == true)
            {
                return View("Index", programaservicio.GetProgramas());
            }
            base.AddError(programaservicio.GetErrors());
            return View("Agregar", model);

        }


        public ActionResult Eliminar(int idprograma)
        {
            IProgramaVista vista = programaservicio.GetPrograma(idprograma);

            vista.Nro_resolucion = "";

            return View(vista);
        }

        [HttpPost]
        public ActionResult Eliminar_Programa(ProgramaVista model)
        {
            bool mreturn = programaservicio.EliminarPrograma(model.IdPrograma, model.Nro_resolucion);
            if (mreturn == true)
            {
                return View("Index", programaservicio.GetProgramas());
            }
            base.AddError(programaservicio.GetErrors());
            return View("Agregar", model);

        }

    }
}
