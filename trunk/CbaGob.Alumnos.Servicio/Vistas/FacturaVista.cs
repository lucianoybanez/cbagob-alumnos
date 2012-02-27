using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string NroFactura { get; set; }
        [Required]
        public string Concepto { get; set; }
        public string Accion { get; set; }
        public IComboBox CondicionCurso { get; set; }
        public IComboBox Institucion { get; set; }
        [Required]
        public string Item { get; set; }
        [Required]
        public decimal Monto { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}