using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Horario : IHorario
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int Id_Horario { get; set; }
        public string Hora_Inicio { get; set; }
        public string Hora_Fin { get; set; }
        public string Dia_Semana { get; set; }
        public string Año { get; set; }
        public string Mes { get; set; }
        public string Curso { get; set; }
        public string Grupo { get; set; }
    }
}
