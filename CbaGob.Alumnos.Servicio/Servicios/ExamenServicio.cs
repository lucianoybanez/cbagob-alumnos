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

        private ICursosRepositorio CursosRepositorio;

        private IGrupoRepositorio GrupoRepositorio;

        private IInscripcionRepositorio InscripcionRepositorio;


        public ExamenServicio(IExamenRepositorio examenRepositorio, ICursosRepositorio cursosRepositorio, IGrupoRepositorio grupoRepositorio, IInscripcionRepositorio inscripcionRepositorio)
        {
            ExamenRepositorio = examenRepositorio;
            CursosRepositorio = cursosRepositorio;
            GrupoRepositorio = grupoRepositorio;
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

            IExamenVista vista = new ExamenVista()
                                     {
                                         FechaExamen = examen.FechaExamen,
                                         IdExamen = examen.IdExamen,
                                         Nota = examen.Nota,
                                         NroExamen = examen.NroExamen,
                                         NombreAlumno = inscripcion.NombreAlumno,
                                         NombreCurso = inscripcion.NombreCurso,
                                         NombreEstadoCurso = inscripcion.NombreEstadoCurso,
                                         NombreInstitucion = inscripcion.NombreInstitucion,
                                         NombreModalidad = inscripcion.NombreModalidad,
                                         NombreNivel = inscripcion.NombreNivel,
                                         NombrePrograma = inscripcion.NombrePrograma,
                                         idInscripcion = inscripcion.IdInscripcion,
                                     };


            return vista;
        }

        public IExamenVista GetExamenVistaByInscripcion(int IdInscripcion)
        {
            var a = InscripcionRepositorio.GetInscripcion(IdInscripcion);
            IExamenVista vista = new ExamenVista()
                                     {
                                         NombreAlumno = a.NombreAlumno,
                                         NombreCurso = a.NombreCurso,
                                         NombreEstadoCurso = a.NombreEstadoCurso,
                                         NombreInstitucion = a.NombreInstitucion,
                                         NombreModalidad = a.NombreModalidad,
                                         NombreNivel = a.NombreNivel,
                                         NombrePrograma = a.NombrePrograma,
                                     };
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
                NroExamen = vista.NroExamen,
                Nota = vista.Nota,
                FechaExamen = vista.FechaExamen,
                IdExamen = vista.IdExamen
            };
            bool result = false;
            if (vista.Accion == "Agregar")
            {
                result = ExamenRepositorio.AgregarExamen(examen);
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

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}