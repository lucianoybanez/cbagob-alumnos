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
    public class CursosController : Controller
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
            CursosVista model = new CursosVista();

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

            return View("Eliminar", model);
        }

        [HttpPost]
        public ActionResult Agregar_Cursos(CursosVista model)
        {
            ICursos mCursos = new Cursos();

            mCursos.N_CURSO = model.N_CURSO;
            mCursos.NRORESOLUCION = model.NRORESOLUCION; 

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

            bool mret = mCursosServicios.Modificar(mCursos);

            model.ListaCursos = mCursosServicios.GetTodos();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Eliminar_Cursos(CursosVista model)
        {

            bool mret = mCursosServicios.Eliminar(model.ID_CURSO);

            model.ListaCursos = mCursosServicios.GetTodos();

            return View("Index", model);
        }

    }
}
