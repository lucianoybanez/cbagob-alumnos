using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface ICargosRepositorio
    {
        IList<ICargos> GetTodosCargos();
        ICargos GetCargo(int idcargo);
        int GetCargosCount();
        IList<ICargos> GetTodosCargos(int skip, int take);
        bool AgregarCargo(ICargos cargo);
        bool ModificarCargo(ICargos cargo);
        bool EliminarCargo(int id_cargo, string nro_resolucion);
    }
}
