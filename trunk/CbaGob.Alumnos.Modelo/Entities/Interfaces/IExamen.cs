using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IExamen : IComunDatos
    {
        int IdExamen { get; set; }
        DateTime FechaExamen { get; set; }
        int NroExamen { get; set; }
        decimal Nota { get; set; }
        int IdInscripcion { get; set; }
        int IdGrupo { get; set; }
        int IdAlumno { get; set; }
        string NombreGrupo { get; set; }
        string NombreAlumno { get; set; }

    }
}
