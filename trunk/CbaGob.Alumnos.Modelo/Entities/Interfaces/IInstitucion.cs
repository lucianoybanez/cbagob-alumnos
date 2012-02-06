using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IInstitucion : IComunDatos
    {
        Int32 INST_ID { get; set; }
        string INST_NOMBRE { get; set; }
        string INS_PROPIA { get; set; }
        Int32 ID_PROVINCIA { get; set; }
        Int32 ID_LOCALIDAD { get; set; }
        Int32 ID_CALLE { get; set; }
        Int32 INST_NRO { get; set; }
        string INST_TELEFONO { get; set; }
    }
}
