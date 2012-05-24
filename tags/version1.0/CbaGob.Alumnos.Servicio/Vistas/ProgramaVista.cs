using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class ProgramaVista : IProgramaVista
    {
        public int IdPrograma { get; set; }
        [Required(ErrorMessage = "*")]
        public string NombrePrograma { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_resolucion { get; set; }
    }
}
