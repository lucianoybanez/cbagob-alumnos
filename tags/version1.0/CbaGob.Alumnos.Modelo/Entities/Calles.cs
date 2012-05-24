using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Calles : ICalles
    {
        public int ID_TIPOCALLE { get; set; }
        public int ID_CALLE { get; set; }
        public string N_CALLE { get; set; }
        public string N_ABREVIADO { get; set; }
        public string ID_PROVINCIA { get; set; }
        public int ID_LOCALIDAD { get; set; }
        public int ID_DEPARTAMENTO { get; set; }
        public DateTime FEC_ULT_ACTUALIZACION { get; set; }
        public string ID_USUARIO { get; set; }
    }
}
