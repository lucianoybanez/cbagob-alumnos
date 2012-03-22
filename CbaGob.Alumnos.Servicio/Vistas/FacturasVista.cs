using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class FacturasVista : IFacturasVista
    {
        public IList<IFactura> Facturas { get; set; }
        public string SearchFacturas { get; set; }
        public IPager Pager { get; set; }
        public string NroFactura { get; set; }
        public DateTime? Fecha { get; set; }
    }
}