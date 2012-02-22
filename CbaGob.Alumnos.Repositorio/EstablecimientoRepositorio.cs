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
    public class EstablecimientoRepositorio : BaseRepositorio, IEstablecimientoRepositorio
    {

        private CursosDB mDB;

        public EstablecimientoRepositorio()
        {
            mDB = new CursosDB();
            mDB.ContextOptions.LazyLoadingEnabled = false;
        }

        #region "Get"
        private IQueryable<IEstablecimiento> QEstablecimiento()
        {
            var a = (from c in mDB.T_ESTABLECIMINETOS
                     where c.ESTADO == "A"
                     select
                         new Establecimiento
                             {
                                 Estado = c.ESTADO,
                                 FechaAlta = c.FEC_ALTA,
                                 FechaModificacion = c.FEC_ALTA,
                                 Id_Domicilio = c.ID_DOMICILIO,
                                 Id_Establecimiento = c.ID_ESTABLECIMIENTO,
                                 Id_Institucion = c.ID_INSTITUCION,
                                 N_Establecimiento = c.N_ESTABLECIMIENTO,
                                 UsuarioAlta = c.USR_ALTA,
                                 UsuarioModificacion = c.USR_MODIF
                             });

            return a;
        }

        public IList<IEstablecimiento> GetAllEstablecimiento()
        {
            try
            {
                var listaestablecimiento = QEstablecimiento().ToList();
                return listaestablecimiento;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IEstablecimiento> GetAllEstablecimientoByInstitucion(int id_institucion)
        {
            try
            {
                var listaestablecimiento = QEstablecimiento().Where(c => c.Id_Institucion == id_institucion).ToList();
                return listaestablecimiento;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEstablecimiento GetEstablecimiento(int id_establecimiento)
        {
            try
            {
                var establecimiento =
                    QEstablecimiento().Where(c => c.Id_Establecimiento == id_establecimiento).FirstOrDefault();
                return establecimiento;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region CRUD
        public bool AgregarEstablecimiento(IEstablecimiento establecimiento)
        {
            try
            {
                base.AgregarDatosAlta(establecimiento);

                T_ESTABLECIMINETOS t_estableciento = new T_ESTABLECIMINETOS()
                                                         {
                                                             ESTADO = establecimiento.Estado,
                                                             FEC_ALTA = establecimiento.FechaAlta,
                                                             FEC_MODIF = establecimiento.FechaModificacion,
                                                             ID_DOMICILIO = establecimiento.Id_Domicilio,
                                                             ID_INSTITUCION = establecimiento.Id_Institucion,
                                                             N_ESTABLECIMIENTO = establecimiento.N_Establecimiento,
                                                             USR_ALTA = establecimiento.UsuarioAlta,
                                                             USR_MODIF = establecimiento.UsuarioModificacion
                                                         };

                mDB.AddToT_ESTABLECIMINETOS(t_estableciento);
                mDB.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarEstablecimiento(IEstablecimiento establecimiento)
        {
            try
            {
                base.AgregarDatosModificacion(establecimiento);

                var modestablecimiento = mDB.T_ESTABLECIMINETOS.FirstOrDefault(c => c.ID_ESTABLECIMIENTO == establecimiento.Id_Establecimiento);

                modestablecimiento.ID_DOMICILIO = establecimiento.Id_Domicilio;
                modestablecimiento.ID_INSTITUCION = establecimiento.Id_Institucion;
                modestablecimiento.N_ESTABLECIMIENTO = establecimiento.N_Establecimiento;
                modestablecimiento.USR_MODIF = establecimiento.UsuarioModificacion;
                modestablecimiento.FEC_MODIF = establecimiento.FechaModificacion;
                mDB.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarEstablecimiento(int id_establecimiento)
        {
            try
            {
                IComunDatos comun = new ComunDatos();

                base.AgregarDatosEliminacion(comun);
                
                var modestablecimiento = mDB.T_ESTABLECIMINETOS.FirstOrDefault(c => c.ID_ESTABLECIMIENTO == id_establecimiento);

                modestablecimiento.ESTADO = comun.Estado;
                modestablecimiento.USR_MODIF = comun.UsuarioModificacion ;
                modestablecimiento.FEC_MODIF = comun.FechaModificacion;
                mDB.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
