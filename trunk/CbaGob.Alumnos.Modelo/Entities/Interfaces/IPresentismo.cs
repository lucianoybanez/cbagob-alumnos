using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IPresentismo : IComunDatos
    {
        int IdPresentismo { get; set; }
        int IdInscripcion { get; set; }
        int ClasesAsistidas { get; set; }
        decimal PorcentajePresentismo { get; set; }
        
    }
}
