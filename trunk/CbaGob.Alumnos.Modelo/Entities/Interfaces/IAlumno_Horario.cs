using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IAlumno_Horario:IComunDatos
    {
        int Id_Alumno_Horario { get; set; }
        int Id_Alumno { get; set; }
        int Id_Horario { get; set; }
    }
}
