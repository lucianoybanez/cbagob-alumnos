using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Rol : IRol
    {
        public int RolId { get; set; }
        public string RolTipo { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
    }


    public enum RolTipo
    {
        Administrador = 1,
        Nivel2 = 2,
        Nivel3 = 3,
        Nivel4 = 4
    }

}