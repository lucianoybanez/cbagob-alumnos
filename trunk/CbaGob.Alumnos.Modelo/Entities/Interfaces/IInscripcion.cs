using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IInscripcion : IComunDatos
    {
        int IdInscripcion { get; set; }
        string Descripcion { get; set; }
        int Id_Condicion_Curso { get; set; }
        DateTime Fecha { get; set; }

        int IdInstitucion { get; set; }
        string NombreInstitucion { get; set; }

        DateTime? FechaIncio { get; set ; }
        DateTime? FechaFin { get; set; }

        int IdEstadoCurso { get; set; }
        string NombreEstadoCurso { get; set; }

        int IdCurso { get; set; }
        string NombreCurso { get; set; }

        int IdNivel { get; set; }
        string NombreNivel { get; set; }

        int IdModalidad { get; set; }
        string NombreModalidad { get; set; }

        int Id_Alumno { get; set; }
        string NombreAlumno { get; set; }
        string ApellidoAlumno { get; set; }
        string Dni { get; set; }

        int idPrograma { get; set; }
        string NombrePrograma { get; set; }
        string NroResolucion { get; set; }
        bool Aprobo { get; set; }
    }
}
