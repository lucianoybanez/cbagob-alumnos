using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface ICajaChicaRepositorio
    {
        IList<ICajaChica> GetCajaChicas();
        IList<ICajaChica> GetCajaChicasByInstitucion(int id_institucion);
        ICajaChica GetCajaChica(int idcajachica);
        IList<IEstadoCajaChica> GetEstadoCajaChicas(); 
        bool AgregarCajaChica(ICajaChica cajachica);
        bool ModificaCajaChica(ICajaChica cajachica);
        bool EliminarCajaChica(int idcajachica);
    }
}
