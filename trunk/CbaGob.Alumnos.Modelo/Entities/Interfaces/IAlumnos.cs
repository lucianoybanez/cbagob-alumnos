using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IAlumnos : IComunDatos, IPersona
    {
        int Id_Alumno { get; set; }
        int Id_Persona { get; set; }
        string Estado { get; set; }
    }
}
