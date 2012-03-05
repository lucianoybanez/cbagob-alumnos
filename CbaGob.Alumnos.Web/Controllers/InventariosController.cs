using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class InventariosController : Controller
    {
        //
        // GET: /Inventarios/
        private IInventarioServicio inventarioservicio;

        public InventariosController()
        {
            inventarioservicio = new InventarioServicio();
        }


        public ActionResult Index()
        {
            return View(inventarioservicio.GetInventario());
        }

        public ActionResult Ver(int id_estado)
        {

            IInventarioVista model = inventarioservicio.GetInventario(id_estado);

            return View(model);
        }

    }
}
