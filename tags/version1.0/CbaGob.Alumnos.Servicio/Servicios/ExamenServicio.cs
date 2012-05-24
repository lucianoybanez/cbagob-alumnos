using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class ExamenServicio : BaseServicio, IExamenServicio
    {
        private IExamenRepositorio ExamenRepositorio;

        private ICondicionCursoRepositorio CondicionCursoRepositorio;

        private IInscripcionRepositorio InscripcionRepositorio;


        public ExamenServicio(IExamenRepositorio examenRepositorio, IInscripcionRepositorio inscripcionRepositorio, ICondicionCursoRepositorio condicionCursoRepositorio)
        {
            ExamenRepositorio = examenRepositorio;
            CondicionCursoRepositorio = condicionCursoRepositorio;
            InscripcionRepositorio = inscripcionRepositorio;
        }

        public IExamenVista GetExamenVista()
        {
            IExamenVista vista = new ExamenVista();
            return vista;
        }

        public IExamenVista GetExamenVista(int IdExamen)
        {

            var examen = ExamenRepositorio.GetExamen(IdExamen);
            var inscripcion = InscripcionRepositorio.GetInscripcion(examen.IdInscripcion);
            var condicionCurso = CondicionCursoRepositorio.GetCondicion(inscripcion.Id_Condicion_Curso);

            IExamenVista vista = new ExamenVista()
                                     {
                                         FechaExamen = examen.FechaExamen,
                                         IdExamen = examen.IdExamen,
                                         Nota = examen.Nota,
                                         NombreAlumno = inscripcion.NombreAlumno,
                                         NombreCurso = inscripcion.NombreCurso,
                                         NombreEstadoCurso = inscripcion.NombreEstadoCurso,
                                         NombreInstitucion = inscripcion.NombreInstitucion,
                                         NombreModalidad = inscripcion.NombreModalidad,
                                         NombreNivel = inscripcion.NombreNivel,
                                         NombrePrograma = inscripcion.NombrePrograma,
                                         idInscripcion = inscripcion.IdInscripcion,
                                     };
            vista.NroExamen.Combo = ComboHelper.GetComboParaCantidadExamenes(condicionCurso.CantidadExamenes);
            vista.NroExamen.Selected = examen.NroExamen.ToString();
            return vista;
        }

        public IExamenVista GetExamenVistaByInscripcion(int IdInscripcion)
        {
            var inscripcion = InscripcionRepositorio.GetInscripcion(IdInscripcion);
            var condicionCurso = CondicionCursoRepositorio.GetCondicion(inscripcion.Id_Condicion_Curso);



            IExamenVista vista = new ExamenVista()
                                     {
                                         NombreAlumno = inscripcion.NombreAlumno,
                                         NombreCurso = inscripcion.NombreCurso,
                                         NombreEstadoCurso = inscripcion.NombreEstadoCurso,
                                         NombreInstitucion = inscripcion.NombreInstitucion,
                                         NombreModalidad = inscripcion.NombreModalidad,
                                         NombreNivel = inscripcion.NombreNivel,
                                         NombrePrograma = inscripcion.NombrePrograma,
                                     };

            vista.NroExamen.Combo = ComboHelper.GetComboParaCantidadExamenes(condicionCurso.CantidadExamenes);

            return vista;

        }

        public IExamenVista GetExamenVistaCambioComboGrupo(IExamenVista vista)
        {

            return vista;
        }

        public IExamenesVista GetExamanes()
        {
            IExamenesVista vista = new ExamenesVista();
            vista.Examens = ExamenRepositorio.GetExamenes();
            return vista;
        }

        public bool GuardarExamen(IExamenVista vista)
        {
            IExamen examen = new Examen()
            {
                IdInscripcion = vista.idInscripcion,
                NroExamen = int.Parse(vista.NroExamen.Selected),
                Nota = vista.Nota,
                FechaExamen = vista.FechaExamen,
                IdExamen = vista.IdExamen
            };
            bool result = false;


            if (vista.Accion == "Agregar")
            {
                IExamen examenModel = ExamenRepositorio.GetExamen(vista.idInscripcion, int.Parse(vista.NroExamen.Selected));
                if (examenModel != null)
                {
                    examen.IdExamen = examenModel.IdExamen;
                    vista.Accion = "Modificar";
                }
                else
                {
                    result = ExamenRepositorio.AgregarExamen(examen);
                }
              
            }
            if (vista.Accion == "Modificar")
            {
                result = ExamenRepositorio.ModificarExamen(examen);
            }
            if (!result)
            {
                base.AddError("Se produjo un error al guardar el examen.");
                base.AddError("Verifique q el Examen no este cargado.");
            }
            return result;
        }

        public bool EliminarExamen(int IdExamen)
        {
            if (!ExamenRepositorio.EliminarExamen(IdExamen))
            {
                base.AddError("Ocurrio un error no se pudo eliminar el examen.");
                return false;
            }
            return true;
        }

        public IList<IExamen> GetExamenes(int IdInscripcion)
        {
            return ExamenRepositorio.GetExamenesByInscripcion(IdInscripcion);
        }

        public IExamenVista GetOnlyCombo(IExamenVista vista)
        {
            var inscripcion = InscripcionRepositorio.GetInscripcion(vista.idInscripcion);
            var condicionCurso = CondicionCursoRepositorio.GetCondicion(inscripcion.Id_Condicion_Curso);
            vista.NroExamen.Combo = ComboHelper.GetComboParaCantidadExamenes(condicionCurso.CantidadExamenes);
            return vista;
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}