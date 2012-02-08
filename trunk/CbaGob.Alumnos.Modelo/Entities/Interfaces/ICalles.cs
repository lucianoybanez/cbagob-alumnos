using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface ICalles
    {
        int ID_TIPOCALLE { get; set; }
        int ID_CALLE { get; set; }
        string N_CALLE { get; set; }
        string N_ABREVIADO { get; set; }
        string ID_PROVINCIA { get; set; }
        int ID_LOCALIDAD { get; set; }
        int ID_DEPARTAMENTO { get; set; }
        DateTime FEC_ULT_ACTUALIZACION { get; set; }
        string ID_USUARIO { get; set; }
    }
}
