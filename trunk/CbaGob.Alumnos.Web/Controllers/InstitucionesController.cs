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



            return View(model);
        }

        [HttpPost]
        public ActionResult Agregar_Institucion(InstitucionVista model)
        {

            IInstitucion mInstitucion = new Institucion();

            mInstitucion.INS_PROPIA = (model.INS_PROPIA == true ? "1" : "0");
            mInstitucion.N_INSTITUCION = model.N_INSTITUCION;

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
    }
}
