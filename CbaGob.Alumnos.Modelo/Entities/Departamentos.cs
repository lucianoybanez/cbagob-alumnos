using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Departamentos : IDepartamentos
    {
        public int ID_DEPARTAMENTO { get; set; }
        public string N_DEPARTAMENTO { get; set; }
        public string ID_PROVINCIA { get; set; }
        public DateTime FEC_ULT_ACTUALIZACION { get; set; }
        public string ID_USUARIO { get; set; }
        public int SUPERFICIE { get; set; }
        public int POBLACION { get; set; }
        public int DENSIDAD { get; set; }
        public string INDEC { get; set; }
    }
}
