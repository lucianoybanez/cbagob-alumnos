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
    public class CajaChicaController : Controller
    {
        //
        // GET: /CajaChica/
        private ICajaChicaServicio cajachicaservicio;
        private IMovimientoServicio movimientoservicio;


        public CajaChicaController()
        {
            cajachicaservicio = new CajaChicaServicio();
            movimientoservicio = new MovimientoServicio();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar(int id_institucion)
        {
            ICajaChicaVista model = cajachicaservicio.GetIndex(id_institucion);

            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarCaja(CajaChicaVista model)
        {
            bool mreturn = cajachicaservicio.AgregarCajaChica(model);

            return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });
        }

        public ActionResult Modificar(int id_institucion, int Id_Caja_Chica)
        {
            ICajaChicaVista model = cajachicaservicio.GetCajaChica(Id_Caja_Chica);

            return View(model);
        }

        public ActionResult ModificarCaja(CajaChicaVista model)
        {
            bool mreturn = cajachicaservicio.ModificaCajaChica(model);

            return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });
        }

        public ActionResult Eliminar(int id_institucion, int Id_Caja_Chica)
        {
            ICajaChicaVista model = cajachicaservicio.GetCajaChica(Id_Caja_Chica);

            return View(model);
        }

        public ActionResult EliminarCaja(CajaChicaVista model)
        {
            bool mreturn = cajachicaservicio.EliminarCajaChica(model.Id_Caja_Chica);

            return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });
        }

        public ActionResult Ver(int id_institucion, int Id_Caja_Chica)
        {
            ICajaChicaVista model = cajachicaservicio.GetCajaChica(Id_Caja_Chica);

            model.Moviminetos = movimientoservicio.GetMovimientosByCajaChica(Id_Caja_Chica);
            
            return View(model);
        }

    }
}
