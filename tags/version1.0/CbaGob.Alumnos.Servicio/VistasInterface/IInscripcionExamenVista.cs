using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IInscripcionExamenVista
    {
        IList<IExamen> Examenes { get; set; }
        string Aprobo { get; set; }
        decimal PromedioRequerdio { get; set; }
        decimal PromedioAlumno { get; set; }
        int ExamenesRequeridos { get; set; }
    }
}