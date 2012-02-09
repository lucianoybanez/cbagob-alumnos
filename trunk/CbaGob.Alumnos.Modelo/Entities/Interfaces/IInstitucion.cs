using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IInstitucion : IComunDatos
    {
        int ID_INSTITUCION { get; set; }
        int ID_DOMICILIO { get; set; }
        string N_INSTITUCION { get; set; }
        string INS_PROPIA { get; set; }
    }
}
