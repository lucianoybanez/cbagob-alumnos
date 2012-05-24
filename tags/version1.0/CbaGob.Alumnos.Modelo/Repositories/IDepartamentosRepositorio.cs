using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IDepartamentosRepositorio
    {
        IList<IDepartamentos> GetTodasbyProvincia(string IdProvincia);
        IDepartamentos GetUno(int IdDepartamento);
    }
}
