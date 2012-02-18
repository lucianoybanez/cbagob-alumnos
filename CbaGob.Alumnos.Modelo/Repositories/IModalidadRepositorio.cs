using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IModalidadRepositorio
    {
        IList<IModalidad> GetModalidades();
        int AgregarModalidad(IModalidad modalidad);
        int ModificarModalidad(IModalidad modalidad);
        int EliminarModalidad(int idModalidad);
    }
}
