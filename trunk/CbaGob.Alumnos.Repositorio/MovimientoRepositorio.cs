using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class MovimientoRepositorio : BaseRepositorio, IMovimientoRepositorio
    {

        private CursosDB mDb;

        public MovimientoRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDb = new CursosDB();
        }

        private IQueryable<IMovimiento> QMovimiento()
        {
            var a = (from c in mDb.T_MOVIMIENTOS
                     where c.ESTADO == "A"
                     select
                         new Movimiento
                             {
                                 Descripcion = c.DESCRIPCION,
                                 Estado = c.ESTADO,
                                 Fecha = c.FECHA,
                                 Id_Caja_Chica = c.ID_CAJA_CHICA,
                                 FechaAlta = c.FEC_ALTA,
                                 FechaModificacion = c.FEC_MODIF,
                                 Id_Movimiento = c.ID_MOVIMIENTO,
                                 Monto = c.MONTO,
                                 Id_Tipo_Movimiento = c.ID_TIPO_MOVIMIENTO,
                                 MontoCaja = c.T_CAJA_CHICA.MONTO,
                                 NombreTipoMovimiento = c.T_TIPOS_MOVIMIENTOS.N_TIPO_MOVIMIENTO,
                                 NombreInstitucion = c.T_CAJA_CHICA.T_INSTITUCIONES.N_INSTITUCION,
                                 UsuarioAlta = c.USR_ALTA,
                                 UsuarioModificacion = c.USR_MODIF,
                                 Nombre_Movimiento = c.N_MOVIMIENTO,
                                 Id_Institucion = c.T_CAJA_CHICA.T_INSTITUCIONES.ID_INSTITUCION  
                             });


            return a;
        }

        private IQueryable<ITipo_Movimiento> QTipoMovimiento()
        {
            var a = (from c in mDb.T_TIPOS_MOVIMIENTOS
                     where c.ESTADO == "A"
                     select
                         new Tipo_Movimiento
                             {Id_Tipo_Movimiento = c.ID_TIPO_MOVIMIENTO, Nombre_Tipo_Movimiento = c.N_TIPO_MOVIMIENTO});
            return a;
        }

        public IList<IMovimiento> GetMovimientosByCajaChica(int id_caja_chica)
        {
            try
            {
                return QMovimiento().Where(c => c.Id_Caja_Chica == id_caja_chica).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IList<ITipo_Movimiento> GetTiposMovimiento()
        {
            try
            {
                return QTipoMovimiento().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IMovimiento GetMovimiento(int Id_Movimento)
        {
            try
            {
                return QMovimiento().Where(c => c.Id_Movimiento == Id_Movimento).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarMovimiento(IMovimiento movimiento)
        {
            try
            {
                base.AgregarDatosAlta(movimiento);

                T_MOVIMIENTOS t_movimiento = new T_MOVIMIENTOS()
                                                 {
                                                     DESCRIPCION = movimiento.Descripcion,
                                                     MONTO = movimiento.Monto,
                                                     N_MOVIMIENTO = movimiento.Nombre_Movimiento,
                                                     FEC_ALTA = movimiento.FechaAlta,
                                                     FEC_MODIF = movimiento.FechaModificacion,
                                                     FECHA = movimiento.Fecha,
                                                     USR_ALTA = movimiento.UsuarioAlta,
                                                     USR_MODIF = movimiento.UsuarioModificacion,
                                                     ID_CAJA_CHICA = movimiento.Id_Caja_Chica,
                                                     ID_TIPO_MOVIMIENTO = movimiento.Id_Tipo_Movimiento,
                                                     ESTADO = movimiento.Estado
                                                 };

                mDb.AddToT_MOVIMIENTOS(t_movimiento);
                mDb.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarMovimiento(IMovimiento movimiento)
        {
            try
            {
                base.AgregarDatosModificacion(movimiento);
                var mov = mDb.T_MOVIMIENTOS.FirstOrDefault(c => c.ID_MOVIMIENTO == movimiento.Id_Movimiento);

                mov.DESCRIPCION = movimiento.Descripcion;
                mov.MONTO = movimiento.Monto;
                mov.N_MOVIMIENTO = movimiento.Nombre_Movimiento;
                mov.FEC_MODIF = movimiento.FechaModificacion;
                mov.FECHA = movimiento.Fecha;
                mov.USR_MODIF = movimiento.UsuarioModificacion;
                mov.ID_CAJA_CHICA = movimiento.Id_Caja_Chica;
                mov.ID_TIPO_MOVIMIENTO = movimiento.Id_Tipo_Movimiento;

                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public bool EliminarMovimiento(int id_movimiento)
        {
            try
            {
                IComunDatos movimiento = new ComunDatos();
                base.AgregarDatosEliminacion(movimiento);
                var mov = mDb.T_MOVIMIENTOS.FirstOrDefault(c => c.ID_MOVIMIENTO == id_movimiento);

                mov.ESTADO = movimiento.Estado;
                mov.FEC_MODIF = movimiento.FechaModificacion;
                mov.USR_MODIF = movimiento.UsuarioModificacion;

                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
