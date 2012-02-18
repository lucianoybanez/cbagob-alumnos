using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface INivel : IComunDatos
    {
        int IdNivel { get; set; }
        string NombreNivel { get; set; }
    }
}
