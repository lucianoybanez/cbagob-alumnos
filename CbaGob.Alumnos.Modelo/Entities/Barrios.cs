using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public class Barrios : IBarrios
    {
        public int ID_BARRIO { get; set; }
        public string N_BARRIO { get; set; }
        public int ID_LOCALIDAD { get; set; }
        public string COMENTARIO { get; set; }
        public DateTime FEC_ULT_ACTUALIZACION { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_PRECINTO { get; set; }
        public int ID_BARRIO_C { get; set; }
        public string N_BARRIO_C { get; set; }
        public int ID_SECCIONAL { get; set; }
    }
}
