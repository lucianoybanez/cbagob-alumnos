using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ICondicionCursoVista
    {
        int IdCondicionCurso { get; set; }
        int IdInstitucion { get; set; }
        string NombeInstitucion { get; set; }
        IComboBox EstadoCurso { get; set; }
        IComboBox Curso { get; set; }
        IComboBox Nivel { get; set; }
        IComboBox Modalidad { get; set; }
        IComboBox Programa { get; set; }
        decimal PromedioRequerido { get; set; }
        int CantidadExamenes { get; set; }
        int CantidadClases { get; set; }
        int Presentismo { get; set; }
        int CargaHoraria { get; set; }
        int Cupo { get; set; }
        decimal Presupuesto { get; set; }
        string Accion { get; set; }
        string NombrePrograma { get; set; }
        string NombreEstadoCurso { get; set; }
        string NombreCurso { get; set; }
        string NombreNivel { get; set; }
        string NombreModalidad { get; set; }
        IList<IGrupo> ListaGrupos { get; set; }
        IList<IAlumnos> ListaAlumno { get; set; }
        System.DateTime Fecha_Inicio { get; set; }
        System.DateTime Fecha_Fin { get; set; }
        string Nro_Resolucion { get; set; }
    }
}