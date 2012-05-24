using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface ICargos : IComunDatos
    {
        int Id_Cargo { get; set; }
        string N_Cargo { get; set; }
        string Nro_Resolucion { get; set; }
    }
}
