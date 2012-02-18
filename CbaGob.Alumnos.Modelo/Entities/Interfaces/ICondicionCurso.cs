using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface ICondicionCurso : IComunDatos
    {
        int IdCondicionCurso { get; set; }
        int IdInstitucion { get; set; }
        string NombeInstitucion { get; set; }
        string EstadoCurso { get; set; }
        int IdCurso { get; set; }
        string NombreCurso { get; set; }
        int IdNivel { get; set; }
        string NombreNivel { get; set; }
        int IdModalidad { get; set; }
        string NombreModalidad { get; set; }
        int IdPrograma { get; set; }
        string NombrePrograma { get; set; }
        decimal PromedioRequerido { get; set; }
        int CantidadExamenes { get; set; }
        int CantidadClases { get; set; }
        int Presentismo { get; set; }
        int CargaHoraria { get; set; }
        int Cupo { get; set; }
        decimal Presupuesto { get; set; }
        int IdEstadoCurso { get; set; }
    }
}
