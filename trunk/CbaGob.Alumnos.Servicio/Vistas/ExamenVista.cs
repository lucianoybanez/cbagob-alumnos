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
            Grupos = new ComboBox();
            Alumnos = new ComboBox();
        }

        public string Accion { get; set; }
        public int IdExamen { get; set; }
        [Required]
        public DateTime FechaExamen { get; set; }
        [Required]
        public int NroExamen { get; set; }
        [Required]
        public decimal Nota { get; set; }
        public IComboBox Grupos { get; set; }
        public IComboBox Alumnos { get; set; }
    }
}