using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IFacturaServicio
    {
        IFacturasVista GetFacturas();
        IFacturaVista GetFactura(int IdFactura);
        bool AgregarFactura(IFacturaVista factura);
        bool EliminarFactura(int idFactura);
    }
}
