using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface ICursos : IComunDatos
    {
        int ID_CURSO { get; set; }
        string N_CURSO { get; set; }
        string ESTADO { get; set; }
        string NRORESOLUCION { get; set; }
        int Id_Area_Tipo_Curso { get; set; }
        string NombreAreaTipoCurso { get; set; }
    }
}
