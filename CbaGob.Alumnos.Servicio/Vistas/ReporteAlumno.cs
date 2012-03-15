using System;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class ReporteAlumno : IReporteAlumno
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Cuil { get; set; }
        public decimal Asistencia { get; set; }
        public decimal NotaFinal { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CondicionLaboral { get; set; }
        public bool Baja { get; set; }
        public string PlanSocial { get; set; }
        public bool Aprobo { get; set; }
    }
}