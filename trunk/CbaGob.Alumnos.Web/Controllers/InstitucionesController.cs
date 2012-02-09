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

namespace CbaGob.Alumnos.Web.Controllers
{
    public class InstitucionesController : Controller
    {
        private IInstitucionServicio InstitucionServicio;


        public InstitucionesController()
        {
            InstitucionServicio = new InstitucionServicio();
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

            return View("Eliminar", model);
        }


        public ActionResult Agregar()
        {
            InstitucionVista model = new InstitucionVista();

            IProvinciasServicio mProvinciasServicio = new ProvinciasServicio();

            model.ListaProvincias = mProvinciasServicio.GetTodas();

            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Institucion(InstitucionVista model)
        {

            IInstitucion mInstitucion = new Institucion();

            mInstitucion.INS_PROPIA = (model.INS_PROPIA == true ? "1" : "0");
            mInstitucion.INST_NOMBRE = model.INST_NOMBRE;
            mInstitucion.INST_NRO = model.INST_NRO;
            mInstitucion.INST_TELEFONO = model.INST_TELEFONO;
            mInstitucion.ID_PROVINCIA = model.ID_PROVINCIA;
            mInstitucion.ID_BARRIO = model.ID_BARRIO;
            mInstitucion.ID_CALLE = model.ID_CALLE;
            mInstitucion.ID_LOCALIDAD = model.ID_LOCALIDAD;
            mInstitucion.ID_DEPARTAMENTO = model.ID_DEPARTAMENTO;

            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            bool mReturn = mInstitucionServicio.AgregarInstitucion(mInstitucion);

            IProvinciasServicio mProvinciasServicio = new ProvinciasServicio();

            model.ListaProvincias = mProvinciasServicio.GetTodas();

            return View("Index", InstitucionServicio.GetIndex());
        }

        [HttpPost]
        public ActionResult Modificar_Institucion(InstitucionVista model)
        {

            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            IInstitucion mInstitucion = new Institucion();

            mInstitucion.INS_PROPIA = (model.INS_PROPIA == true ? "1" : "0");
            mInstitucion.INST_NOMBRE = model.INST_NOMBRE;
            mInstitucion.INST_NRO = model.INST_NRO;
            mInstitucion.INST_TELEFONO = model.INST_TELEFONO;
            mInstitucion.ID_PROVINCIA = model.ID_PROVINCIA;
            mInstitucion.ID_BARRIO = model.ID_BARRIO;
            mInstitucion.ID_CALLE = model.ID_CALLE;
            mInstitucion.ID_LOCALIDAD = model.ID_LOCALIDAD;
            mInstitucion.ID_DEPARTAMENTO = model.ID_DEPARTAMENTO;
            mInstitucion.INST_ID = model.INST_ID;


            bool ret = mInstitucionServicio.ModificarInstitucion(mInstitucion);

            return View("Index", InstitucionServicio.GetIndex());
        }

        [HttpPost]
        public ActionResult Eliminar_Institucion(InstitucionVista model)
        {

            IInstitucionServicio mInstitucionServicio = new InstitucionServicio();

            bool mReturn = mInstitucionServicio.EliminarInstitucion(model.INST_ID);


            return View("Index", InstitucionServicio.GetIndex());
        }


        [HttpPost]
        public ActionResult CargarDepartamentos(InstitucionVista pmodel)
        {
            IProvinciasServicio mProvinciasServicio = new ProvinciasServicio();

            pmodel.ListaProvincias = mProvinciasServicio.GetTodas();

            IDepartamentosServicios mDepartamentosServicios = new DepartamentosServicios();

            pmodel.ListaDepartamento = mDepartamentosServicios.GetTodasbyProvincia(pmodel.ID_PROVINCIA);

            return View("Agregar", pmodel);
        }

        [HttpPost]
        public ActionResult CargarLocalidad(InstitucionVista pmodel)
        {
            IProvinciasServicio mProvinciasServicio = new ProvinciasServicio();

            pmodel.ListaProvincias = mProvinciasServicio.GetTodas();

            IDepartamentosServicios mDepartamentosServicios = new DepartamentosServicios();

            pmodel.ListaDepartamento = mDepartamentosServicios.GetTodasbyProvincia(pmodel.ID_PROVINCIA);


            ILocalidadesServicio mLocalidadesServicio = new LocalidadesServicio();

            pmodel.ListaLocalidades = mLocalidadesServicio.getTodasByDepartamento(pmodel.ID_DEPARTAMENTO);

            return View("Agregar", pmodel);
        }

        [HttpPost]
        public ActionResult CargarBarrios(InstitucionVista pmodel)
        {
            IProvinciasServicio mProvinciasServicio = new ProvinciasServicio();

            pmodel.ListaProvincias = mProvinciasServicio.GetTodas();

            IDepartamentosServicios mDepartamentosServicios = new DepartamentosServicios();

            pmodel.ListaDepartamento = mDepartamentosServicios.GetTodasbyProvincia(pmodel.ID_PROVINCIA);


            ILocalidadesServicio mLocalidadesServicio = new LocalidadesServicio();

            pmodel.ListaLocalidades = mLocalidadesServicio.getTodasByDepartamento(pmodel.ID_DEPARTAMENTO);

            IBarriosServicio mBarriosServicio = new BarriosServicio();

            pmodel.ListaBarrios = mBarriosServicio.GetTodasbyLocalidad(Convert.ToInt32(pmodel.ID_LOCALIDAD));

            return View("Agregar", pmodel);
        }

        [HttpPost]
        public ActionResult CargarCalles(InstitucionVista pmodel)
        {
            IProvinciasServicio mProvinciasServicio = new ProvinciasServicio();

            pmodel.ListaProvincias = mProvinciasServicio.GetTodas();

            IDepartamentosServicios mDepartamentosServicios = new DepartamentosServicios();

            pmodel.ListaDepartamento = mDepartamentosServicios.GetTodasbyProvincia(pmodel.ID_PROVINCIA);


            ILocalidadesServicio mLocalidadesServicio = new LocalidadesServicio();

            pmodel.ListaLocalidades = mLocalidadesServicio.getTodasByDepartamento(pmodel.ID_DEPARTAMENTO);

            IBarriosServicio mBarriosServicio = new BarriosServicio();

            pmodel.ListaBarrios = mBarriosServicio.GetTodasbyLocalidad(Convert.ToInt32(pmodel.ID_LOCALIDAD));

            ICallesServicio mCallesServicio = new CallesServicio();

            pmodel.ListaCalles = mCallesServicio.GetTodasBYProDepLoca(pmodel.ID_PROVINCIA, pmodel.ID_DEPARTAMENTO, Convert.ToInt32(pmodel.ID_LOCALIDAD));

            return View("Agregar", pmodel);
        }



    }
}
