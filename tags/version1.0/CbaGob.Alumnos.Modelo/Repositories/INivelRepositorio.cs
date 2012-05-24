using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface INivelRepositorio
    {
        IList<INivel> GetNiveles();
        int AgregarNivel(INivel nivel);
        int ModificarNivel(INivel nivel);
        int EliminarNivel(int idNivel);
    }
}
