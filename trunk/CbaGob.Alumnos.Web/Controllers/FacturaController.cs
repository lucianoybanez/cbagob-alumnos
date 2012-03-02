using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class FacturaController : BaseController
    {
        private IFacturaServicio FacturaServicio;
        private IInstitucionServicio institucionservicio;
        private ICondicionesCursoServicio condicionescursoservicio;

        public FacturaController(IFacturaServicio facturaServicio, ICondicionesCursoServicio pcondicionescursoservicio)
        {
            FacturaServicio = facturaServicio;
            institucionservicio = new InstitucionServicio();
            condicionescursoservicio = pcondicionescursoservicio;
        }

        public ActionResult Index()
        {
            return View("Index", FacturaServicio.GetFacturas());
        }

        public ActionResult Agregar(int idCondicionCurso, int IdInstitucion)
        {
            IFacturaVista model = FacturaServicio.GetIndex();

            model.Curso = condicionescursoservicio.GetForModificacion(idCondicionCurso);

            model.Id_Condicion_Curso = idCondicionCurso;

            return View("Agregar", model);
        }

        public ActionResult Detalle(int Idfactura)
        {
            return View("Agregar", FacturaServicio.GetFactura(Idfactura));
        }

        public ActionResult CambiarCondicion(FacturaVista factura)
        {
            return View("Agregar", FacturaServicio.CambiarCondicion(factura));
        }

        public ActionResult Eliminar(int Idfactura)
        {
            FacturaServicio.EliminarFactura(Idfactura);
            return RedirectToAction("Index");
        }

        public ActionResult GuardarFactura(FacturaVista factura)
        {
            factura.CondicionCurso.Selected = factura.Id_Condicion_Curso.ToString();
            
            if (ModelState.IsValid)
            {
                if (FacturaServicio.AgregarFactura(factura))
                {
                    return Index();
                }
                AddError(FacturaServicio.GetErrors());
            }
            return CambiarCondicion(factura);
        }

        public ActionResult Seleccion()
        {
            IFacturaVista model = FacturaServicio.GetIndex();

            model.Instituciones = institucionservicio.GetIndex();

            return View(model);
        }

        public ActionResult VerCursos(int IdInstitucion)
        {
            IFacturaVista model = new FacturaVista();

            model.Cursos = condicionescursoservicio.GetByInstitucionId(IdInstitucion);

            model.Instituciones = institucionservicio.GetIndex();

            return View("Seleccion", model);
        }

    }
}
