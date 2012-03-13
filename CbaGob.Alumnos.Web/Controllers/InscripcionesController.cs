using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    
    public class InscripcionesController : BaseController
    {
        private IInscripcionServicio InscripcionServicio;

        private IExamenServicio ExamenServicio;

        public InscripcionesController(IInscripcionServicio inscripcionServicio, IExamenServicio examenServicio)
        {
            InscripcionServicio = inscripcionServicio;
            ExamenServicio = examenServicio;
        }

        #region 'Inscripciones'

        public ActionResult Index()
        {
            return View(InscripcionServicio.GetAllInscripcion());
        }

        public ActionResult IndexPager(Pager pager)
        {
            return View("Index", InscripcionServicio.GetAllInscripcion(pager));
        }

        public ActionResult Agregar()
        {
            var vista = InscripcionServicio.GetInscripcion(0);
            vista.Accion = "Agregar";
            return View(vista);
        }

        public ActionResult Modificar(int idInscripcion)
        {
            var vista = InscripcionServicio.GetInscripcion(idInscripcion);
            vista.Accion = "Modificar";
            return View("Agregar", vista);
        }

        public ActionResult Ver(int idInscripcion)
        {
            var vista = InscripcionServicio.GetInscripcion(idInscripcion);
            vista.Accion = "Ver";
            return View("Agregar", vista);
        }

        public ActionResult Eliminar(int idInscripcion)
        {
            var vista = InscripcionServicio.GetInscripcion(idInscripcion);
            vista.Accion = "Eliminar";
            return View("Agregar", vista);
        }

        public ActionResult Guardar(InscripcionVista vista)
        {
            bool result = false;
            if (vista.Accion == "Agregar")
            {
                result = InscripcionServicio.AgregarInscripcion(vista);
            }
            if (!result)
            {
                base.AddError(InscripcionServicio.GetErrors());
                return View("Agregar", vista);
            }
            return RedirectToAction("Index");
        }

        public ActionResult GuardarEliminacion(int IdInscripcion)
        {
            if (!InscripcionServicio.EliminarInscripcion(IdInscripcion))
            {
                base.AddError(InscripcionServicio.GetErrors());
                return RedirectToAction("Eliminar", IdInscripcion);
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region 'Presentismo'

        public ActionResult Presentismo()
        {
            return View();
        }


        public ActionResult GuardarPresentismo(InscripcionPresentismoVista vista)
        {
            bool result = InscripcionServicio.GuardarPresentismo(vista);
            if (!result)
            {
                base.AddError(InscripcionServicio.GetErrors());
            }
            return Ver(vista.IdInscripcion);
        }

        #endregion

        #region 'EmitirCertificado'

        public ActionResult Certificado()
        {
            CertificadoVista vista = new CertificadoVista();
            return View(vista);
        }

        [HttpPost]
        public ActionResult CertificadoPDF(CertificadoVista vista)
        {
            string appPath = HttpContext.Request.ApplicationPath;
            string physicalPath = HttpContext.Request.MapPath(appPath) + "Content\\images\\";
            vista.ImagenEscudoPath = physicalPath + "EscudoCordoba.png";
            return ViewPdf(vista);
        }


        #endregion

        #region 'Examenes'

        public ActionResult Examenes()
        {
            return View();
        }

        #endregion

        public PartialViewResult GetListaInscriptos(string nombre, string apellido, string dni, string institucion)
        {
            return PartialView("_ListaInscripciones",InscripcionServicio.GetAllInscripcionBy(nombre, apellido, dni, institucion).ListaInscripciones);
        }
    }
}
