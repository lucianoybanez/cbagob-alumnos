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
    public class CursosController : BaseController
    {
        private ICursosServicios mCursosServicios;

        public CursosController()
        {
            mCursosServicios = new CursosServicios();
        }

        public ActionResult Index()
        {
            ICursosVista model = new CursosVista();

            model.ListaCursos = mCursosServicios.GetTodos();

            return View(model);
        }

        public ActionResult Agregar()
        {
            ICursosVista model = mCursosServicios.GetVistaIndex();

            return View(model);
        }

        public ActionResult Modificar(Int32 id_curso)
        {
            ICursosVista model = mCursosServicios.GetUnaVista(id_curso);

            return View("Modificar", model);
        }

        public ActionResult Eliminar(Int32 id_curso)
        {
            ICursosVista model = mCursosServicios.GetUnaVista(id_curso);

            model.AreasTipoCursos.Enabled = false;

            model.NRORESOLUCION = "";

            return View("Eliminar", model);
        }

        [HttpPost]
        public ActionResult Agregar_Cursos(CursosVista model)
        {
            ICursos mCursos = new Cursos();

            mCursos.N_CURSO = model.N_CURSO;
            mCursos.NRORESOLUCION = model.NRORESOLUCION;
            mCursos.Id_Area_Tipo_Curso = Convert.ToInt32(model.AreasTipoCursos.Selected);

            bool mret = mCursosServicios.Agregar(mCursos);

            model.ListaCursos = mCursosServicios.GetTodos();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Modificar_Cursos(CursosVista model)
        {
            ICursos mCursos = new Cursos();

            mCursos.N_CURSO = model.N_CURSO;
            mCursos.ID_CURSO = model.ID_CURSO;
            mCursos.NRORESOLUCION = model.NRORESOLUCION;
            mCursos.Id_Area_Tipo_Curso = Convert.ToInt32(model.AreasTipoCursos.Selected);

            bool mret = mCursosServicios.Modificar(mCursos);

            model.ListaCursos = mCursosServicios.GetTodos();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Eliminar_Cursos(CursosVista model)
        {

            bool mret = mCursosServicios.Eliminar(model.ID_CURSO, model.NRORESOLUCION);

            model.ListaCursos = mCursosServicios.GetTodos();

            return View("Index", model);
        }

    }
}
