using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IAlumnosServicios : IBaseServicio
    {
        IList<IAlumnos> GetTodos();
        IList<IAlumnos> GetTodosByNombreApellido(string nombre, string apellido);
        IList<IAlumnos> GetTodosByDni(string dni);
        IList<IAlumnos> GetTodosByCondicionCurso(int id_condicion_curso);
        IList<IAlumnos> GetTodosAlumnosSinGrupo(int id_condicion_curso);
        IList<IAlumnos> GetTodosSinGrupo(int id_condicion_curso);
        IList<IAlumnos> GetTodosAlumnosEnGrupo(int id_grupo, int id_condicion_curso);
        IAlumnos GetUno(int id_alumno);
        bool Agregar(IAlumnos alumno);
        bool Modificar(IAlumnos alumno);
        bool Eliminar(int id_alumno);
        bool AsiganraGrupo(int id_grupo, int id_alumno, int id_condicion_curso);
        bool DesasignaraGrupo(int id_grupo, int id_alumno, int id_condicion_curso);
    }
}
