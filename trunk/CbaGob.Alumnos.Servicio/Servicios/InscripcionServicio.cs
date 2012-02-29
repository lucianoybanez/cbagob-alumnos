using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class InscripcionServicio : IInscripcionServicio
    {
        private IInscripcionRepositorio inscripcionrepositorio;

        public InscripcionServicio()
        {
            inscripcionrepositorio = new InscripcionRepositorio();
        }

        public IInscripcionesVista GetAllInscripcion()
        {
            IInscripcionesVista inscripcionesvista = new InscripcionesVista();
            inscripcionesvista.ListaInscripciones = inscripcionrepositorio.GetAllInscripcion();
            return inscripcionesvista;
        }

        public IInscripcionesVista GetAllInscripcionByAlumno(int id_alumno)
        {
            try
            {
                IInscripcionesVista inscripcionesvista = new InscripcionesVista();

                IList<IInscripcion> ListaInscripcion = inscripcionrepositorio.GetAllInscripcionByAlumno(id_alumno);

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
            try
            {
                IInscripcionVista inscripcionvista = new InscripcionVista();
                IAlumnosRepositorio alumnosrepositorio = new AlumnosRepositorio();
                ICondicionCursoRepositorio condicionCursorepositorio = new CondicionCursoRepositorio();


                IInscripcion inscripcion = inscripcionrepositorio.GetInscripcion(id_inscripcion);
                inscripcionvista.Descripcion = inscripcion.Descripcion;
                inscripcionvista.Fecha = inscripcion.Fecha;
                inscripcionvista.Id_Alumno = inscripcion.Id_Alumno;
                inscripcionvista.Id_Grupo = inscripcion.Id_Condicion_Curso;
                inscripcionvista.Id_Inscipcion = inscripcion.IdInscripcion;

                inscripcionvista.ListaAlumnos = alumnosrepositorio.GetTodos();

                return inscripcionvista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarInscripcion(IInscripcion inscripcion)
        {
            try
            {
                return inscripcionrepositorio.AgregarInscripcion(inscripcion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarInscripcion(IInscripcion inscripcion)
        {
            try
            {
                return inscripcionrepositorio.ModificarInscripcion(inscripcion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarInscripcion(int id_inscripcion)
        {
            try
            {
                return inscripcionrepositorio.EliminarInscripcion(id_inscripcion);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
