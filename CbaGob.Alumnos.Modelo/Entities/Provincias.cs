using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Provincias : IProvincias
    {
        public string ID_PROVINCIA { get; set; }
        public string N_PROVINCIA { get; set; }
        public DateTime FEC_ULT_ACTUALIZACION { get; set; }
        public string ID_USUARIO { get; set; }
        public string ID_PAIS { get; set; }
        public string INDEC { get; set; }
    }
}
