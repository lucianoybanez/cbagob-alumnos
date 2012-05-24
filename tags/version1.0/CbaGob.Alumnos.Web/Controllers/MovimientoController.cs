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
    public class MovimientoController : Controller
    {
        //
        // GET: /Movimiento/

        private IMovimientoServicio moviminetoservicio;


        public MovimientoController(IMovimientoServicio moviminetoservicio)
        {
            this.moviminetoservicio = moviminetoservicio;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Agregar(int id_institucion, int Id_Caja_Chica)
        {
            IMovimientoVista model = moviminetoservicio.GetIndex();

            model.Id_Caja_Chica = Id_Caja_Chica;

            model.Id_Institucion = id_institucion;


            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarMovimineto(MovimientoVista model)
        {

            bool mret = moviminetoservicio.AgregarMovimiento(model);

            return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });
        }

        public ActionResult Modificar(int Id_Movimineto)
        {
            IMovimientoVista model = moviminetoservicio.GetMovimiento(Id_Movimineto);

            return View(model);
        }

        [HttpPost]
        public ActionResult ModificarMovimineto(MovimientoVista model)
        {

            bool mret = moviminetoservicio.ModificarMovimiento(model);

            return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });
        }

        public ActionResult Eliminar(int Id_Movimineto)
        {
            IMovimientoVista model = moviminetoservicio.GetMovimiento(Id_Movimineto);

            model.TipoMovimiento.Enabled = false;

            return View(model);
        }

        [HttpPost]
        public ActionResult EliminarMovimineto(MovimientoVista model)
        {

            bool mret = moviminetoservicio.EliminarMovimiento(model.Id_Movimiento);

            return RedirectToAction("Ver", "Instituciones", new { INST_ID = model.Id_Institucion });
        }

    }
}
