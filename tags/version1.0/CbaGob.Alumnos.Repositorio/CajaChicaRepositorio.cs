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
    public class CajaChicaRepositorio : BaseRepositorio, ICajaChicaRepositorio
    {

        private CursosDB mDb;

        public CajaChicaRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDb = new CursosDB();
        }


        private IQueryable<ICajaChica> QCajaChica()
        {
            var a =
                (from c in mDb.T_CAJA_CHICA
                 where c.ESTADO == "A"
                 select
                     new CajaChica
                         {
                             Estado = c.ESTADO,
                             FechaAlta = c.FEC_ALTA,
                             Id_Caja_Chica = c.ID_CAJA_CHICA,
                             Id_Institucion = c.ID_INSTITUCION,
                             FechaModificacion = c.FEC_MODIF,
                             NombreEstadoCaja = c.T_ESTADOS_CAJA_CHICA.N_ESTADO_CAJA_CHICA,
                             NombreInstitucion = c.T_INSTITUCIONES.N_INSTITUCION,
                             Id_Estado_Caja_Chica = c.ID_ESTADO_CAJA_CHICA,
                             Monto = c.MONTO,
                             UsuarioAlta = c.USR_ALTA,
                             UsuarioModificacion = c.USR_MODIF

                         });
            return a;
        }


        public IList<ICajaChica> GetCajaChicas()
        {
            try
            {
                return QCajaChica().ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<ICajaChica> GetCajaChicasByInstitucion(int id_institucion)
        {
            try
            {
                return QCajaChica().Where(c => c.Id_Institucion == id_institucion).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ICajaChica GetCajaChica(int idcajachica)
        {
            try
            {
                return QCajaChica().Where(c => c.Id_Caja_Chica == idcajachica).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private IQueryable<IEstadoCajaChica> QEstadoCajaChica()
        {
            var a = (from c in mDb.T_ESTADOS_CAJA_CHICA
                     select
                         new EstadoCajaChica { Id_Estado_Caja_Chica = c.ID_ESTADO_CAJA_CHICA, Nombre_estado = c.N_ESTADO_CAJA_CHICA });
            return a;
        }

        public IList<IEstadoCajaChica> GetEstadoCajaChicas()
        {
            try
            {
                return QEstadoCajaChica().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarCajaChica(ICajaChica cajachica)
        {
            try
            {
                base.AgregarDatosAlta(cajachica);

                T_CAJA_CHICA t_caja_chica = new T_CAJA_CHICA()
                                                {
                                                    ESTADO = cajachica.Estado,
                                                    ID_ESTADO_CAJA_CHICA = cajachica.Id_Estado_Caja_Chica,
                                                    MONTO = Convert.ToDecimal(cajachica.Monto),
                                                    USR_ALTA = cajachica.UsuarioAlta,
                                                    USR_MODIF = cajachica.UsuarioModificacion,
                                                    FEC_ALTA = cajachica.FechaAlta,
                                                    FEC_MODIF = cajachica.FechaModificacion,
                                                    ID_INSTITUCION = cajachica.Id_Institucion,

                                                };

                mDb.AddToT_CAJA_CHICA(t_caja_chica);
                mDb.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool ModificaCajaChica(ICajaChica cajachica)
        {
            try
            {
                base.AgregarDatosModificacion(cajachica);
                var cur = mDb.T_CAJA_CHICA.FirstOrDefault(c => c.ID_CAJA_CHICA == cajachica.Id_Caja_Chica);
                cur.ID_ESTADO_CAJA_CHICA = cajachica.Id_Estado_Caja_Chica;
                cur.MONTO = cajachica.Monto;
                cur.USR_MODIF = cajachica.UsuarioModificacion;
                cur.FEC_MODIF = cajachica.FechaModificacion;
                cur.ID_INSTITUCION = cajachica.Id_Institucion;

                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool EliminarCajaChica(int idcajachica)
        {
            try
            {
                IComunDatos cajachica = new ComunDatos();
                base.AgregarDatosEliminacion(cajachica);
                var cur = mDb.T_CAJA_CHICA.FirstOrDefault(c => c.ID_CAJA_CHICA == idcajachica);
                cur.ESTADO = cajachica.Estado;
                cur.USR_MODIF = cajachica.UsuarioModificacion;
                cur.FEC_MODIF = cajachica.FechaModificacion;


                mDb.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
