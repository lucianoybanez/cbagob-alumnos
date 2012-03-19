using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class GruposController : BaseController
    {
        private IGrupoServicio gruposervicio;
        private ICondicionesCursoServicio CondicionesCursoServicio;
        private IHorarioServicio horarioservicio;
        private IAlumnosServicios alumnosservicios;
        private IDocentesServicio docentesservicio;


        public GruposController(IGrupoServicio gruposervicio, ICondicionesCursoServicio condicionesCursoServicio, IHorarioServicio horarioservicio, IAlumnosServicios alumnosservicios, IDocentesServicio docentesservicio)
        {
            this.gruposervicio = gruposervicio;
            CondicionesCursoServicio = condicionesCursoServicio;
            this.horarioservicio = horarioservicio;
            this.alumnosservicios = alumnosservicios;
            this.docentesservicio = docentesservicio;
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

            model = gruposervicio.GetGrupo(id_grupo);

            //model.ListaAlumnos = alumnosservicios.GetTodosAlumnosSinGrupo(model.Id_Condicion_Curso).ListaAlumno;

            //model.ListaAlumnosInGrupo = alumnosservicios.GetTodosAlumnosEnGrupo(id_grupo, model.Id_Condicion_Curso).ListaAlumno;

            //model.ListaDocentesNoGrupo = docentesservicio.GetDocentesNotInGrupo(id_grupo).ListaDocentes;

            //model.ListaDocentesInGrupo = docentesservicio.GetDocentesInGrupo(id_grupo).ListaDocentes;

            return View("Ver", model);
        }

        public ActionResult AsignarAlumno(int id_grupo, int id_alumno, int id_condicon_curso)
        {
            IGrupoVista model = new GrupoVista();

            bool mret = alumnosservicios.AsiganraGrupo(id_grupo, id_alumno, id_condicon_curso);

            if (mret == false)
            {
                base.AddError(alumnosservicios.GetErrors());
            }

            model = gruposervicio.GetGrupo(id_grupo);

            return View("Ver", model);
        }

        public ActionResult DesasignarAlumno(int id_grupo, int id_alumno, int id_condicon_curso)
        {
            IGrupoVista model = new GrupoVista();

            bool mret = alumnosservicios.DesasignaraGrupo(id_grupo, id_alumno, id_condicon_curso);

            model = gruposervicio.GetGrupo(id_grupo);


            //model.ListaAlumnos = alumnosservicios.GetTodosAlumnosSinGrupo(model.Id_Condicion_Curso).ListaAlumno;

            //model.ListaAlumnosInGrupo = alumnosservicios.GetTodosAlumnosEnGrupo(id_grupo, model.Id_Condicion_Curso).ListaAlumno;



            //model.ListaDocentesNoGrupo = docentesservicio.GetDocentesNotInGrupo(id_grupo).ListaDocentes;

            //model.ListaDocentesInGrupo = docentesservicio.GetDocentesInGrupo(id_grupo).ListaDocentes;

            return View("Ver", model);
        }

        public ActionResult AsignarDocente(int id_grupo, int id_docente, int id_condicon_curso)
        {
            IGrupoVista model = new GrupoVista();

            bool mret = docentesservicio.AsignarDocentes(id_docente, id_grupo, id_condicon_curso);

            if (mret == false)
            {
                base.AddError(docentesservicio.GetErrors());
            }

            model = gruposervicio.GetGrupo(id_grupo);

            //model.ListaAlumnos = alumnosservicios.GetTodosAlumnosSinGrupo(model.Id_Condicion_Curso).ListaAlumno;

            //model.ListaAlumnosInGrupo = alumnosservicios.GetTodosAlumnosEnGrupo(id_grupo, model.Id_Condicion_Curso).ListaAlumno;

            //model.ListaDocentesNoGrupo = docentesservicio.GetDocentesNotInGrupo(id_grupo).ListaDocentes;

            //model.ListaDocentesInGrupo = docentesservicio.GetDocentesInGrupo(id_grupo).ListaDocentes;

            return View("Ver", model);
        }

        public ActionResult DesasignarDocente(int id_grupo, int id_docente, int id_condicon_curso)
        {
            IGrupoVista model = new GrupoVista();

            bool mret = docentesservicio.DesasignarDocentes(id_docente, id_grupo, id_condicon_curso);

            model = gruposervicio.GetGrupo(id_grupo);


            //model.ListaAlumnos = alumnosservicios.GetTodosAlumnosSinGrupo(model.Id_Condicion_Curso).ListaAlumno;

            //model.ListaAlumnosInGrupo = alumnosservicios.GetTodosAlumnosEnGrupo(id_grupo, model.Id_Condicion_Curso).ListaAlumno;


            //model.ListaDocentesNoGrupo = docentesservicio.GetDocentesNotInGrupo(id_grupo).ListaDocentes;

            //model.ListaDocentesInGrupo = docentesservicio.GetDocentesInGrupo(id_grupo).ListaDocentes;

            return View("Ver", model);
        }

        public ActionResult AgregarHorario(int id_grupo, int id_horario)
        {
            IGrupoVista model = new GrupoVista();

            horarioservicio.AgregarHorarioAGrupo(id_grupo, id_horario);

            model = gruposervicio.GetGrupo(id_grupo);

            model.ListaAlumnos = alumnosservicios.GetTodosAlumnosSinGrupo(model.Id_Condicion_Curso).ListaAlumno;

            model.ListaAlumnosInGrupo = alumnosservicios.GetTodosAlumnosEnGrupo(id_grupo, model.Id_Condicion_Curso).ListaAlumno;

            model.ListaDocentesNoGrupo = docentesservicio.GetDocentesNotInGrupo(id_grupo).ListaDocentes;

            model.ListaDocentesInGrupo = docentesservicio.GetDocentesInGrupo(id_grupo).ListaDocentes;

            return View("Ver", model);
        }

        public ActionResult SacarHorario(int id_grupo, int id_horario)
        {
            IGrupoVista model = new GrupoVista();


            horarioservicio.SacarHorarioAGrupo(id_grupo, id_horario);

            model = gruposervicio.GetGrupo(id_grupo);


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
            bool mRet = gruposervicio.ModificarGrupo(model);


            return RedirectToAction("VerCondicionCurso", "CondicionesCurso", new { idCondicionCurso = model.Id_Condicion_Curso, IdInstitucion = model.Id_Institucion });
        }

    }
}
