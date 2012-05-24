using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IAreaTipoCurso : IComunDatos
    {
        int Id_Area_Tipo_Curso { get; set; }
        string Nombre_AreaTipoCurso { get; set; }
        string Nro_Resolucion { get; set; }
    }
}
