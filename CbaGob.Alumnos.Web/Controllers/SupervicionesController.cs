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

            model.supervisor.Name = "BuSupervsores";
            model.supervisor.Tipo = "Supervisores";

            return View("Agregar_2Paso", model);
        }

        public ActionResult Agregar_Supervicion(SupervicionVista model)
        {
            model.Hs_Supervision = model.hora.ToString() + ":" + model.minuto.ToString();

            bool mreturn = supervicionesservicio.AgregarSuperviciones(model);

            return View("Index", supervicionesservicio.GetSuperviciones());
        }

        public ActionResult Modificar(int id_supervisor)
        {
            ISupervicionVista model = new SupervicionVista();

            model = supervicionesservicio.GetSupervicion(id_supervisor);
            model.Grupo = gruposservicio.GetGrupo(model.Id_Grupo);
            model.supervisor.Name = "BuSupervsores";
            model.supervisor.Tipo = "Supervisores";
            model.supervisor.Valor = model.NombrePersonaJuridica;


            return View(model);
        }

        public ActionResult Modificar_Supervicion(SupervicionVista model)
        {
            model.Hs_Supervision = model.hora.ToString() + ":" + model.minuto.ToString();

            bool mreturn = supervicionesservicio.ModificarSuperviciones(model);

            return View("Index", supervicionesservicio.GetSuperviciones());
        }

        public ActionResult Eliminar(int id_supervisor)
        {
            ISupervicionVista model = new SupervicionVista();

            model = supervicionesservicio.GetSupervicion(id_supervisor);
            model.Grupo = gruposservicio.GetGrupo(model.Id_Grupo);
            model.supervisor.Name = "BuSupervsores";
            model.supervisor.Tipo = "Supervisores";
            model.supervisor.Valor = model.NombrePersonaJuridica;


            return View(model);
        }

        public ActionResult Eliminar_Supervicion(SupervicionVista model)
        {

            bool mreturn = supervicionesservicio.EliminarSuperviciones(model.Id_Supervision, model.Nro_resolucion);

            return View("Index", supervicionesservicio.GetSuperviciones());
        }

    }
}
