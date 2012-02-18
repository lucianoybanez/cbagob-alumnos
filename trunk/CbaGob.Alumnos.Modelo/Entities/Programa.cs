using System;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Programa : IPrograma
    {
        public int IdPrograma { get; set; }
        public string NombrePrograma { get; set; }

        public string Descripcion{get; set; }
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
    }
}