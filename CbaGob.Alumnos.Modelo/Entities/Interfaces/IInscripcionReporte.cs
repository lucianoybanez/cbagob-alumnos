using System;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IInscripcionReporte
    {
        string NombreAlumno { get; set; }
        string Telefono { get; set; }
        string CUIL { get; set; }
        DateTime? FechaNacimiento { get; set; }
        bool EstadoAsistencia { get; set; }
        int ClasesAsistidas { get; set; }
        decimal Notas { get; set; }
        int Sexo { get; set; }
    }
}