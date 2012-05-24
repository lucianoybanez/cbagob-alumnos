using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IModalidad : IComunDatos
    {
        int IdModalidad { get; set; }
        string NombreModalidad { get; set; }
        string Nro_Resolucion { get; set; }

    }
}
