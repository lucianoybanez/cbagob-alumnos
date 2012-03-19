using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IAlumnosRepositorio
    {
        IList<IAlumnos> GetTodos();
        IList<IAlumnos> GetTodos(int skip, int take);
        int GetCountAlumnos();
        IList<IAlumnos> GetTodosByNombreApellido(string nombre, string apellido);
        IList<IAlumnos> GetTodosByDni(string dni);
        IList<IAlumnos> GetTodosByCondicionCurso(int id_condicion_curso);
        IList<IAlumnos> GetTodosAlumnosSinGrupo(int id_condicion_curso);
        IList<IAlumnos> GetTodosAlumnosEnGrupo(int id_grupo, int id_condicion_curso);
        IAlumnos GetUno(int id_alumno);
        bool Agregar(IAlumnos alumno);
        bool Modificar(IAlumnos alumno);
        bool Eliminar(int id_alumno, string nro_resolucion);
        bool AsiganraGrupo(int id_grupo, int id_alumno, int id_condicion_curso);
        bool DesasignaraGrupo(int id_grupo, int id_alumno, int id_condicion_curso);
        IList<IAlumnos> BuscarAlumnos(string nombre, string apellido, string dni, string cuil);
        IList<IAlumnos> BuscarAlumnos(string nombre, string apellido, string dni, string cuil, int skip, int take);
    }
}
