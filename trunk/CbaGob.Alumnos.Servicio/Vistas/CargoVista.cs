using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class CargoVista : ICargoVista
    {
        public int Id_Cargo { get; set; }
        [Required(ErrorMessage = "*")]
        public string N_Cargo { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Resolucion { get; set; }
    }
}
