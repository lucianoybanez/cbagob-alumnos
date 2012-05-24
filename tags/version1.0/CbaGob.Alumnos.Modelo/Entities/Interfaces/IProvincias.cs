using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IProvincias
    {
        string ID_PROVINCIA { get; set; }
        string N_PROVINCIA { get; set; }
        DateTime FEC_ULT_ACTUALIZACION { get; set; }
        string ID_USUARIO { get; set; }
        string ID_PAIS { get; set; }
        string INDEC { get; set; }
    }
}
