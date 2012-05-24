using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Cargos : ICargos
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int Id_Cargo { get; set; }
        public string N_Cargo { get; set; }
        public string Nro_Resolucion { get; set; }
        public string Estado { get; set; }
    }
}
