using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IFacturaServicio : IBaseServicio
    {
        IFacturasVista GetFacturas();
        IFacturaVista GetFactura(int IdFactura);
        IFacturaVista CambiarCondicion(IFacturaVista vista);
        IFacturaVista GetIndex();
        bool AgregarFactura(IFacturaVista factura);
        bool EliminarFactura(int idFactura);
    }
}
