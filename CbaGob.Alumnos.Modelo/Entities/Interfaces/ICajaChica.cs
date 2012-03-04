using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface ICajaChica : IComunDatos
    {
        int Id_Caja_Chica { get; set; }
        int Id_Estado_Caja_Chica { get; set; }
        int Id_Institucion { get; set; }
        decimal Monto { get; set; }
        string NombreInstitucion { get; set; }
        string NombreEstadoCaja { get; set; }

    }
}
