using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IInstitucionServicio
    {
        IList<IInstitucion> GetTodas();
        IInstitucion GetUna(Int32 INST_ID);
        bool AgregarInstitucion(IInstitucion pInstitucion);
        bool ModificarInstitucion(IInstitucion pInstitucion);
        bool EliminarInstitucion(Int32 INST_ID);
    }
}
