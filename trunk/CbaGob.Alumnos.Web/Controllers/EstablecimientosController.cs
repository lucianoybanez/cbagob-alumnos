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
    public class EstablecimientosController : Controller
    {
        private IEstablecimientoServicio establecimientoservicio;
        private IDomiciliosServicios domiciliosservicios;

        //
        // GET: /Establecimientos/

        public EstablecimientosController()
        {
            establecimientoservicio = new EstablecimientoServicio();
            domiciliosservicios = new DomiciliosServicios();

        }

        public ActionResult Index()
        {
            IEstablecimientosVista model = new EstablecimientosVista();

            model = establecimientoservicio.GetAllEstableciminetoByInstitucion(26);

            return View(model);
        }

        public ActionResult Agregar()
        {

            IEstablecimientoVista model = new EstablecimientoVista();

            model.ListaDomicilio = domiciliosservicios.GetTodosDomicilios();

            return View(model);
        }

        public ActionResult Modificar(int id_establecimiento)
        {
            IEstablecimientoVista model;

            model = establecimientoservicio.GetEstablecimiento(id_establecimiento);
            
            model.ListaDomicilio = domiciliosservicios.GetTodosDomicilios();

            return View(model);
        }

        public ActionResult Eliminar(int id_establecimiento)
        {
            IEstablecimientoVista model;

            model = establecimientoservicio.GetEstablecimiento(id_establecimiento);

            model.ListaDomicilio = domiciliosservicios.GetTodosDomicilios();

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Establecimiento(EstablecimientoVista model)
        {

            model.Id_Institucion = 26;
            bool mRet = establecimientoservicio.AgregarEstablecimiento(model);

            IEstablecimientosVista establecimientosvista = new EstablecimientosVista();

            establecimientosvista = establecimientoservicio.GetAllEstableciminetoByInstitucion(26);

            return View("Index", establecimientosvista);
        }

        [HttpPost]
        public ActionResult Eliminar_Establecimiento(EstablecimientoVista model)
        {


            bool mRet = establecimientoservicio.EliminarEstablecimiento(model.Id_Establecimiento);

            IEstablecimientosVista establecimientosvista = new EstablecimientosVista();

            establecimientosvista = establecimientoservicio.GetAllEstableciminetoByInstitucion(26);

            return View("Index", establecimientosvista);
        }

        [HttpPost]
        public ActionResult Modificar_Establecimiento(EstablecimientoVista model)
        {

            model.Id_Institucion = 26;
            bool mRet = establecimientoservicio.ModificarEstablecimiento(model);

            IEstablecimientosVista establecimientosvista = new EstablecimientosVista();

            establecimientosvista = establecimientoservicio.GetAllEstableciminetoByInstitucion(26);

            return View("Index", establecimientosvista);

        }

    }
}
