using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface ITipo_Movimiento
    {
        int Id_Tipo_Movimiento { get; set; }
        string Nombre_Tipo_Movimiento { get; set; }
    }
}
