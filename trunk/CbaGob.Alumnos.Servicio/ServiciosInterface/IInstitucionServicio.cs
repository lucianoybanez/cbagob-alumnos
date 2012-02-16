using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IInstitucionServicio
    {
        IList<IInstitucion> GetTodas();
        InstitucionVista GetIndex();
        IInstitucion GetUna(Int32 IdInstitucion);
        IInstitucionVista GetUnaVista(Int32 IdInstitucion);
        bool AgregarInstitucion(IInstitucion pInstitucion);
        bool ModificarInstitucion(IInstitucion pInstitucion);
        bool EliminarInstitucion(Int32 IdInstitucion);
    }
}
