using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class InstitucionesController : BaseController
    {
        private IInstitucionServicio InstitucionServicio;
        private IDomiciliosServicios Domiciliosdervicios;
        private ICondicionesCursoServicio CondicionesCursoServicio;


        public InstitucionesController(IInstitucionServicio institucionServicio, IDomiciliosServicios domiciliosdervicios, ICondicionesCursoServicio condicionesCursoServicio)
        {
            InstitucionServicio = institucionServicio;
            Domiciliosdervicios = domiciliosdervicios;
            CondicionesCursoServicio = condicionesCursoServicio;
        }

        public ActionResult Index()
        {
            return View("Index", InstitucionServicio.GetIndex());
        }

        public ActionResult Modificar(Int32 INST_ID)
        {

            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            IInstitucionVista model = mInstitucionServicio.GetUnaVista(INST_ID);

            model.ListaDomicilios = Domiciliosdervicios.GetTodosDomicilios();

            model.domicilios = Domiciliosdervicios.GetUno(model.ID_DOMICILIO);

            return View("Modificar", model);
        }

        public ActionResult Eliminar(Int32 INST_ID)
        {
            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            IInstitucionVista model = mInstitucionServicio.GetUnaVista(INST_ID);

            model.domicilios = Domiciliosdervicios.GetUno(model.ID_DOMICILIO);

            return View("Eliminar", model);
        }
        
        public ActionResult Agregar()
        {
            InstitucionVista model = new InstitucionVista();

            model.ListaDomicilios = Domiciliosdervicios.GetTodosDomicilios();

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Institucion(InstitucionVista model)
        {

            IInstitucion mInstitucion = new Institucion();

            mInstitucion.INS_PROPIA = (model.INS_PROPIA == true ? "1" : "0");
            mInstitucion.N_INSTITUCION = model.N_INSTITUCION;
            mInstitucion.ID_DOMICILIO = model.ID_DOMICILIO;

            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            bool mReturn = mInstitucionServicio.AgregarInstitucion(mInstitucion);


            return View("Index", InstitucionServicio.GetIndex());
        }

        [HttpPost]
        public ActionResult Modificar_Institucion(InstitucionVista model)
        {

            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            IInstitucion mInstitucion = new Institucion();

            mInstitucion.INS_PROPIA = (model.INS_PROPIA == true ? "1" : "0");

            mInstitucion.N_INSTITUCION = model.N_INSTITUCION;

            mInstitucion.ID_INSTITUCION = model.ID_INSTITUCION;

            mInstitucion.ID_DOMICILIO = model.ID_DOMICILIO;

            bool ret = mInstitucionServicio.ModificarInstitucion(mInstitucion);

            return View("Index", InstitucionServicio.GetIndex());
        }

        [HttpPost]
        public ActionResult Eliminar_Institucion(InstitucionVista model)
        {

            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            bool mReturn = mInstitucionServicio.EliminarInstitucion(model.ID_INSTITUCION);


            return View("Index", InstitucionServicio.GetIndex());
        }

        public ActionResult ListarCondicionCurso(int INST_ID)
        {
            return null;
        }

        public ActionResult CursosAsignados(int IdInstitucion)
        {
            return View("CursosAsignados", CondicionesCursoServicio.GetByInstitucionId(IdInstitucion));

        }
    }
}
