using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class InscripcionVista : IInscripcionVista
    {
        public string Accion { get; set; }
        public int IdCondicionCurso { get; set; }
        public int IdInscripcion { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string NombreInstitucion { get; set; }
        public string NombreEstadoCurso { get; set; }
        public string NombreCurso { get; set; }
        public string NombreNivel { get; set; }
        public string NombreModalidad { get; set; }
        public string NombrePrograma { get; set; }
        public int IdAlumno { get; set; }
        [Required]
        public string NombreAlumno { get; set; }

        public string NumeroResolucion { get; set; }

        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public IInscripcionExamenVista examens { get; set; }
        public IInscripcionPresentismoVista Presentismo { get; set; }
    }
}
