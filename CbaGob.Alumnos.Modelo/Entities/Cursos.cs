using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Cursos : ICursos
    {
        public int ID_CURSO { get; set; }
        public string N_CURSO { get; set; }
        public string ESTADO { get; set; }
        public string NRORESOLUCION { get; set; }
        public int Id_Area_Tipo_Curso { get; set; }
        public string NombreAreaTipoCurso { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
    }
}
