using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IFactura : IComunDatos
    {
        int IdFactura { get; set; }
        string NroFactura { get; set; }
        decimal MontoTotal { get; set; }
        string Concepto { get; set; }
        IList<IDetalleFactura> DetalleFactura { get; set; } 
    }
}
