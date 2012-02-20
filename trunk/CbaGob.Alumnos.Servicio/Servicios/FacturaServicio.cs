using System;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class FacturaServicio : BaseServicio, IFacturaServicio
    {
        private IFacturaRepositorio FacturaRepositorio;

        public FacturaServicio(IFacturaRepositorio facturaRepositorio)
        {
            FacturaRepositorio = facturaRepositorio;
        }

        public IFacturasVista GetFacturas()
        {
            IFacturasVista vista = new FacturasVista();
            vista.Facturas = FacturaRepositorio.GetFacturas();
            return vista;
        }

        public IFacturaVista GetFactura(int IdFactura)
        {
            throw new NotImplementedException();
        }

        public bool AgregarFactura(IFacturaVista factura)
        {
            throw new NotImplementedException();
        }

        public bool EliminarFactura(int idFactura)
        {
            throw new NotImplementedException();
        }
    }
}