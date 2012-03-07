using System;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class CondicionCurso : ICondicionCurso
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int IdCondicionCurso{get; set; }

        public int IdInstitucion{get; set; }
        public string NombeInstitucion { get; set; }
        public string NombreEstadoCurso { get; set; }
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public int IdNivel { get; set; }
        public string NombreNivel { get; set; }
        public int IdModalidad { get; set; }
        public string NombreModalidad { get; set; }
        public int IdPrograma { get; set; }
        public string NombrePrograma { get; set; }
        public decimal PromedioRequerido { get; set; }
        public int CantidadExamenes { get; set; }
        public int CantidadClases { get; set; }
        public int Presentismo { get; set; }
        public int CargaHoraria { get; set; }
        public int Cupo { get; set; }
        public decimal Presupuesto { get; set; }
        public int IdEstadoCurso{get; set; }
        public string Nro_Resolucion { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
    }
}