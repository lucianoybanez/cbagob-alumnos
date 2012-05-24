using System;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IReporteAlumno
    {
        string Nombre { get; set; }
        string Telefono { get; set; }
        string Cuil { get; set; }
        decimal Asistencia { get; set; }
        decimal NotaFinal { get; set; }
        DateTime? FechaNacimiento { get; set; }
        string CondicionLaboral { get; set; }
        bool Estado { get; set; }
        string PlanSocial { get; set; }
        bool Aprobo { get; set; }

    }
}