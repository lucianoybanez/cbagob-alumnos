using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class InscripcionServicio : BaseServicio, IInscripcionServicio
    {
        private IInscripcionRepositorio Inscripcionrepositorio;

        private IInstitucionRepositorio InstitucionRepositorio;

        private ICursosRepositorio CursosRepositorio;

        private IEstadoCursoRepositorio EstadoCursoRepositorio;

        private INivelRepositorio NivelRepositorio;

        private IModalidadRepositorio ModalidadRepositorio;

        private ICondicionCursoRepositorio CondicionCursoRepositorio;

        private IProgramaRepositorio ProgramaRepositorio;


        public InscripcionServicio(IInscripcionRepositorio inscripcionrepositorio, IInstitucionRepositorio institucionRepositorio, ICursosRepositorio cursosRepositorio, IEstadoCursoRepositorio estadoCursoRepositorio, INivelRepositorio nivelRepositorio, IModalidadRepositorio modalidadRepositorio, ICondicionCursoRepositorio condicionCursoRepositorio, IProgramaRepositorio programaRepositorio)
        {
            Inscripcionrepositorio = inscripcionrepositorio;
            InstitucionRepositorio = institucionRepositorio;
            CursosRepositorio = cursosRepositorio;
            EstadoCursoRepositorio = estadoCursoRepositorio;
            NivelRepositorio = nivelRepositorio;
            ModalidadRepositorio = modalidadRepositorio;
            CondicionCursoRepositorio = condicionCursoRepositorio;
            ProgramaRepositorio = programaRepositorio;
        }

        public IInscripcionesVista GetAllInscripcion()
        {
            IInscripcionesVista inscripcionesvista = new InscripcionesVista();
            inscripcionesvista.ListaInscripciones = Inscripcionrepositorio.GetAllInscripcion();
            return inscripcionesvista;
        }

        public IInscripcionesVista GetAllInscripcionByAlumno(int id_alumno)
        {
            try
            {
                IInscripcionesVista inscripcionesvista = new InscripcionesVista();

                IList<IInscripcion> ListaInscripcion = Inscripcionrepositorio.GetAllInscripcionByAlumno(id_alumno);

                inscripcionesvista.ListaInscripciones = ListaInscripcion;

                return inscripcionesvista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IInscripcionVista GetInscripcion(int id_inscripcion)
        {

            var inscripcion = Inscripcionrepositorio.GetInscripcion(id_inscripcion);

            if (inscripcion!=null)
            {
                IInscripcionVista vista = new InscripcionVista()
                {
                    Descripcion = inscripcion.Descripcion,
                    Fecha = inscripcion.Fecha,
                    IdAlumno = inscripcion.Id_Alumno,
                    IdCondicionCurso = inscripcion.Id_Condicion_Curso,
                    IdInscripcion = inscripcion.IdInscripcion,
                    NombreAlumno = inscripcion.NombreAlumno,
                    NombreCurso = inscripcion.NombreCurso,
                    NombreEstadoCurso = inscripcion.NombreEstadoCurso,
                    NombreInstitucion = inscripcion.NombreInstitucion,
                    NombreModalidad = inscripcion.NombreModalidad,
                    NombreNivel = inscripcion.NombreNivel,
                    NombrePrograma = inscripcion.NombrePrograma
                };
                return vista;
            }
            return new InscripcionVista();
        }

        public bool AgregarInscripcion(IInscripcionVista vista)
        {
            if (vista.IdCondicionCurso != 0)
            {
                if (vista.IdAlumno != 0)
                {
                    IInscripcion inscripcion = new Inscripcion();
                    inscripcion.Id_Condicion_Curso = vista.IdCondicionCurso;
                    inscripcion.Id_Alumno = vista.IdAlumno;
                    inscripcion.Fecha = vista.Fecha;
                    inscripcion.Descripcion = vista.Descripcion;
                    bool result = Inscripcionrepositorio.AgregarInscripcion(inscripcion);
                    if (result)
                    {
                        return true;
                    }
                    else
                    {
                        base.AddError("Ocurrio un Error al agregar la Inscripcion. Verifique q no fue Inscripto anteriormente.");
                    }
                }
                else
                {
                    base.AddError("Debe Seleccionar un Alumno");
                }
            }
            else
            {
                base.AddError("Debe Seleccionar un Curso asginado a una Institucion");
            }
            return false;


        }

        public bool ModificarInscripcion(IInscripcionVista inscripcion)
        {

            //return Inscripcionrepositorio.ModificarInscripcion(inscripcion);
            return true;
        }

        public bool EliminarInscripcion(int id_inscripcion)
        {
            bool result = Inscripcionrepositorio.EliminarInscripcion(id_inscripcion);

            if (!result)
            {
                base.AddError("Ocurrio un error al Eliminar la Inscripcion");
            }

            return result;

        }

        public bool GuardarPresentismo(InscripcionPresentismoVista vista)
        {
            IPresentismo presentismo = new Presentismo()
                                           {
                                               ClasesAsistidas = vista.ClasesAsistidas,
                                               IdInscripcion = vista.IdInscripcion,
                                               IdPresentismo = vista.IdInscripcion
                                           };
            bool result = false;

            bool alta = Inscripcionrepositorio.GuardarPresentismo(presentismo);

            if (!alta)
            {
                result = Inscripcionrepositorio.ModificarPresentismo(presentismo);
            }
            else
            {
                result = true;
            }

            if (!result)
            {
                base.AddError("Ocurrio un Error al guardar el Presentismo.");
            }
            return result;
        }

        public IInscripcionPresentismoVista GetPresentismo(int idInscripcion)
        {
            var a = Inscripcionrepositorio.GetPresentismo(idInscripcion);
            if (a!=null)
            {
                IInscripcionPresentismoVista vista = new InscripcionPresentismoVista()
                {
                    ClasesAsistidas = a.ClasesAsistidas,
                    IdPresentismo = a.IdPresentismo,
                    IdInscripcion = a.IdInscripcion,
                    PorcentajePresentismo = a.PorcentajePresentismo
                };
                return vista;
            }
           
            return new InscripcionPresentismoVista();
        }

        public IInscripcionesVista GetAllInscripcionBy(string nombre, string apellido, string dni, string institucion)
        {
            IInscripcionesVista vista = new InscripcionesVista();
            vista.ListaInscripciones = Inscripcionrepositorio.GetAllInscripcionBy(nombre, apellido, dni, institucion);

            return vista;
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}
