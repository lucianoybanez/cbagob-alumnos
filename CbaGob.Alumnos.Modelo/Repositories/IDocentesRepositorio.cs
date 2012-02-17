using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IDocentesRepositorio
    {
        IList<IDocentes> GetTodos();
        IList<IDocentes> GetTodosByRazonSocial(string razonsocial);
        IDocentes GetUno(int id_docente);
        bool Agregar(IDocentes docente);
        bool Modificar(IDocentes docente);
        bool Eliminar(int id_docente);
    }
}
