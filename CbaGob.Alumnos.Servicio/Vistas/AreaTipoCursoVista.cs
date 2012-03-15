using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class AreaTipoCursoVista : IAreaTipoCursoVista
    {
        public int Id_Area_Tipo_Curso { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nombre_AreaTipoCurso { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Resolucion { get; set; }
    }
}
