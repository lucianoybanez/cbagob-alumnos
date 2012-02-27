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
    }
}