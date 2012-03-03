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

            model.DomicilioBusqueda.Tipo = "Domicilios";
            model.DomicilioBusqueda.Name = "BuDomicilio";
            model.DomicilioBusqueda.Valor = model.DireccionCompleta;

            return View("Modificar", model);
        }

        public ActionResult Eliminar(Int32 INST_ID)
        {
            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            IInstitucionVista model = mInstitucionServicio.GetUnaVista(INST_ID);

            return View("Eliminar", model);
        }

        public ActionResult Ver(Int32 INST_ID)
        {

            IInstitucionVista model = InstitucionServicio.GetUnaVista(INST_ID);

            IEstablecimientoServicio establecimientoservicio = new EstablecimientoServicio();

            model.ListaEstablecimiento = establecimientoservicio.GetAllEstableciminetoByInstitucion(model.Id_Institucion).ListaEstablecimiento;

            model.CondicionesCursos = CondicionesCursoServicio.GetByInstitucionId(INST_ID).CondicionesCursos;
           
            return View("Ver", model);
        }

        public ActionResult Agregar()
        {
            InstitucionVista model = new InstitucionVista();

            model.DomicilioBusqueda.Tipo = "Domicilios";
            model.DomicilioBusqueda.Name = "BuDomicilio";

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Institucion(InstitucionVista model)
        {

            IInstitucion mInstitucion = new Institucion();

            mInstitucion.espropia = (model.espropia == true ? "1" : "0");
            mInstitucion.Nombre_Institucion = model.Nombre_Institucion;
            mInstitucion.Id_Domicilio = model.Id_Domicilio;

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

            mInstitucion.Id_Domicilio = model.Id_Domicilio;

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

            bool mReturn = mInstitucionServicio.EliminarInstitucion(model.Id_Institucion);
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


    }
}
