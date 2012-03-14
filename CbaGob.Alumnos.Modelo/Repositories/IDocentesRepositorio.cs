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
        IList<IDocentes> GetDocentesNotInGrupo(int id_grupo);
        IList<IDocentes> GetDocentesInGrupo(int id_grupo);
        IDocentes GetUno(int id_docente);
        bool Agregar(IDocentes docente);
        bool Modificar(IDocentes docente);
        bool Eliminar(int id_docente, string nroresolucion);
        bool AsignarDocentes(int id_docente, int id_grupo, int id_condicion_curso);
        bool DesasignarDocentes(int id_docente, int id_grupo, int id_condicion_curso);
        IList<IDocentes> BuscarDocente(string razonsocial, string cuit_cuil);
    }
}
