using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class InstitucionesController : Controller
    {
        private IInstitucionServicio InstitucionServicio;


        public InstitucionesController()
        {
            InstitucionServicio = new InstitucionServicio();
        }

        public ActionResult Index()
        {
            return View("Index", InstitucionServicio.GetIndex());
        }

    }
}
