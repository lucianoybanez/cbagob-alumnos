using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IModalidadVista
    {
        int IdModalidad { get; set; }
        string NombreModalidad { get; set; }
        string Nro_Resolucion { get; set; }
    }
}
