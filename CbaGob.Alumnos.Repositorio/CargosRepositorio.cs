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
    public class CargosRepositorio : BaseRepositorio, ICargosRepositorio
    {
        private CursosDB mDB;

        public CargosRepositorio(ILoggedUserHelper helper)
            : base(helper)
        {
            mDB = new CursosDB();
        }


        private IQueryable<ICargos> QCargos()
        {
            try
            {
                var a =
                    (from c in mDB.T_CARGOS
                     where c.ESTADO == "A"
                     select new Cargos { Id_Cargo = c.ID_CARGO, N_Cargo = c.N_CARGO , Nro_Resolucion = c.NRO_RESOLUCION});

                return a;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public IList<ICargos> GetTodosCargos()
        {
            try
            {
                return QCargos().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICargos GetCargo(int idcargo)
        {
            try
            {
                return QCargos().Where(c => c.Id_Cargo == idcargo).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCargosCount()
        {
            try
            {
                return QCargos().Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<ICargos> GetTodosCargos(int skip, int take)
        {
            try
            {
                return QCargos().OrderBy(c => c.N_Cargo).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarCargo(ICargos cargo)
        {
            try
            {
                base.AgregarDatosAlta(cargo);


                T_CARGOS t_cargo = new T_CARGOS
                                       {
                                           ESTADO = cargo.Estado,
                                           FEC_ALTA = cargo.FechaAlta,
                                           FEC_MODIF = cargo.FechaModificacion,
                                           N_CARGO = cargo.N_Cargo,
                                           NRO_RESOLUCION = cargo.Nro_Resolucion,
                                           USR_ALTA = cargo.UsuarioAlta,
                                           USR_MODIF = cargo.UsuarioModificacion
                                       };

                mDB.AddToT_CARGOS(t_cargo);
                mDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarCargo(ICargos cargo)
        {
            try
            {
                base.AgregarDatosModificacion(cargo);

                var updatecargo = mDB.T_CARGOS.FirstOrDefault(c => c.ID_CARGO == cargo.Id_Cargo);

                updatecargo.FEC_MODIF = cargo.FechaModificacion;
                updatecargo.N_CARGO = cargo.N_Cargo;
                updatecargo.USR_MODIF = cargo.UsuarioModificacion;

                mDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarCargo(int id_cargo, string nro_resolucion)
        {
            try
            {
                IComunDatos datos = new ComunDatos();

                base.AgregarDatosEliminacion(datos);

                var updatecargo = mDB.T_CARGOS.FirstOrDefault(c => c.ID_CARGO == id_cargo);
                updatecargo.ESTADO = datos.Estado;
                updatecargo.FEC_MODIF = datos.FechaModificacion;
                updatecargo.NRO_RESOLUCION = nro_resolucion;
                updatecargo.USR_MODIF = datos.UsuarioModificacion;

                mDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
