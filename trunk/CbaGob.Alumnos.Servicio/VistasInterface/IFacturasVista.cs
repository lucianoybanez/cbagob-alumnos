using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IFacturasVista
    {
        IList<IFactura> Facturas { get; set; }
        string SearchFacturas { get; set; }
        IPager Pager { get; set; }
    }
}
