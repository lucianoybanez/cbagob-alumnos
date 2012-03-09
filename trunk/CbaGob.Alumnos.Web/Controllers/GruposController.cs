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
    public class GruposController : Controller
    {
        private IGrupoServicio gruposervicio;
        private ICondicionesCursoServicio CondicionesCursoServicio;

        public GruposController(ICondicionesCursoServicio condicionesCursoServicio)
        {
            gruposervicio = new GrupoServicio();
            CondicionesCursoServicio = condicionesCursoServicio;
        }

        public ActionResult Index()
        {

            IGruposVista gruposvista = gruposervicio.GetAllGrupo();

            return View(gruposvista);
        }

        public ActionResult Agregar(int id_condicionCurso)
        {

            IGrupoVista model = new GrupoVista();

            model.Id_Condicion_Curso = id_condicionCurso;

            ICondicionCursoVista condicioncursovista = CondicionesCursoServicio.GetForModificacion(id_condicionCurso);

            model.Id_Institucion = condicioncursovista.IdInstitucion;

            model.Nombre_Curso = condicioncursovista.NombreCurso;

            model.Nombre_Institucion = condicioncursovista.NombeInstitucion;

            model.BuscadorEstablecimientos.Name = "BuscadorEstablecimientos";
            model.BuscadorEstablecimientos.Tipo = "Estableciminetos";
            model.BuscadorEstablecimientos.Relacionado = "Id_Institucion";

            return View(model);
        }

        public ActionResult Modificar(int id_grupo)
        {
            IGrupoVista model = new GrupoVista();

            model = gruposervicio.GetGrupo(id_grupo);

            ICondicionCursoVista condicioncursovista = CondicionesCursoServicio.GetForModificacion(model.Id_Condicion_Curso);

            model.Nombre_Curso = condicioncursovista.NombreCurso;

            model.Nombre_Institucion = condicioncursovista.NombeInstitucion;

            model.BuscadorEstablecimientos.Name = "BuscadorEstablecimientos";
            model.BuscadorEstablecimientos.Tipo = "Estableciminetos";
            model.BuscadorEstablecimientos.Relacionado = "Id_Institucion";
            model.BuscadorEstablecimientos.Valor = model.NombreEstablecimiento;

            return View(model);
        }

        public ActionResult Eliminar(int id_grupo)
        {
            IGrupoVista model = new GrupoVista();

            model = gruposervicio.GetGrupo(id_grupo);

            model.Nro_Resolucion = "";

            return View(model);
        }

        public ActionResult VerGrupo(int id_grupo)
        {
            IGrupoVista model = new GrupoVista();

            IAlumnosServicios alumnosservicios = new AlumnosServicios();

            model = gruposervicio.GetGrupo(id_grupo);

            model.ListaAlumnos = alumnosservicios.GetTodosAlumnosSinGrupo(model.Id_Condicion_Curso).ListaAlumno;

            model.ListaAlumnosInGrupo = alumnosservicios.GetTodosAlumnosEnGrupo(id_grupo, model.Id_Condicion_Curso).ListaAlumno;

            IDocentesServicio docentesservicio = new DocentesServicio();

            model.ListaDocentesNoGrupo = docentesservicio.GetDocentesNotInGrupo(id_grupo).ListaDocentes;

            model.ListaDocentesInGrupo = docentesservicio.GetDocentesInGrupo(id_grupo).ListaDocentes;

            return View("Ver", model);
        }

        public ActionResult AsignarAlumno(int id_grupo, int id_alumno, int id_condicon_curso)
        {
            IGrupoVista model = new GrupoVista();

            IAlumnosServicios alumnosservicios = new AlumnosServicios();

            model = gruposervicio.GetGrupo(id_grupo);

            bool mret = alumnosservicios.AsiganraGrupo(id_grupo, id_alumno, id_condicon_curso);

            model.ListaAlumnos = alumnosservicios.GetTodosAlumnosSinGrupo(model.Id_Condicion_Curso).ListaAlumno;

            model.ListaAlumnosInGrupo = alumnosservicios.GetTodosAlumnosEnGrupo(id_grupo, model.Id_Condicion_Curso).ListaAlumno;

            IDocentesServicio docentesservicio = new DocentesServicio();

            model.ListaDocentesNoGrupo = docentesservicio.GetDocentesNotInGrupo(id_grupo).ListaDocentes;

            model.ListaDocentesInGrupo = docentesservicio.GetDocentesInGrupo(id_grupo).ListaDocentes;

            return View("Ver", model);
        }

        public ActionResult DesasignarAlumno(int id_grupo , int id_alumno, int id_condicon_curso)
        {
            IGrupoVista model = new GrupoVista();

            IAlumnosServicios alumnosservicios = new AlumnosServicios();

            model = gruposervicio.GetGrupo(id_grupo);

            bool mret = alumnosservicios.DesasignaraGrupo(id_grupo, id_alumno, id_condicon_curso);

            model.ListaAlumnos = alumnosservicios.GetTodosAlumnosSinGrupo(model.Id_Condicion_Curso).ListaAlumno;

            model.ListaAlumnosInGrupo = alumnosservicios.GetTodosAlumnosEnGrupo(id_grupo, model.Id_Condicion_Curso).ListaAlumno;

            IDocentesServicio docentesservicio = new DocentesServicio();

            model.ListaDocentesNoGrupo = docentesservicio.GetDocentesNotInGrupo(id_grupo).ListaDocentes;

            model.ListaDocentesInGrupo = docentesservicio.GetDocentesInGrupo(id_grupo).ListaDocentes;

            return View("Ver", model);
        }

        public ActionResult AsignarDocente(int id_grupo, int id_docente)
        {
            IGrupoVista model = new GrupoVista();

            IAlumnosServicios alumnosservicios = new AlumnosServicios();

            IDocentesServicio docentesservicio = new DocentesServicio();

            model = gruposervicio.GetGrupo(id_grupo);

            bool mret = docentesservicio.AsignarDocentes(id_docente, id_grupo, model.Id_Condicion_Curso);

            model.ListaAlumnos = alumnosservicios.GetTodosAlumnosSinGrupo(model.Id_Condicion_Curso).ListaAlumno;

            model.ListaAlumnosInGrupo = alumnosservicios.GetTodosAlumnosEnGrupo(id_grupo, model.Id_Condicion_Curso).ListaAlumno;

            

            model.ListaDocentesNoGrupo = docentesservicio.GetDocentesNotInGrupo(id_grupo).ListaDocentes;

            model.ListaDocentesInGrupo = docentesservicio.GetDocentesInGrupo(id_grupo).ListaDocentes;

            return View("Ver", model);
        }

        public ActionResult DesasignarDocente(int id_grupo, int id_docente)
        {
            IGrupoVista model = new GrupoVista();

            IAlumnosServicios alumnosservicios = new AlumnosServicios();

            IDocentesServicio docentesservicio = new DocentesServicio();

            model = gruposervicio.GetGrupo(id_grupo);

            bool mret = docentesservicio.DesasignarDocentes(id_docente, id_grupo, model.Id_Condicion_Curso);

            model.ListaAlumnos = alumnosservicios.GetTodosAlumnosSinGrupo(model.Id_Condicion_Curso).ListaAlumno;

            model.ListaAlumnosInGrupo = alumnosservicios.GetTodosAlumnosEnGrupo(id_grupo, model.Id_Condicion_Curso).ListaAlumno;


            model.ListaDocentesNoGrupo = docentesservicio.GetDocentesNotInGrupo(id_grupo).ListaDocentes;

            model.ListaDocentesInGrupo = docentesservicio.GetDocentesInGrupo(id_grupo).ListaDocentes;

            return View("Ver", model);
        }
        
        [HttpPost]
        public ActionResult Agregar_Grupo(GrupoVista model)
        {

            model.Id_Condicion_Curso = model.Id_Condicion_Curso;
            model.Id_Horario = 1;
            bool mRet = gruposervicio.AgregarGrupo(model);

            return RedirectToAction("VerCondicionCurso", "CondicionesCurso", new { idCondicionCurso = model.Id_Condicion_Curso, IdInstitucion = model.Id_Institucion });
        }

        [HttpPost]
        public ActionResult Eliminar_Grupo(GrupoVista model)
        {
            bool mRet = gruposervicio.EliminarGrupo(model.Id_Grupo, model.Nro_Resolucion);

            return RedirectToAction("VerCondicionCurso", "CondicionesCurso", new { idCondicionCurso = model.Id_Condicion_Curso, IdInstitucion = model.Id_Institucion });
        }

        [HttpPost]
        public ActionResult Modificar_Grupo(GrupoVista model)
        {

            model.Id_Condicion_Curso = model.Id_Condicion_Curso;
            model.Id_Horario = 1;
            bool mRet = gruposervicio.ModificarGrupo(model);


            return RedirectToAction("VerCondicionCurso", "CondicionesCurso", new { idCondicionCurso = model.Id_Condicion_Curso, IdInstitucion = model.Id_Institucion });
        }

    }
}
