using System.ComponentModel.DataAnnotations;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class CondicionCursoVista : ICondicionCursoVista
    {
        public CondicionCursoVista()
        {
            Curso = new ComboBox();
            Nivel = new ComboBox();
            Modalidad = new ComboBox();
            Programa = new ComboBox();
        }
        
        public string NombeInstitucion { get; set; }

        public string EstadoCurso {get; set; }
        public IComboBox Curso { get; set; }
        public IComboBox Nivel { get; set; }
        public IComboBox Modalidad { get; set; }
        public IComboBox Programa { get; set; }
        public decimal PromedioRequerido { get; set; }
        public int CantidadExamenes { get; set; }
        public int CantidadClases { get; set; }
        public int Presentismo { get; set; }
        public int CargaHoraria { get; set; }
        public int Cupo { get; set; }
        public decimal Presupuesto { get; set; }
    }
}