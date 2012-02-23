using System;
using System.Data.Objects;
using System.Linq;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;
using System.Transactions;

namespace CbaGob.Alumnos.Repositorio
{
    public class FacturaRepositorio : BaseRepositorio, IFacturaRepositorio
    {
        private CursosDB mDB;

        public FacturaRepositorio()
        {
            mDB = new CursosDB();
        }

        public IList<IFactura> GetFacturas()
        {
            var a = (from p in mDB.T_FACTURAS
                     where p.ESTADO=="A"
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
                         UsuarioModificacion = p.USR_MODIF,
                         IdCondicionCurso = p.T_CONDICIONES_CURSO.ID_CONDICION_CURSO,
                         NombreCurso = p.T_CONDICIONES_CURSO.T_CURSOS.N_CURSO,
                         NombreInstitucion = p.T_CONDICIONES_CURSO.T_INSTITUCIONES.N_INSTITUCION
                     }).ToList().Cast<IFactura>().ToList();
            return a;
        }

        public IFactura GetFacturabyId(int idFactura)
        {
            var factura = (from queryResult in mDB.T_FACTURAS
                           where queryResult.ID_FACTURA == idFactura && queryResult.ESTADO == "A"
                           select new Factura()
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
                               IdCondicionCurso = queryResult.T_CONDICIONES_CURSO.ID_CONDICION_CURSO,
                               IdInstitucion = queryResult.T_CONDICIONES_CURSO.ID_INSTITUCION,
                               /*DetalleFactura = new DetalleFactura()
                               {
                                   Descripcion = queryResult.T_DETALLES_FACTURA.DESCRIPCION,
                                   FechaAlta = queryResult.T_DETALLES_FACTURA.FEC_ALTA,
                                   FechaModificacion = queryResult.T_DETALLES_FACTURA.FEC_MODIF,
                                   Estado = queryResult.T_DETALLES_FACTURA.ESTADO,
                                   IdDetalleFactura = queryResult.T_DETALLES_FACTURA.ID_DETALLE_FACTURA,
                                   IdFactura = queryResult.ID_FACTURA,
                                   Item = queryResult.T_DETALLES_FACTURA.ITEM,
                                   Monto = queryResult.T_DETALLES_FACTURA.MONTO,
                                   UsuarioAlta = queryResult.T_DETALLES_FACTURA.USR_ALTA,
                                   UsuarioModificacion = queryResult.T_DETALLES_FACTURA.USR_MODIF
                               }*/
                           }).FirstOrDefault();


            return factura;
        }

        public int AgregarFactura(IFactura factura)
        {
            try
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
                    ID_CONDICION_CURSO = factura.IdCondicionCurso,
                };
                mDB.AddToT_FACTURAS(facturas);
                mDB.SaveChanges();
             

                return mDB.T_FACTURAS.OrderByDescending(c => c.ID_FACTURA).First().ID_FACTURA;

            }
            catch (Exception ex)
            {
                throw;
            }

            return 0;




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

        public bool AgregarDetalle(IDetalleFactura detalleFactura)
        {
            /*
            try
            {
                base.AgregarDatosAlta(detalleFactura);
                T_DETALLES_FACTURA detalle = new T_DETALLES_FACTURA()
                {
                    DESCRIPCION = detalleFactura.Descripcion,
                    ESTADO = detalleFactura.Estado,
                    FEC_ALTA = detalleFactura.FechaAlta,
                    FEC_MODIF = detalleFactura.FechaModificacion,
                    ITEM = detalleFactura.Item,
                    MONTO = detalleFactura.Monto,
                    USR_ALTA = detalleFactura.UsuarioAlta,
                    USR_MODIF = detalleFactura.UsuarioModificacion,
                    ID_FACTURA = detalleFactura.IdFactura
                };
                mDB.AddToT_DETALLES_FACTURA(detalle);
                mDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
             * */
            return true;
        }
    }
}