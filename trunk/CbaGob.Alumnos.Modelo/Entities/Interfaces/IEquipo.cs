using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IEquipo : IComunDatos
    {
        int Id_Equipo { get; set; }
        int Id_Estado_Equipo { get; set; }
        string N_Equipos { get; set; }
        string NombreEstadoEquipo { get; set; }
    }
}
