using System;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public class InscripcionReporte : IInscripcionReporte
    {
        public string NombreAlumno { get; set; }
        public string Telefono { get; set; }
        public string CUIL { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool EstadoAsistencia { get; set; }
        public int ClasesAsistidas { get; set; }
        public decimal Notas { get; set; }
        public int Sexo { get; set; }
    }
}