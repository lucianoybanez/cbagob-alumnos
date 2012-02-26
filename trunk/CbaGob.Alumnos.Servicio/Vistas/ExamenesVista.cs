using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class ExamenesVista : IExamenesVista
    {
        public IList<IExamen> Examens { get; set; }
    }
}