using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Tipo_Movimiento : ITipo_Movimiento
    {
        public int Id_Tipo_Movimiento { get; set; }
        public string Nombre_Tipo_Movimiento { get; set; }
    }
}
