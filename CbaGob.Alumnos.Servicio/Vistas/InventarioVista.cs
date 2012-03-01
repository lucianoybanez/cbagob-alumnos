using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class InventarioVista : IInventarioVista
    {
        public string NombreItem { get; set; }
        public int CantidadEquipos { get; set; }
        public int Id_EstadoEquipo { get; set; }
        public IList<IEquipo> ListaEquipo { get; set; }
    }
}
