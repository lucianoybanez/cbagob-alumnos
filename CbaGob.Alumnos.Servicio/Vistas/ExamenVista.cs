using System;
using System.ComponentModel.DataAnnotations;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class ExamenVista : IExamenVista
    {
        public  int idInscripcion { get; set; }
        public string Accion { get; set; }
        public int IdExamen { get; set; }
        [Required]
        public DateTime FechaExamen { get; set; }
        [Required]
        [Range(1, 20)]
        public int NroExamen { get; set; }
        [Required]
        [Range(1, 10)]
        public decimal Nota { get; set; }

        public string NombreInstitucion { get; set; }
        public string NombreEstadoCurso { get; set; }
        public string NombreCurso { get; set; }
        public string NombreNivel { get; set; }
        public string NombreModalidad { get; set; }
        public string NombrePrograma { get; set; }
        public string NombreAlumno { get; set; }
    }
}