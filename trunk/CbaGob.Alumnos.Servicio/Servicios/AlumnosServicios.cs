using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class AlumnosServicios : IAlumnosServicios
    {
        private IAlumnosRepositorio alumnosrepositorio;

        public AlumnosServicios()
        {
            alumnosrepositorio = new AlumnosRepositorio();
        }

        public IList<IAlumnos> GetTodos()
        {
            try
            {
                return alumnosrepositorio.GetTodos();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public IList<IAlumnos> GetTodosByNombreApellido(string nombre, string apellido)
        {
            try
            {
                return alumnosrepositorio.GetTodosByNombreApellido(nombre, apellido);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IAlumnos> GetTodosByDni(string dni)
        {
            try
            {
                return alumnosrepositorio.GetTodosByDni(dni);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IAlumnos GetUno(int id_alumno)
        {
            try
            {
                return alumnosrepositorio.GetUno(id_alumno);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Agregar(IAlumnos alumno)
        {
            try
            {
                return alumnosrepositorio.Agregar(alumno);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Modificar(IAlumnos alumno)
        {
            try
            {
                return alumnosrepositorio.Modificar(alumno);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Eliminar(int id_alumno)
        {
            try
            {
                return alumnosrepositorio.Eliminar(id_alumno);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
