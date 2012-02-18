using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IProgramaRepositorio
    {
        IList<IPrograma> GetProgramas();
        int AgregarPrograma(IPrograma programa);
        int ModificarPrograma(IPrograma programa);
        int EliminarPrograma(int idPrograma);
    }
}
