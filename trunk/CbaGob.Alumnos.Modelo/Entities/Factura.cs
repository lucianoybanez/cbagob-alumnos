using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Factura : IFactura
    {
        public int IdFactura { get; set; }

        public int IdInstitucion{ get; set; }

        public string NombreCurso { get; set; }

        public string NombreInstitucion{get; set; }
        public int IdCondicionCurso { get; set; }
        public string NroFactura { get; set; }
        public decimal MontoTotal { get; set; }
        public string Concepto { get; set; }
        public IDetalleFactura DetalleFactura { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
    }
}