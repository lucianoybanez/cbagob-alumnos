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
    public class EquipamientosController : Controller
    {
        //
        // GET: /Equipamientos/

        private IEquipoServicio equiposervicio;


        public EquipamientosController(IEquipoServicio equiposervicio)
        {
            this.equiposervicio = equiposervicio;
        }

        public ActionResult Index()
        {
            return View(equiposervicio.GetEquipos());
        }


        public ActionResult Agregar()
        {
            IEquipoVista model = new EquipoVista();

            return View(equiposervicio.GetForAlta());
        }


        [HttpPost]
        public ActionResult Agregar_Equipo(EquipoVista model)
        {

            model.Id_Estado_Equipo = Convert.ToInt32(model.EstadoEquipo.Selected);

            bool mret = equiposervicio.AgregarEquipo(model);

            return View("Index", equiposervicio.GetEquipos());
        }

        public ActionResult Modificar(int id_equipo)
        {
            IEquipoVista model = equiposervicio.GetEquipo(id_equipo);

            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar_Equipo(EquipoVista model)
        {
            model.Id_Estado_Equipo = Convert.ToInt32(model.EstadoEquipo.Selected);

            bool mret = equiposervicio.ModificarEquipo(model);

            return View("Index", equiposervicio.GetEquipos());
        }

        public ActionResult Eliminar(int id_equipo)
        {
            IEquipoVista model = equiposervicio.GetEquipo(id_equipo);

            model.EstadoEquipo.Enabled = false;

            return View(model);
        }

        [HttpPost]
        public ActionResult Eliminar_Equipo(EquipoVista model)
        {
           
            bool mret = equiposervicio.EliminarEquipo(model.Id_Equipo);

            return View("Index", equiposervicio.GetEquipos());
        }
    }
}
