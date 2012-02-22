using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class FacturaVista : IFacturaVista
    {
        public FacturaVista()
        {
            CondicionCurso = new ComboBox();
            Institucion = new ComboBox();
        }

        public int IdFactura { get; set; }
        public string NroFactura { get; set; }
        public decimal MontoTotal { get; set; }
        public string Concepto { get; set; }
        public string Accion { get; set; }
        public IComboBox CondicionCurso { get; set; }
        public IComboBox Institucion { get; set; }
        public string Item { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
    }
}