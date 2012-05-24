using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Web.Controllers
{
    [ViewAuthorize(Rol = new RolTipo[] { RolTipo.Supervisor, RolTipo.ResponsableIFP })]
    public class PrestamosController : Controller
    {
        //
        // GET: /Prestamos/

        private IPrestamoServicio prestamoservicio;


        public PrestamosController(IPrestamoServicio prestamoservicio)
        {
            this.prestamoservicio = prestamoservicio;
        }

        public ActionResult Index()
        {
            return View(prestamoservicio.GetPrestamos());
        }

        public ActionResult Agregar()
        {
            IPrestamoVista model = new PrestamoVista();

            model.Fec_Inicio = System.DateTime.Now;
            model.Fec_Fin = System.DateTime.Now;

            model.Institucion.Name = "BuInstitutos";
            model.Institucion.Tipo = "Instituciones";

            model.Equipos.Name = "BuEquipos";
            model.Equipos.Tipo = "Equipos";

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Prestamo(PrestamoVista model)
        {
            bool mret = prestamoservicio.AgregarPresatmo(model);
            return View("Index", prestamoservicio.GetPrestamos());
        }

        public ActionResult Modificar(int id_prestamo)
        {
            IPrestamoVista model = prestamoservicio.GetPrestamo(id_prestamo);

            model.Institucion.Name = "BuInstitutos";
            model.Institucion.Tipo = "Instituciones";
            model.Institucion.Valor = model.NombreInstitucion;

            model.Equipos.Name = "BuEquipos";
            model.Equipos.Tipo = "Equipos";
            model.Equipos.Valor = model.NombreEquipo;

            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar_Prestamo(PrestamoVista model)
        {
            bool mret = prestamoservicio.ModificarPresatmo(model);
            return View("Index", prestamoservicio.GetPrestamos());
        }

        public ActionResult Eliminar(int id_prestamo)
        {
            return View(prestamoservicio.GetPrestamo(id_prestamo));
        }

        [HttpPost]
        public ActionResult Eliminar_Prestamo(PrestamoVista model)
        {
            bool mret = prestamoservicio.EliminarPresatmo(model.Id_Prestamo);
            return View("Index", prestamoservicio.GetPrestamos());
        }

        public ActionResult IndexPager(Pager pager)
        {
            return View("Index", prestamoservicio.GetPrestamos(pager));
        }
    }
}
