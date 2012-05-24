using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IFacturaServicio : IBaseServicio
    {
        IFacturasVista GetFacturas(DateTime? Fecha, string NroFactura);
        IFacturasVista GetFacturas(IPager Pager,DateTime? Fecha, string NroFactura);
        IFacturasVista GetFacturasbyLiquidacion();
        IFacturasVista GetFacturasbyLiquidacion(IPager Pager);
        IFacturaVista GetFactura(int IdFactura);
        IFacturaVista CambiarCondicion(IFacturaVista vista);
        IFacturaVista GetIndex();
        bool AgregarFactura(IFacturaVista factura);
        bool EliminarFactura(int idFactura);
        bool LiquidarFactura(int idFactura);
    }
}
