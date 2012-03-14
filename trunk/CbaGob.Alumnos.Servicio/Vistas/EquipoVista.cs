using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class EquipoVista : IEquipoVista
    {
        public EquipoVista()
        {
            EstadoEquipo = new ComboBox();
        }
        
        public int Id_Equipo { get; set; }
        [Range(1, 9999999999999999999)]
        public int Id_Estado_Equipo { get; set; }
        [Required()]
        public string N_Equipos { get; set; }
        public string NombreEstadoEquipo { get; set; }
        public IComboBox EstadoEquipo { get; set; }
        public string NombreEquipoBusqueda { get; set; }
    }
}
