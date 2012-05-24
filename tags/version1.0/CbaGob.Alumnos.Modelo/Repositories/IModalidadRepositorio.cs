using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IModalidadRepositorio
    {
        IList<IModalidad> GetModalidades();
        IList<IModalidad> GetModalidades(int skip, int take);
        int GetCountModalidad();
        IModalidad GetModalidad(int id_modalidad);
        bool AgregarModalidad(IModalidad modalidad);
        bool ModificarModalidad(IModalidad modalidad);
        bool EliminarModalidad(int idModalidad, string nro_resolucion);

    }
}
