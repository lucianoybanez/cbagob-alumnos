using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IProgramaVista
    {
        int IdPrograma { get; set; }
        string NombrePrograma { get; set; }
        string Descripcion { get; set; }
        string Nro_resolucion { get; set; }
    }
}
