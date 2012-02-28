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
        public string Estado { get; set; }
        public int Id_Institucion { get; set; }
        public int Id_Domicilio { get; set; }
        public string Nombre_Institucion { get; set; }
        public string espropia { get; set; }
        public string DireccionCompleta { get; set; }
    }
}
