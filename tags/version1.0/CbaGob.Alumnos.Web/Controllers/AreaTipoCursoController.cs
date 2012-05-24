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
    [ViewAuthorize(Rol = new RolTipo[] { RolTipo.Supervisor})]
    public class AreaTipoCursoController : BaseController
    {
        private IAreasTipoCursoServicio areastipocursoservicio;

        public AreaTipoCursoController(IAreasTipoCursoServicio areastipocursoservicio)
        {
            this.areastipocursoservicio = areastipocursoservicio;
        }

        public ActionResult Index()
        {
            return View(areastipocursoservicio.GetAreasTipoCurso());
        }

        public ActionResult Agregar()
        {
            IAreaTipoCursoVista vista = new AreaTipoCursoVista();

            return View(vista);
        }

        [HttpPost]
        public ActionResult Agregar_AreaTipoCurso(AreaTipoCursoVista model)
        {
            bool mreturn = areastipocursoservicio.AgregarAreaTipoCargo(model);
            if (mreturn == true)
            {
                return View("Index", areastipocursoservicio.GetAreasTipoCurso());
            }
            base.AddError(areastipocursoservicio.GetErrors());
            return View("Agregar", model);

        }


        public ActionResult Modificar(int idareatipocurso)
        {
            IAreaTipoCursoVista model = areastipocursoservicio.GetAreaTipoCurso(idareatipocurso);

            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar_AreaTipoCurso(AreaTipoCursoVista model)
        {
            bool mreturn = areastipocursoservicio.ModificarAreaTipoCargo(model);
            if (mreturn == true)
            {
                return View("Index", areastipocursoservicio.GetAreasTipoCurso());
            }
            base.AddError(areastipocursoservicio.GetErrors());
            return View("Agregar", model);

        }


        public ActionResult Eliminar(int idareatipocurso)
        {
            IAreaTipoCursoVista model = areastipocursoservicio.GetAreaTipoCurso(idareatipocurso);

            model.Nro_Resolucion = "";

            return View(model);
        }

        [HttpPost]
        public ActionResult Eliminar_AreaTipoCurso(AreaTipoCursoVista model)
        {
            bool mreturn = areastipocursoservicio.EliminarAreaTipoCargo(model.Id_Area_Tipo_Curso, model.Nro_Resolucion);
            if (mreturn == true)
            {
                return View("Index", areastipocursoservicio.GetAreasTipoCurso());
            }
            base.AddError(areastipocursoservicio.GetErrors());
            return View("Agregar", model);

        }

        public ActionResult IndexPager(Pager pager)
        {
            return View("Index", areastipocursoservicio.GetAreasTipoCurso(pager));
        }

    }
}
