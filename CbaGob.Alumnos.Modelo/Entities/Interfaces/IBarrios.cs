using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IBarrios
    {
        int ID_BARRIO { get; set; }
        string N_BARRIO { get; set; }
        int ID_LOCALIDAD { get; set; }
        string COMENTARIO { get; set; }
        DateTime FEC_ULT_ACTUALIZACION { get; set; }
        int ID_USUARIO { get; set; }
        int ID_PRECINTO { get; set; }
        int ID_BARRIO_C { get; set; }
        string N_BARRIO_C { get; set; }
        int ID_SECCIONAL { get; set; }
    }
}
