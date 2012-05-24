using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Tipo_EstadoCivil : ITipo_EstadoCivil
    {
        public int Id_TipoEstadoCivil { get; set; }
        public string Nombre_TipoEstadoCivil { get; set; }
    }
}
