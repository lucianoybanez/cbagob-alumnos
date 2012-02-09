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
        public int ID_INSTITUCION { get; set; }
        public int ID_DOMICILIO { get; set; }
        public string N_INSTITUCION { get; set; }
        public string INS_PROPIA { get; set; }
    }
}
