using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IFacturaRepositorio
    {
        IList<IFactura> GetFacturas();
        IFactura GetFacturabyId(int idFactura);
        bool AgregarFactura(IFactura factura);
        bool ModificarFactura(IFactura factura);
        bool EliminarFactura(int idFactura);
    }
}
