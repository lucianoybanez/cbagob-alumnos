using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Equipo : IEquipo
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int Id_Equipo { get; set; }
        public int Id_Estado_Equipo { get; set; }
        public string N_Equipos { get; set; }
        public string NombreEstadoEquipo { get; set; }
    }
}
