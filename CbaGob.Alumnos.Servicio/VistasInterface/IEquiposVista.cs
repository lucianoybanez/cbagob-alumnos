using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IEquiposVista
    {
        IList<IEquipo> ListaEquipos { get; set; }
        int Id_Equipo { get; set; }
    }
}
