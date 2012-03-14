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
        private ICajaChicaServicio cajachicaservice;


        public InstitucionesController(IInstitucionServicio institucionServicio, IDomiciliosServicios domiciliosdervicios, ICondicionesCursoServicio condicionesCursoServicio)
        {
            InstitucionServicio = institucionServicio;
            Domiciliosdervicios = domiciliosdervicios;
            CondicionesCursoServicio = condicionesCursoServicio;
            cajachicaservice = new CajaChicaServicio();
        }

        public ActionResult Index()
        {
            return View("Index", InstitucionServicio.GetIndex());
        }

        public ActionResult Modificar(Int32 INST_ID)
        {

            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            IInstitucionVista model = mInstitucionServicio.GetUnaVista(INST_ID);

            return View("Modificar", model);
        }

        public ActionResult Eliminar(Int32 INST_ID)
        {
            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            IInstitucionVista model = mInstitucionServicio.GetUnaVista(INST_ID);

            model.Nro_Resolucion = "";

            return View("Eliminar", model);
        }

        public ActionResult Ver(Int32 INST_ID)
        {

            IInstitucionVista model = InstitucionServicio.GetUnaVista(INST_ID);

            IEstablecimientoServicio establecimientoservicio = new EstablecimientoServicio();

            model.ListaEstablecimiento = establecimientoservicio.GetAllEstableciminetoByInstitucion(model.Id_Institucion).ListaEstablecimiento;

            model.CondicionesCursos = CondicionesCursoServicio.GetByInstitucionId(INST_ID).CondicionesCursos;

            model.CajaChica = cajachicaservice.GetCajaChicasByInstitucion(INST_ID);

            return View("Ver", model);
        }

        public ActionResult Agregar()
        {
            InstitucionVista model = new InstitucionVista();

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Institucion(InstitucionVista model)
        {

            IInstitucion mInstitucion = new Institucion();

            mInstitucion.espropia = (model.espropia == true ? "1" : "0");
            mInstitucion.Nombre_Institucion = model.Nombre_Institucion;
            mInstitucion.Provincia = model.Provincia;
            mInstitucion.Localidad = model.Localidad;
            mInstitucion.Barrio = model.Barrio;
            mInstitucion.Calle = model.Calle;
            mInstitucion.Nro = model.Nro;
            mInstitucion.Depto = model.Depto;
            mInstitucion.Nro_Expediente = model.Nro_Expediente;
            mInstitucion.Nro_Resolucion = model.Nro_Resolucion;


            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            bool mReturn = mInstitucionServicio.AgregarInstitucion(mInstitucion);
            if (mReturn)
            {
                return View("Index", InstitucionServicio.GetIndex());
            }
            base.AddError(InstitucionServicio.GetErrors());
            return View("Agregar", model);
        }

        [HttpPost]
        public ActionResult Modificar_Institucion(InstitucionVista model)
        {

            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            IInstitucion mInstitucion = new Institucion();

            mInstitucion.espropia = (model.espropia == true ? "1" : "0");

            mInstitucion.Nombre_Institucion = model.Nombre_Institucion;

            mInstitucion.Id_Institucion = model.Id_Institucion;

            mInstitucion.Provincia = model.Provincia;
            mInstitucion.Localidad = model.Localidad;
            mInstitucion.Barrio = model.Barrio;
            mInstitucion.Calle = model.Calle;
            mInstitucion.Nro = model.Nro;
            mInstitucion.Depto = model.Depto;
            mInstitucion.Nro_Expediente = model.Nro_Expediente;
            mInstitucion.Nro_Resolucion = model.Nro_Resolucion;


            bool ret = mInstitucionServicio.ModificarInstitucion(mInstitucion);
            if (ret)
            {
                return View("Index", InstitucionServicio.GetIndex());
            }
            base.AddError(InstitucionServicio.GetErrors());
            return View("Modificar", model);

        }

        [HttpPost]
        public ActionResult Eliminar_Institucion(InstitucionVista model)
        {

            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            bool mReturn = mInstitucionServicio.EliminarInstitucion(model.Id_Institucion, model.Nro_Resolucion);
            if (mReturn)
            {
                return View("Index", InstitucionServicio.GetIndex());
            }
            base.AddError(InstitucionServicio.GetErrors());
            return View("Eliminar", model);
        }

        public ActionResult ListarCondicionCurso(int INST_ID)
        {
            return null;
        }

        public ActionResult CursosAsignados(int IdInstitucion)
        {
            return View("CursosAsignados", CondicionesCursoServicio.GetByInstitucionId(IdInstitucion));

        }

        [HttpPost]
        public ActionResult BuscarInstitucion(InstitucionVista model)
        {
            return View("Index", InstitucionServicio.BuscarInstitucion(model.Nombre_InstitucionBusqueda));
        }


    }
}
