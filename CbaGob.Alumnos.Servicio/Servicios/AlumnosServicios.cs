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
            return alumnosrepositorio.GetTodosByNombreApellido(nombre, apellido);

        }

        public IList<IAlumnos> GetTodosByDni(string dni)
        {
            return alumnosrepositorio.GetTodosByDni(dni);
        }

        public IList<IAlumnos> GetTodosByCondicionCurso(int id_condicion_curso)
        {
            try
            {
                return alumnosrepositorio.GetTodosByCondicionCurso(id_condicion_curso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IAlumnos> GetTodosAlumnosSinGrupo(int id_condicion_curso)
        {
            try
            {
                return alumnosrepositorio.GetTodosAlumnosSinGrupo(id_condicion_curso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IAlumnos> GetTodosSinGrupo(int id_condicion_curso)
        {
            try
            {
                IList<IAlumnos> listretono = alumnosrepositorio.GetTodosByCondicionCurso(id_condicion_curso);
                return listretono;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IAlumnos> GetTodosAlumnosEnGrupo(int id_grupo, int id_condicion_curso)
        {
            try
            {
                IList<IAlumnos> listretono = alumnosrepositorio.GetTodosAlumnosEnGrupo(id_grupo, id_condicion_curso);
                return listretono;
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

        public bool AsiganraGrupo(int id_grupo, int id_alumno, int id_condicion_curso)
        {
            try
            {
                return alumnosrepositorio.AsiganraGrupo(id_grupo, id_alumno, id_condicion_curso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DesasignaraGrupo(int id_grupo, int id_alumno, int id_condicion_curso)
        {
            try
            {
                return alumnosrepositorio.DesasignaraGrupo(id_grupo, id_alumno, id_condicion_curso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
