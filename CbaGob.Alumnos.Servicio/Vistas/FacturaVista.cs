using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class FacturaVista : IFacturaVista
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int IdFactura { get; set; }
        public string NroFactura { get; set; }
        public decimal MontoTotal { get; set; }
        public string Concepto { get; set; }
        public IList<IDetalleFactura> DetalleFactura { get; set; }
    }
}