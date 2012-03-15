using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class CargosController : BaseController
    {
        //
        // GET: /Cargos/
        private ICargosServicio cargoservicio;


        public CargosController(ICargosServicio cargoservicio)
        {
            this.cargoservicio = cargoservicio;
        }

        public ActionResult Index()
        {
            return View(cargoservicio.GetTodosCargos());
        }

        public ActionResult Agregar()
        {
            ICargoVista model = new CargoVista();

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Cargo(CargoVista model)
        {
            bool mreturn = cargoservicio.AgregarCargo(model);
            if (mreturn == true)
            {
                return View("Index", cargoservicio.GetTodosCargos());
            }
            base.AddError(cargoservicio.GetErrors());
            return View("Agregar", model);

        }

        public ActionResult Modificar(int idcargo)
        {
            ICargoVista model = cargoservicio.GetCargo(idcargo);

            return View(model);
        }

        [HttpPost]
        public ActionResult modificar_Cargo(CargoVista model)
        {
            bool mreturn = cargoservicio.ModificarCargo(model);
            if (mreturn == true)
            {
                return View("Index", cargoservicio.GetTodosCargos());
            }
            base.AddError(cargoservicio.GetErrors());
            return View("Agregar", model);

        }

        public ActionResult Eliminar(int idcargo)
        {
            ICargoVista model = cargoservicio.GetCargo(idcargo);

            model.Nro_Resolucion = "";

            return View(model);
        }

        [HttpPost]
        public ActionResult Eliminar_Cargo(CargoVista model)
        {
            bool mReturn = cargoservicio.EliminarCargo(model.Id_Cargo, model.Nro_Resolucion);
            if (mReturn)
            {
                return View("Index", cargoservicio.GetTodosCargos());
            }
            base.AddError(cargoservicio.GetErrors());
            return View("Eliminar", model);
        }

        public ActionResult IndexPager(Pager pager)
        {
            return View("Index", cargoservicio.GetTodosCargos(pager));
        }

    }
}
