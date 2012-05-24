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
    public class PrestamoVista : IPrestamoVista
    {
        public PrestamoVista()
        {
            Institucion = new Buscador();
            Equipos = new Buscador();
        }

        public int Id_Prestamo { get; set; }
        [Range(1, 9999999999999999)]
        public int Id_Institucion { get; set; }
        [Range(1, 9999999999999999)]
        public int Id_Equipo { get; set; }
        public DateTime Fec_Inicio { get; set; }
        public DateTime Fec_Fin { get; set; }
        public string Observaciones { get; set; }
        public string NombreEquipo { get; set; }
        public string NombreInstitucion { get; set; }
        public IBuscador Institucion { get; set; }
        public IBuscador Equipos { get; set; }

    }
}
