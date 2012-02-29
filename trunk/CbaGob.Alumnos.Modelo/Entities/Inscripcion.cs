using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Inscripcion : IInscripcion
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int IdInscripcion { get; set; }
        public string Descripcion { get; set; }
        public int Id_Condicion_Curso { get; set; }
        public DateTime Fecha { get; set; }
        public int IdInstitucion { get; set; }
        public string NombreInstitucion { get; set; }
        public int IdEstadoCurso { get; set; }
        public string NombreEstadoCurso { get; set; }
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public int IdNivel { get; set; }
        public string NombreNivel { get; set; }
        public int IdModalidad { get; set; }
        public string NombreModalidad { get; set; }
        public int Id_Alumno { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
    }
}
