using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IProgramaRepositorio
    {
        IList<IPrograma> GetProgramas();
        IPrograma GetPrograma(int idprograma);
        int GetCountPrograma();
        IList<IPrograma> GetProgramas(int skip, int take);
        bool AgregarPrograma(IPrograma programa);
        bool ModificarPrograma(IPrograma programa);
        bool EliminarPrograma(int idPrograma, string nro_resolucion);

    }
}
