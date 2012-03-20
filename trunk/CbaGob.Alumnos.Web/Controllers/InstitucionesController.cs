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
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    
    public class InstitucionesController : BaseController
    {
        private IInstitucionServicio InstitucionServicio;
        private ICondicionesCursoServicio CondicionesCursoServicio;
        private ICajaChicaServicio Cajachicaservice;
        private IEstablecimientoServicio Establecimientoservicio;


        public InstitucionesController(IInstitucionServicio institucionServicio, ICondicionesCursoServicio condicionesCursoServicio, ICajaChicaServicio cajachicaservice, IEstablecimientoServicio establecimientoservicio)
        {
            InstitucionServicio = institucionServicio;
            CondicionesCursoServicio = condicionesCursoServicio;
            Cajachicaservice = cajachicaservice;
            Establecimientoservicio = establecimientoservicio;
        }

        public ActionResult Index()
        {
            return View("Index", InstitucionServicio.GetIndex());
        }

        public ActionResult Modificar(Int32 INST_ID)
        {
            IInstitucionVista model = InstitucionServicio.GetUnaVista(INST_ID);

            return View("Modificar", model);
        }

        public ActionResult Eliminar(Int32 INST_ID)
        {

            IInstitucionVista model = InstitucionServicio.GetUnaVista(INST_ID);

            model.Nro_Resolucion = "";

            return View("Eliminar", model);
        }

        public ActionResult Ver(Int32 INST_ID)
        {

            IInstitucionVista model = InstitucionServicio.GetUnaVista(INST_ID);

            model.ListaEstablecimiento = Establecimientoservicio.GetAllEstableciminetoByInstitucion(model.Id_Institucion).ListaEstablecimiento;

            model.CondicionesCursos = CondicionesCursoServicio.GetByInstitucionId(INST_ID).CondicionesCursos;

            model.CajaChica = Cajachicaservice.GetCajaChicasByInstitucion(INST_ID);

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
            mInstitucion.Telefono = model.Telefono;



            bool mReturn = InstitucionServicio.AgregarInstitucion(mInstitucion);
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
            mInstitucion.Telefono = model.Telefono;


            bool ret = InstitucionServicio.ModificarInstitucion(mInstitucion);
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



            bool mReturn = InstitucionServicio.EliminarInstitucion(model.Id_Institucion, model.Nro_Resolucion);
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

        public ActionResult BuscarCurso(Int32 Id_Institucion, string cursobusqueda, string añobuscqueda)
        {

            IInstitucionVista model = InstitucionServicio.GetUnaVista(Id_Institucion);

            model.ListaEstablecimiento = Establecimientoservicio.GetAllEstableciminetoByInstitucion(model.Id_Institucion).ListaEstablecimiento;

            model.CondicionesCursos = CondicionesCursoServicio.BuscarCondiciones(Id_Institucion, cursobusqueda, añobuscqueda, "").CondicionesCursos;

            model.CajaChica = Cajachicaservice.GetCajaChicasByInstitucion(Id_Institucion);

            model.cursobusqueda = cursobusqueda;

            model.añobuscqueda = añobuscqueda;

            return View("Ver", model);
        }

        public ActionResult BuscarSede(Int32 Id_Institucion, string cursobusqueda, string añobuscqueda, string nombresede)
        {

            IInstitucionVista model = InstitucionServicio.GetUnaVista(Id_Institucion);

            model.ListaEstablecimiento = Establecimientoservicio.BusquedaEstablecimiento(Id_Institucion, nombresede).ListaEstablecimiento;

            model.CondicionesCursos = CondicionesCursoServicio.BuscarCondiciones(Id_Institucion, cursobusqueda, añobuscqueda, "").CondicionesCursos;

            model.CajaChica = Cajachicaservice.GetCajaChicasByInstitucion(Id_Institucion);

            model.cursobusqueda = cursobusqueda;

            model.añobuscqueda = añobuscqueda;

            return View("Ver", model);
        }

        public ActionResult IndexPager(Pager pager, string Nombre_InstitucionBusqueda)
        {
            if (Nombre_InstitucionBusqueda == "")
            { return View("Index", InstitucionServicio.GetIndex(pager)); }
            else
            { return View("Index", InstitucionServicio.BuscarInstitucion(pager, Nombre_InstitucionBusqueda)); }
            
        }


    }
}
