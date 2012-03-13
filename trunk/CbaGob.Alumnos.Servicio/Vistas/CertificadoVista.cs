using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class CertificadoVista : ICertificadoVista
    {
        [Required]
        public string NombreAlumno { get; set; }
        [Required]
        [AllowHtml]
        public string Texto { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public string ImagenSistemaPath { get; set; }
        public string ImagenEscudoPath { get; set; }
        public string dni { get; set; }
    }
}