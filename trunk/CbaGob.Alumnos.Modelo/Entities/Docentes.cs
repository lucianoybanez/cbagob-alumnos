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
        public string Estado { get; set; }
        public int Id_Docente { get; set; }
        public int Id_Cargo { get; set; }
        public string N_Modalidad { get; set; }
        public string Planta { get; set; }
        public string Reproca { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Barrio { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        public string Cuit_Cuil { get; set; }
        public string RazonSoial { get; set; }
        public string Nro_Resolucion { get; set; }
        public string Dni { get; set; }
        public int id_tipo_docente { get; set; }
        public string NombreTipoDocente { get; set; }
        public string Resolucion_Reproca { get; set; }
    }
}
