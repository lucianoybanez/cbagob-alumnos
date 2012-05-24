using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ICargoVista
    {
        int Id_Cargo { get; set; }
        string N_Cargo { get; set; }
        string Nro_Resolucion { get; set; }
    }
}
