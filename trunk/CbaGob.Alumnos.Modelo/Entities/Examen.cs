using System;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Examen : IExamen
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int IdExamen { get; set; }
        public DateTime FechaExamen { get; set; }
        public int NroExamen { get; set; }
        public decimal Nota { get; set; }
        public int IdInscripcion { get; set; }
        public int IdGrupo { get; set; }
        public int IdAlumno { get; set; }
        public string NombreGrupo { get; set; }
        public string NombreAlumno { get; set; }
    }
}