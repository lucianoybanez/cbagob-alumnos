using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Docentes : IDocentes
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int Id_Docente { get; set; }
        public int Id_PersonaJuridica { get; set; }
        public int Id_Domicilio { get; set; }
        public int Id_Cargo { get; set; }
        public string N_Modalidad { get; set; }
        public int Id_PersonaJur { get; set; }
        public int Id_Sede { get; set; }
        public string Cuit { get; set; }
        public string Razon_Social { get; set; }
        public string Estado { get; set; }
    }
}
