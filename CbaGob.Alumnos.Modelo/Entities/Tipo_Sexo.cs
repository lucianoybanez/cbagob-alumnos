using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Tipo_Sexo : ITipo_Sexo
    {
        public int Id_TipoSexo { get; set; }
        public string Nombre_TipoSexo { get; set; }
    }
}
