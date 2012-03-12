using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Superviciones : ISuperviciones
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int Id_Supervision { get; set; }
        public int Id_Grupo { get; set; }
        public int Id_Supervisor { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fec_Supervision { get; set; }
        public string Hs_Supervision { get; set; }
        public string NombreInstitucion { get; set; }
        public string NombreCurso { get; set; }
        public string NombreGrupo { get; set; }
        public string NombrePersonaJuridica { get; set; }
    }
}
