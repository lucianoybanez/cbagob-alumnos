using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface ICursosServicios : IBaseServicio
    {
        IList<ICursos> GetTodosbyInstitucion(int IdInstitucion);
        IList<ICursos> GetTodos();
        ICursos GetUno(int IdCurso);
        ICursosVista GetUnaVista(int id);
        bool Agregar(ICursos pCursos);
        bool Modificar(ICursos pCursos);
        bool Eliminar(int IdCurso);
    }
}
