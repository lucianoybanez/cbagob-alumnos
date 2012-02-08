using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface ILocalidades
    {
        int ID_LOCALIDAD { get; set; }
        string N_LOCALIDAD { get; set; }
        string ID_PROVINCIA { get; set; }
        int ID_DEPARTAMENTO { get; set; }
        DateTime FEC_ULT_ACTUALIZACION { get; set; }
        int ID_USUARIO { get; set; }
        string TIPO { get; set; }
        string INDEC { get; set; }
    }
}
