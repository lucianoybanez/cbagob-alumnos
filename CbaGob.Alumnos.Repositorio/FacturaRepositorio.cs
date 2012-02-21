using System;
using System.Linq;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class FacturaRepositorio : BaseRepositorio,IFacturaRepositorio
    {
        private CursosDB mDB;

        public FacturaRepositorio()
        {
            mDB = new CursosDB();
        }

        public IList<IFactura> GetFacturas()
        {
            var a = (from p in mDB.T_FACTURAS
                     select new Factura()
                                {
                                    Concepto = p.CONCEPTO,
                                    Estado = p.ESTADO,
                                    FechaAlta = p.FEC_ALTA,
                                    FechaModificacion = p.FEC_MODIF,
                                    IdFactura = p.ID_FACTURA,
                                    MontoTotal = p.MONTO_TOTAL,
                                    NroFactura = p.NRO_FACTURA,
                                    UsuarioAlta = p.USR_ALTA,
                                    UsuarioModificacion = p.USR_MODIF
                                }).Cast<IFactura>().ToList();
            return a;
        }

        public IFactura GetFacturabyId(int idFactura)
        {
            var queryResult = mDB.T_FACTURAS.Where(c => c.ID_FACTURA == idFactura && c.ESTADO == "A").FirstOrDefault();
            if (queryResult!=null)
            {
                IFactura factura = new Factura()
                                       {
                                           Concepto = queryResult.CONCEPTO,
                                           Estado = queryResult.ESTADO,
                                           FechaAlta = queryResult.FEC_ALTA,
                                           FechaModificacion = queryResult.FEC_MODIF,
                                           MontoTotal = queryResult.MONTO_TOTAL,
                                           UsuarioAlta = queryResult.USR_ALTA,
                                           UsuarioModificacion = queryResult.USR_MODIF,
                                           NroFactura = queryResult.NRO_FACTURA,
                                           IdFactura = queryResult.ID_FACTURA,
                                           DetalleFactura = new List<IDetalleFactura>()
                                       };
                //foreach (var detalle in queryResult.T_DETALLES_FACTURA)
                //{
                //    factura.DetalleFactura.Add(new DetalleFactura()
                //                                   {
                //                                       Descripcion = detalle.DESCRIPCION,
                //                                       IdDetalleFactura = detalle.ID_DETALLE_FACTURA,
                //                                       IdFactura = detalle.ID_FACTURA,
                //                                       Item = detalle.ITEM,
                //                                       Monto = detalle.MONTO
                //                                   });
                //}
                return factura;
            }
            return null;
        }

        public bool AgregarFactura(IFactura factura)
        {
            base.AgregarDatosAlta(factura);
            T_FACTURAS facturas = new T_FACTURAS()
                                      {
                                          CONCEPTO = factura.Concepto,
                                          ESTADO = factura.Estado,
                                          FEC_ALTA = factura.FechaAlta,
                                          FEC_MODIF = factura.FechaModificacion,
                                          MONTO_TOTAL = factura.MontoTotal,
                                          NRO_FACTURA = factura.NroFactura,
                                          USR_ALTA = factura.UsuarioAlta,
                                          USR_MODIF = factura.UsuarioModificacion,
                                      };
            mDB.AddToT_FACTURAS(facturas);

            foreach (var item in factura.DetalleFactura)
            {
                base.AgregarDatosAlta(item);
                T_DETALLES_FACTURA detalle = new T_DETALLES_FACTURA()
                                                 {
                                                     DESCRIPCION = item.Descripcion,
                                                     ESTADO = item.Estado,
                                                     FEC_ALTA = item.FechaAlta,
                                                     FEC_MODIF = item.FechaModificacion,
                                                     //ID_CONDICION_CURSO = item.CondicionCurso.IdCondicionCurso,
                                                     ID_FACTURA = 5,// Check this on ecommerce to check how get last id of factura on transaction
                                                     ITEM = item.Item,
                                                     MONTO = item.Monto,
                                                     USR_ALTA = item.UsuarioAlta,
                                                     USR_MODIF = item.UsuarioModificacion,
                                                 };
                mDB.AddToT_DETALLES_FACTURA(detalle);
            }
            mDB.SaveChanges();
            return true;
        }

        public bool ModificarFactura(IFactura factura)
        {
            throw new NotImplementedException();
        }

        public bool EliminarFactura(int idFactura)
        {
            IComunDatos datos = new ComunDatos();
            base.AgregarDatosEliminacion(datos);

            try
            {
                var a = mDB.T_DETALLES_FACTURA.Where(c => c.ID_FACTURA == idFactura).ToList();
                foreach (var detalle in a)
                {
                    detalle.ESTADO = datos.Estado;
                    detalle.FEC_MODIF = datos.FechaModificacion;
                    detalle.USR_MODIF = datos.UsuarioModificacion;
                }

                var factura = mDB.T_FACTURAS.Where(c => c.ID_FACTURA == idFactura).FirstOrDefault();
                factura.ESTADO = datos.Estado;
                factura.FEC_MODIF = datos.FechaModificacion;
                factura.USR_MODIF = datos.UsuarioModificacion;

                mDB.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}