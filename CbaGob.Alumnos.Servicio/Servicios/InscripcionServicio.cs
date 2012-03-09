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
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class InscripcionServicio : BaseServicio, IInscripcionServicio
    {
        private IInscripcionRepositorio Inscripcionrepositorio;

        private ICondicionCursoRepositorio CondicionCursoRepositorio;

        private IAutenticacionServicio Aut;

        public InscripcionServicio(IInscripcionRepositorio inscripcionrepositorio, IAutenticacionServicio aut, ICondicionCursoRepositorio condicionCurso)
        {
            Inscripcionrepositorio = inscripcionrepositorio;
            Aut = aut;
            CondicionCursoRepositorio = condicionCurso;
        }

        public IInscripcionesVista GetAllInscripcion()
        {
            IInscripcionesVista inscripcionesvista = new InscripcionesVista();
            var pager = new Pager(Inscripcionrepositorio.GetAllInscripcion(),3, "FormIndexInscripciones", Aut.GetUrl("IndexPager", "Inscripciones"));
            inscripcionesvista.pager = pager;
            inscripcionesvista.ListaInscripciones = Inscripcionrepositorio.GetAllInscripcion(pager.Skip, pager.PageSize);
            return inscripcionesvista;
        }

        public IInscripcionesVista GetAllInscripcion(IPager pager)
        {
            IInscripcionesVista inscripcionesvista = new InscripcionesVista();
            inscripcionesvista.pager = pager;
            inscripcionesvista.ListaInscripciones = Inscripcionrepositorio.GetAllInscripcion(pager.Skip, pager.PageSize);
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

            if (inscripcion != null)
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

                    bool result = false;
                    var inscripcionModelo = Inscripcionrepositorio.GetInscripcion(inscripcion.Id_Condicion_Curso,inscripcion.Id_Alumno);
                    if (inscripcionModelo!=null)
                    {
                        inscripcion.IdInscripcion = inscripcionModelo.IdInscripcion;
                        result = Inscripcionrepositorio.ModificarInscripcion(inscripcion);
                    }
                    else
                    {
                        result = Inscripcionrepositorio.AgregarInscripcion(inscripcion);
                    }
                    if (!result)
                    {
                        base.AddError("Ocurrio un Error al agregar la Inscripcion. Verifique q no fue Inscripto anteriormente.");
                    }
                    return result;
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
            var inscripcion = Inscripcionrepositorio.GetInscripcion(vista.IdInscripcion);
            var condicion = CondicionCursoRepositorio.GetCondicion(inscripcion.Id_Condicion_Curso);
            int maxClases = condicion.CantidadClases;

            if (vista.ClasesAsistidas <= maxClases)
            {
                IPresentismo presentismo = new Presentismo()
                                          {
                                              ClasesAsistidas = vista.ClasesAsistidas,
                                              IdInscripcion = vista.IdInscripcion,
                                          };
                bool result = false;

                var dataPresentismo = Inscripcionrepositorio.GetPresentismo(vista.IdInscripcion);
                if (dataPresentismo!=null)
                {
                    presentismo.IdPresentismo = dataPresentismo.IdPresentismo;
                    result = Inscripcionrepositorio.ModificarPresentismo(presentismo);
                }
                else
                {
                    result = Inscripcionrepositorio.GuardarPresentismo(presentismo);
                }
                if (!result)
                {
                    base.AddError("Ocurrio un Error al guardar el Presentismo.");
                }
                return result;
            }
            else
            {
                base.AddError("La Cantidad de clases asistidas tiene q estar entre 0 y " + maxClases +".");
                return false;
            }


        }

        public IInscripcionPresentismoVista GetPresentismo(int idInscripcion)
        {
            var presentismo = Inscripcionrepositorio.GetPresentismo(idInscripcion);
            var inscripcion = Inscripcionrepositorio.GetInscripcion(idInscripcion);
            var condicion = CondicionCursoRepositorio.GetCondicion(inscripcion.Id_Condicion_Curso);
            int maxClases = condicion.CantidadClases;
            if (presentismo != null)
            {
                IInscripcionPresentismoVista vista = new InscripcionPresentismoVista()
                {
                    ClasesAsistidas = presentismo.ClasesAsistidas,
                    IdPresentismo = presentismo.IdPresentismo,
                    IdInscripcion = presentismo.IdInscripcion,
                    TotalClasesCurso = maxClases
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
