using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IEstadoCurso : IComunDatos
    {
        int IdEstadoCurso { get; set; }
        string NombreEstadoCurso { get; set; }
    }
}
