using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface ISupervicionesServicio:IBaseServicio
    {
        ISupervicionesVista GetSuperviciones();
        ISupervicionesVista GetSuperviciones(IPager Pager);
        ISupervicionVista GetSupervicion(int idsupervision);
        bool AgregarSuperviciones(ISupervicionVista supervicion);
        bool ModificarSuperviciones(ISupervicionVista supervicion);
        bool EliminarSuperviciones(int idsupervicion, string nro_resolucion);
    }
}
