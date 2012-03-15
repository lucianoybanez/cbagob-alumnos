using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IAreaTipoCursoVista
    {
        int Id_Area_Tipo_Curso { get; set; }
        string Nombre_AreaTipoCurso { get; set; }
        string Nro_Resolucion { get; set; }
    }
}
