using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Alumno : IAlumnos
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int Id_Alumno { get; set; }
        public int Id_Persona { get; set; }
        public string Nov_Apellido { get; set; }
        public string Nov_Nombre { get; set; }
        public string Cuil { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Id_Sexo { get; set; }
        public string Nro_Documento { get; set; }
        public string Id_Tipo_Documento { get; set; }
        public string Id_Estado_Civil { get; set; }
        public string Estado { get; set; }
    }
}
