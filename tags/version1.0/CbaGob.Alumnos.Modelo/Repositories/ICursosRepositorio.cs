using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface ICursosRepositorio
    {
        IList<ICursos> GetTodosbyInstitucion(int IdInstitucion);
        IList<ICursos> GetTodos();
        IList<ICursos> GetTodos(int skip, int take);
        int GetCountCursos();
        ICursos GetUno(int IdCurso);
        bool Agregar(ICursos pCursos);
        bool Modificar(ICursos pCursos);
        bool Eliminar(int IdCurso, string nroresolucion);
    }
}
