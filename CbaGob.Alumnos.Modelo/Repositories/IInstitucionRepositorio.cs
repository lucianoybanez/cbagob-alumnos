using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IInstitucionRepositorio
    {
        IList<IInstitucion> GetInstituciones();
        IList<IInstitucion> GetInstituciones(int skip, int take);
        int GetCountInstituciones();
        IInstitucion GetInstitucion(Int32 IdInstitucion);
        bool AgregarInstitucion(IInstitucion pInstitucion);
        bool ModificarInstitucion(IInstitucion pInstitucion);
        bool EliminarInstitucion(Int32 IdInstitucion, string nro_resolucion);
        IList<IInstitucion> BuscarInstitucion(string nombreinstitucion);
    } 
}
