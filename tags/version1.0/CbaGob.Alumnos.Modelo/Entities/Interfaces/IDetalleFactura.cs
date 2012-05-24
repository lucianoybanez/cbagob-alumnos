using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IDetalleFactura : IComunDatos
    {
        int IdDetalleFactura { get; set; }
        int IdFactura { get; set; }
        string Item { get; set; }
        decimal Monto { get; set; }
        string Descripcion { get; set; }
    }
}
