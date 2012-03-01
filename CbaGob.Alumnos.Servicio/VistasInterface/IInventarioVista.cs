using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IInventarioVista
    {
        string NombreItem { get; set; }
        int CantidadEquipos { get; set; }
        int Id_EstadoEquipo { get; set; }
        IList<IEquipo> ListaEquipo { get; set; }
    }
}
