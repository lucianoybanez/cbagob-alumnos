using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class ModalidadVista : IModalidadVista
    {
        public int IdModalidad { get; set; }
        [Required(ErrorMessage = "*")]
        public string NombreModalidad { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Resolucion { get; set; }
    }
}
