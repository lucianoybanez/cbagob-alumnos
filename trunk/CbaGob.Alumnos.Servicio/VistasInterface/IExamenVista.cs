using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IExamenVista
    {
        int idInscripcion { get; set; }
        string Accion { get; set; }
        int IdExamen { get; set; }
        DateTime FechaExamen { get; set; }
        int NroExamen { get; set; }
        decimal Nota { get; set; }

        string NombreInstitucion { get; set; }
        string NombreEstadoCurso { get; set; }

        string NombreCurso { get; set; }

        string NombreNivel { get; set; }

        string NombreModalidad { get; set; }

        string NombrePrograma { get; set; }
      
        string NombreAlumno { get; set; }

    }
}
