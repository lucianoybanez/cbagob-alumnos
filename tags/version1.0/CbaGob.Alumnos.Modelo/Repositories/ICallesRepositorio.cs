using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface ICallesRepositorio
    {
        IList<ICalles> GetTodasBYProDepLoca(string IdProvincia, int IdDepartamento, int IdLocalidad);
        ICalles GetUno(int IdCalle);
    }
}
