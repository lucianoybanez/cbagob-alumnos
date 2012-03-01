using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class EquiposVista : IEquiposVista
    {
        public IList<IEquipo> ListaEquipos { get; set; }
        public int Id_Equipo { get; set; }
    }
}
