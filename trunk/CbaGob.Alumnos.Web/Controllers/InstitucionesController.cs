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
            return View("Index", InstitucionServicio.GetIndex());
        }

        public ActionResult Eliminar(Int32 INST_ID)
        {
            return View("Index", InstitucionServicio.GetIndex());
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
            if (ModelState.IsValid)
            {

                IProvinciasServicio mProvinciasServicio = new ProvinciasServicio();

                model.ListaProvincias = mProvinciasServicio.GetTodas();

               
            }
            return View("Agregar", model);
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

            pmodel.ListaBarrios = mBarriosServicio.GetTodasbyLocalidad(pmodel.ID_LOCALIDAD);

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

            pmodel.ListaBarrios = mBarriosServicio.GetTodasbyLocalidad(pmodel.ID_LOCALIDAD);

            ICallesServicio mCallesServicio = new CallesServicio();

            pmodel.ListaCalles = mCallesServicio.GetTodasBYProDepLoca(pmodel.ID_PROVINCIA, pmodel.ID_DEPARTAMENTO, pmodel.ID_LOCALIDAD);

            return View("Agregar", pmodel);
        }

        

    }
}
