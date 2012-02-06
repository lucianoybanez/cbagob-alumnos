using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IInstitucion : IComunDatos
    {
        int INST_ID { get; set; }
        string INST_NOMBRE { get; set; }
        string INS_PROPIA { get; set; }
        int ID_PROVINCIA { get; set; }
        int ID_LOCALIDAD { get; set; }
        int ID_CALLE { get; set; }
        int INST_NRO { get; set; }
        string INST_TELEFONO { get; set; }
    }
}
