using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IAlumnosServicios : IBaseServicio
    {
        IAlumnosVista GetTodos();
        IAlumnosVista GetTodosByNombreApellido(string nombre, string apellido);
        IAlumnosVista GetTodosByDni(string dni);
        IAlumnosVista GetTodosByCondicionCurso(int id_condicion_curso);
        IAlumnosVista GetTodosAlumnosSinGrupo(int id_condicion_curso);
        IAlumnosVista GetTodosSinGrupo(int id_condicion_curso);
        IAlumnosVista GetTodosAlumnosEnGrupo(int id_grupo, int id_condicion_curso);
        IAlumnosVista GetUno(int id_alumno);
        IAlumnosVista GetIndex();
        bool Agregar(IAlumnosVista alumno);
        bool Modificar(IAlumnosVista alumno);
        bool Eliminar(int id_alumno, string nro_resolucion);
        bool AsiganraGrupo(int id_grupo, int id_alumno, int id_condicion_curso);
        bool DesasignaraGrupo(int id_grupo, int id_alumno, int id_condicion_curso);
        IAlumnosVista BuscarAlumnos(string nombre, string apellido, string dni, string cuil);
    }

}
