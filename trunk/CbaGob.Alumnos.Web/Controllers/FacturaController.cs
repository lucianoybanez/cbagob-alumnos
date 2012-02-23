using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class FacturaController : BaseController 
    {
        private IFacturaServicio FacturaServicio;

        public FacturaController(IFacturaServicio facturaServicio)
        {
            FacturaServicio = facturaServicio;
        }

        public ActionResult Index()
        {
            return View("Index",FacturaServicio.GetFacturas());
        }

        public ActionResult Agregar()
        {
            return View("Agregar",FacturaServicio.GetIndex());
        }

        public ActionResult Detalle(int Idfactura)
        {
            return View("Agregar",FacturaServicio.GetFactura(Idfactura));
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

    }
}
