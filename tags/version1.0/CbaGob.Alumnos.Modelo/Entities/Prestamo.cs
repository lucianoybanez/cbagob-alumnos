using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Prestamo : IPrestamo
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int Id_Prestamo { get; set; }
        public int Id_Institucion { get; set; }
        public int Id_Equipo { get; set; }
        public DateTime Fec_Inicio { get; set; }
        public DateTime Fec_Fin { get; set; }
        public string Observaciones { get; set; }
        public string NombreEquipo { get; set; }
        public string NombreInstitucion { get; set; }
    }
}
