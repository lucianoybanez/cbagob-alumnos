using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IEquipoVista 
    {
        int Id_Equipo { get; set; }
        int Id_Estado_Equipo { get; set; }
        string N_Equipos { get; set; }
        string NombreEstadoEquipo { get; set; }
        IComboBox EstadoEquipo { get; set; }
    }
}
