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

        public FacturaRepositorio(ILoggedUserHelper helper)
            : base(helper)
        {
            mDB = new CursosDB();
        }

        private IQueryable<IFactura> QFactura()
        {
            var a = (from c in mDB.T_FACTURAS
                     where c.ESTADO == "A"
                     select new Factura()
                                {
                                    Concepto = c.CONCEPTO,
                                    Estado = c.ESTADO,
                                    FechaAlta = c.FEC_ALTA,
                                    FechaModificacion = c.FEC_MODIF,
                                    IdFactura = c.ID_FACTURA,
                                    MontoTotal = c.MONTO_TOTAL,
                                    NroFactura = c.NRO_FACTURA,
                                    UsuarioAlta = c.USR_ALTA,
                                    UsuarioModificacion = c.USR_MODIF,
                                    IdCondicionCurso = c.T_CONDICIONES_CURSO.ID_CONDICION_CURSO,
                                    NombreCurso = c.T_CONDICIONES_CURSO.T_CURSOS.N_CURSO,
                                    NombreInstitucion = c.T_CONDICIONES_CURSO.T_INSTITUCIONES.N_INSTITUCION
                                });

            return a;
        }


        public IList<IFactura> GetFacturas()
        {
            try
            {
                return QFactura().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IFactura> GetFacturas(int skip, int take)
        {
            try
            {
                return QFactura().OrderBy(c => c.NombreInstitucion).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCountFacturas()
        {
            try
            {
                return QFactura().Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private IQueryable<IFactura> QFacturaLiquidacion()
        {
            var a = (from c in mDB.T_FACTURAS
                     where c.ESTADO == "A" && c.LIQUIDADA == "N"
                     select new Factura()
                                {
                                    Concepto = c.CONCEPTO,
                                    Estado = c.ESTADO,
                                    FechaAlta = c.FEC_ALTA,
                                    FechaModificacion = c.FEC_MODIF,
                                    IdFactura = c.ID_FACTURA,
                                    MontoTotal = c.MONTO_TOTAL,
                                    NroFactura = c.NRO_FACTURA,
                                    UsuarioAlta = c.USR_ALTA,
                                    UsuarioModificacion = c.USR_MODIF,
                                    IdCondicionCurso = c.T_CONDICIONES_CURSO.ID_CONDICION_CURSO,
                                    NombreCurso = c.T_CONDICIONES_CURSO.T_CURSOS.N_CURSO,
                                    NombreInstitucion = c.T_CONDICIONES_CURSO.T_INSTITUCIONES.N_INSTITUCION
                                });

            return a;
        }


        public IList<IFactura> GetFacturasbyLiquidacion()
        {
            try
            {
                return QFacturaLiquidacion().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IList<IFactura> GetFacturasbyLiquidacion(int skip, int take)
        {
            try
            {
                return QFacturaLiquidacion().OrderBy(c => c.NombreInstitucion).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCountFacturasbyLiquidacion()
        {
            try
            {
                return QFacturaLiquidacion().Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IFactura GetFacturabyId(int idFactura)
        {
            var factura = (from queryResult in mDB.T_FACTURAS
                           join c in mDB.T_DETALLES_FACTURA on queryResult.ID_FACTURA equals c.ID_FACTURA
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
                               NombreCurso = queryResult.T_CONDICIONES_CURSO.T_CURSOS.N_CURSO,
                               NombreInstitucion = queryResult.T_CONDICIONES_CURSO.T_INSTITUCIONES.N_INSTITUCION,


                               DetalleFactura = new DetalleFactura()
                               {
                                   Descripcion = c.DESCRIPCION,
                                   FechaAlta = c.FEC_ALTA,
                                   FechaModificacion = c.FEC_MODIF,
                                   Estado = c.ESTADO,
                                   IdDetalleFactura = c.ID_DETALLE_FACTURA,
                                   IdFactura = queryResult.ID_FACTURA,
                                   Item = c.ITEM,
                                   Monto = c.MONTO,
                                   UsuarioAlta = c.USR_ALTA,
                                   UsuarioModificacion = c.USR_MODIF
                               }
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
                    MONTO_TOTAL = 0,
                    NRO_FACTURA = factura.NroFactura,
                    USR_ALTA = factura.UsuarioAlta,
                    USR_MODIF = factura.UsuarioModificacion,
                    ID_CONDICION_CURSO = factura.IdCondicionCurso,
                    LIQUIDADA = "N"
                };

                mDB.AddToT_FACTURAS(facturas);
                mDB.SaveChanges();

                T_DETALLES_FACTURA obj = new T_DETALLES_FACTURA()
                                             {
                                                 ESTADO = factura.Estado,
                                                 FEC_ALTA = factura.FechaAlta,
                                                 DESCRIPCION = factura.DetalleFactura.Descripcion,
                                                 FEC_MODIF = factura.FechaModificacion,
                                                 ITEM = factura.DetalleFactura.Item,
                                                 USR_MODIF = factura.UsuarioModificacion,
                                                 USR_ALTA = factura.UsuarioAlta,
                                                 MONTO = factura.DetalleFactura.Monto,
                                                 ID_FACTURA = mDB.T_FACTURAS.OrderByDescending(c => c.ID_FACTURA).First().ID_FACTURA

                                             };
                mDB.AddToT_DETALLES_FACTURA(obj);
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

        public bool LiquidarFactura(int idFactura)
        {
            IComunDatos datos = new ComunDatos();
            base.AgregarDatosEliminacion(datos);

            try
            {
                var factura = mDB.T_FACTURAS.Where(c => c.ID_FACTURA == idFactura).FirstOrDefault();
                factura.LIQUIDADA = "S";
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