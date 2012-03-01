using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IEstado_Equipo : IComunDatos
    {
        int Id_Estado_Equipo { get; set; }
        string Nombre_Estado_Equipo { get; set; }
    }
}
