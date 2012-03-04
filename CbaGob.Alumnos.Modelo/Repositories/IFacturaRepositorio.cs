using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IFacturaRepositorio
    {
        IList<IFactura> GetFacturas();
        IList<IFactura> GetFacturasbyLiquidacion();
        IFactura GetFacturabyId(int idFactura);
        int AgregarFactura(IFactura factura);
        bool ModificarFactura(IFactura factura);
        bool EliminarFactura(int idFactura);
        bool AgregarDetalle(IDetalleFactura detalleFactura);
        bool LiquidarFactura(int idFactura);
    }
}
