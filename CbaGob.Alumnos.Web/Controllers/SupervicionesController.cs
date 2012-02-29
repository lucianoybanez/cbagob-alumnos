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
    public class SupervicionesController : Controller
    {
        //
        // GET: /Superviciones/
        private ISupervicionesServicio supervicionesservicio;
        private IInstitucionServicio institucionservicio;
        private ICondicionesCursoServicio condicionescursoservicio;
        private IGrupoServicio gruposservicio;


        public SupervicionesController(ICondicionesCursoServicio pcondicionescursoservicio)
        {
            supervicionesservicio = new SupervicionesServicio();
            institucionservicio = new InstitucionServicio();
            condicionescursoservicio = pcondicionescursoservicio;
            gruposservicio = new GrupoServicio();
        }


        public ActionResult Index()
        {

            return View(supervicionesservicio.GetSuperviciones());
        }


        public ActionResult Agregar()
        {
            ISupervicionVista model = new SupervicionVista();

            model.Institucions = institucionservicio.GetIndex();

            return View(model);
        }

        public ActionResult VerCursos(int IdInstitucion)
        {
            ISupervicionVista model = new SupervicionVista();

            model.Cursos = condicionescursoservicio.GetByInstitucionId(IdInstitucion);

            model.Institucions = institucionservicio.GetIndex();

            return View("Agregar", model);
        }

        public ActionResult VerGrupos(int idCondicionCurso, int IdInstitucion)
        {
            ISupervicionVista model = new SupervicionVista();

            model.Cursos = condicionescursoservicio.GetByInstitucionId(IdInstitucion);

            model.Grupos = gruposservicio.GetAllGrupoByCurso(idCondicionCurso);

            model.Institucions = institucionservicio.GetIndex();

            return View("Agregar", model);
        }

        public ActionResult RealizarSupervicionGrupo(int id_grupo)
        {
            ISupervicionVista model = new SupervicionVista();

            model.Grupo = gruposservicio.GetGrupo(id_grupo);

            model.Fec_Supervision = System.DateTime.Now;

            return View("Agregar_2Paso", model);
        }
        





    }
}
