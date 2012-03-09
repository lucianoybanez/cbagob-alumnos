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
        public string Estado { get; set; }
        public int Id_Alumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nro_Documento { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Cuil { get; set; }
        public int Id_Tipo_Dni { get; set; }
        public int Id_Tipo_Estado_Civil { get; set; }
        public int Id_Tipo_Sexo { get; set; }
        public string Sexo { get; set; }
        public string Estado_Civil { get; set; }
        public string Tipo_Dni { get; set; }
        public string Nro_Resolucion { get; set; }
        public string Nro_Telefono { get; set; }
        public string Nro_Celular { get; set; }
    }
}
