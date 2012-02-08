using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Localidades : ILocalidades
    {
        public int ID_LOCALIDAD { get; set; }
        public string N_LOCALIDAD { get; set; }
        public string ID_PROVINCIA { get; set; }
        public int ID_DEPARTAMENTO { get; set; }
        public DateTime FEC_ULT_ACTUALIZACION { get; set; }
        public int ID_USUARIO { get; set; }
        public string TIPO { get; set; }
        public string INDEC { get; set; }
    }
}
