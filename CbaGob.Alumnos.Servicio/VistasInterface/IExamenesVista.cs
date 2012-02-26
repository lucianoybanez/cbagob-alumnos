using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IExamenesVista
    {
        IList<IExamen> Examens { get; set; }
    }
}
