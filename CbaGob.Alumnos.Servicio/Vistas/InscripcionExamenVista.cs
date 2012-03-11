using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class InscripcionExamenVista : IInscripcionExamenVista
    {
        public IList<IExamen> Examenes { get; set; }
        public string Aprobo { get; set; }
        public decimal PromedioRequerdio { get; set; }
        public decimal PromedioAlumno { get; set; }
        public int ExamenesRequeridos { get; set; }
    }
}