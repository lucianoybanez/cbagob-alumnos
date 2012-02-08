using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Institucion : IInstitucion
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int INST_ID { get; set; }
        public string INST_NOMBRE { get; set; }
        public string INS_PROPIA { get; set; }
        public string ID_PROVINCIA { get; set; }
        public int ID_LOCALIDAD { get; set; }
        public int ID_CALLE { get; set; }
        public int INST_NRO { get; set; }
        public string INST_TELEFONO { get; set; }
        public int ID_DEPARTAMENTO { get; set; }
        public int ID_BARRIO { get; set; }
        public string ESTADO { get; set; }
    }
}
