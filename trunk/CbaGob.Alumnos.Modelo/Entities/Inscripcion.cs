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
        public int Id_Inscipcion { get; set; }
        public int Id_Alumno { get; set; }
        public int Id_Condicion_Curso { get; set; }
        public DateTime Fecha { get; set; }
        public string Nov_Apellido { get; set; }
        public string Nov_Nombre { get; set; }
        public string Cuil { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Nro_Documento { get; set; }
        public string Nombre_Curso { get; set; }
        public string Descripcion { get; set; }
    }
}
