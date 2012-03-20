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
    [ViewAuthorize(Rol = new RolTipo[] { RolTipo.Supervisor, RolTipo.ResponsableIFP })]
    public class CajaChicaController : Controller
    {
        //
        // GET: /CajaChica/
        private ICajaChicaServicio cajachicaservicio;
        private IMovimientoServicio movimientoservicio;


        public CajaChicaController(ICajaChicaServicio cajachicaservicio, IMovimientoServicio movimientoservicio)
        {
            this.cajachicaservicio = cajachicaservicio;
            this.movimientoservicio = movimientoservicio;
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

            if (mreturn != false)
            { return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion }); }
            else
            {
                return View("Agregar", model);
            }
        }

        public ActionResult Modificar(int id_institucion, int Id_Caja_Chica)
        {
            ICajaChicaVista model = cajachicaservicio.GetCajaChica(Id_Caja_Chica);

            return View(model);
        }

        public ActionResult ModificarCaja(CajaChicaVista model)
        {
            bool mreturn = cajachicaservicio.ModificaCajaChica(model);

            if (mreturn)
            {
                return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });
            }
            else
            {
                ICajaChicaVista vista = cajachicaservicio.GetCajaChica(model.Id_Caja_Chica);
                return View("Modificar", vista);
            }
        }

        public ActionResult Eliminar(int id_institucion, int Id_Caja_Chica)
        {
            ICajaChicaVista model = cajachicaservicio.GetCajaChica(Id_Caja_Chica);

            return View(model);
        }

        public ActionResult EliminarCaja(CajaChicaVista model)
        {
            bool mreturn = cajachicaservicio.EliminarCajaChica(model.Id_Caja_Chica);

            if (mreturn)
            {
                return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });
            }
            else
            {
                ICajaChicaVista vista = cajachicaservicio.GetCajaChica(model.Id_Caja_Chica);
                return View("Eliminar", vista);
            }

        }

        public ActionResult Ver(int id_institucion, int Id_Caja_Chica)
        {
            ICajaChicaVista model = cajachicaservicio.GetCajaChica(Id_Caja_Chica);

            model.Moviminetos = movimientoservicio.GetMovimientosByCajaChica(Id_Caja_Chica);

            decimal montototalmovimineto = 0;

            foreach (var movimientos in model.Moviminetos.ListaMoviento)
            {
                montototalmovimineto = montototalmovimineto + movimientos.Monto;
            }

            model.SaldoCaja = model.Monto - montototalmovimineto;

            return View(model);
        }

    }
}
