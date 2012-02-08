using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IDepartamentos
    {
        int ID_DEPARTAMENTO { get; set; }
        string N_DEPARTAMENTO { get; set; }
        string ID_PROVINCIA { get; set; }
        DateTime FEC_ULT_ACTUALIZACION { get; set; }
        string ID_USUARIO { get; set; }
        int SUPERFICIE { get; set; }
        int POBLACION { get; set; }
        int DENSIDAD { get; set; }
        string INDEC { get; set; }
    }
}
