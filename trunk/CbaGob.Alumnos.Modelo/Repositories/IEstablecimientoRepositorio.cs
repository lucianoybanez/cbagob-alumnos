using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IEstablecimientoRepositorio
    {
        IList<IEstablecimiento> GetTodos();
        IList<IEstablecimiento> GetEstablecimientoByInstitucion(int id_institucion);
        IEstablecimiento GetUno(int id_establecimiento);
        bool Agregar(IEstablecimiento establecimiento);
        bool Modificar(IEstablecimiento establecimiento);
        bool Eliminar(int id_establecimiento);
    }
}
