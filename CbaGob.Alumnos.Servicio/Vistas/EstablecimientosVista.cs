using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class EstablecimientosVista : IEstablecimientosVista
    {
        public IList<IEstablecimiento> ListaEstablecimiento { get; set; }
        public int Id_Institucion { get; set; }
    }
}
