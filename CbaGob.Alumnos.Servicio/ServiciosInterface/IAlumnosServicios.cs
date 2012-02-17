using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IAlumnosServicios
    {
        IList<IAlumnos> GetTodos();
        IList<IAlumnos> GetTodosByNombreApellido(string nombre, string apellido);
        IList<IAlumnos> GetTodosByDni(string dni);
        IAlumnos GetUno(int id_alumno);
        bool Agregar(IAlumnos alumno);
        bool Modificar(IAlumnos alumno);
        bool Eliminar(int id_alumno);
    }
}
