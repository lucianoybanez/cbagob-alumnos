using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class FacturasVista : IFacturasVista
    {
        public IList<IFactura> Facturas { get; set; }
        public string SearchFacturas { get; set; }
    }
}