using System;
using System.ComponentModel.DataAnnotations;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class ExamenVista : IExamenVista
    {
        public ExamenVista()
        {
            Cursos = new ComboBox();
        }

        public string Accion { get; set; }
        public int IdExamen { get; set; }
        public DateTime FechaExamen { get; set; }
        public int NroExamen { get; set; }
        [Required]
        public decimal Nota { get; set; }
        public IComboBox Cursos { get; set; }
        public string NombreAlumno { get; set; }
    }
}