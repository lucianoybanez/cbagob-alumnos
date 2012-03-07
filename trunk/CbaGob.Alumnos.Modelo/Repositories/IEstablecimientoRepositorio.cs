using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IEstablecimientoRepositorio
    {
        IList<IEstablecimiento> GetAllEstablecimiento();
        IList<IEstablecimiento> GetAllEstablecimientoByInstitucion(int id_institucion);
        IEstablecimiento GetEstablecimiento(int id_establecimiento);
        bool AgregarEstablecimiento(IEstablecimiento establecimiento);
        bool ModificarEstablecimiento(IEstablecimiento establecimiento);
        bool EliminarEstablecimiento(int id_establecimiento, string nroresolucion);
    }
}
