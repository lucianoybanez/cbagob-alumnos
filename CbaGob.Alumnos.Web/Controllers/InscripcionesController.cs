using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class InscripcionesController : BaseController 
    {
        private IInscripcionServicio InscripcionServicio;

        public InscripcionesController(IInscripcionServicio inscripcionServicio)
        {
            InscripcionServicio = inscripcionServicio;
        }

        public ActionResult Index()
        {
            return View(InscripcionServicio.GetAllInscripcion());
        }

        public ActionResult Agregar()
        {
            return null;
        }

        public ActionResult Modificar(int idInscripcion)
        {
            return null;
        }

        public ActionResult Eliminar(int iIdInscripcion)
        {
            return null;
        }

    }
}
