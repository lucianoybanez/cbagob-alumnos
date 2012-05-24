using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Tipo_Dni : ITipo_Dni
    {
        public int Id_TipoDni { get; set; }
        public string Nombre_TipoDni { get; set; }
    }
}
