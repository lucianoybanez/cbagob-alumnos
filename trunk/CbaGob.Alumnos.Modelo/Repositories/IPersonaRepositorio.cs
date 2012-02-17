using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IPersonaRepositorio
    {
        IList<IPersona> GetTodas();
        IList<IPersona> GetTodasByNombre(string nombre);
        IList<IPersona> GetPersonasDni(int dni);
    }
}
