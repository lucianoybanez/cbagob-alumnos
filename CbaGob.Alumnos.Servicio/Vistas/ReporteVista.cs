using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.Vistas;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class ReporteVista : IReporteVista
    {
        public ReporteVista()
        {
            Alumnos = new List<IReporteAlumno>();
        }

        public string NombreReporte { get; set; }
        public string NombreInstitucion { get; set; }
        public string NombreCurso { get; set; }
        public string Expediente { get; set; }
        public string Resolucion { get; set; }
        public string Codigo { get; set; }
        public int Varones { get; set; }
        public int Mujeres { get; set; }
        public int TotalHyM { get; set; }
        public DateTime Fecha { get; set; }
        public IList<IReporteAlumno> Alumnos { get; set; }
        public string PathGobiernoImagen1 { get; set; }
        public string PathGobiernoImagen2 { get; set; }
    }
}