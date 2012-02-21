using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class EstablecimientoVista : IEstablecimientoVista
    {
        public int Id_Establecimiento { get; set; }
        public int Id_Institucion { get; set; }
        public int Id_Domicilio { get; set; }
        public string N_Establecimiento { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Barrio { get; set; }
        public string Calle { get; set; }
        public string Nro { get; set; }
    }
}
