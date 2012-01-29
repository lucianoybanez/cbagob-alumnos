using System.Collections.Generic;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IRol : IComunDatos
    {
        int RolId { get; set; }
        string RolTipo { get; set; }
    }
}
