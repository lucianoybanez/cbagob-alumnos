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
    public class EquipoRepositorio : BaseRepositorio, IEquipoRepositorio
    {
        private CursosDB mDb;

        public EquipoRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDb = new CursosDB();
        }

        private IQueryable<IEquipo> QEquipo()
        {
            try
            {
                var a = (from c in mDb.T_EQUIPOS
                         where c.ESTADO == "A"
                         select
                             new Equipo
                                 {
                                     Estado = c.ESTADO,
                                     FechaAlta = c.FEC_ALTA,
                                     FechaModificacion = c.FEC_MODIF,
                                     Id_Equipo = c.ID_EQUIPO,
                                     Id_Estado_Equipo = c.ID_ESTADO_EQUIPO,
                                     N_Equipos = c.N_EQUIPOS,
                                     NombreEstadoEquipo = c.T_ESTADOS_EQUIPO.N_ESTADO_EQUIPO,
                                     UsuarioAlta = c.USR_ALTA,
                                     UsuarioModificacion = c.USR_MODIF
                                 });
                return a;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IEquipo> GetEquipos()
        {
            try
            {
                return QEquipo().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IEquipo> GetEquiposByEstado(int id_estado_equipo)
        {
            try
            {
                return QEquipo().Where(c => c.Id_Estado_Equipo == id_estado_equipo).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEquipo GetEquipo(int id_equipo)
        {
            try
            {
                return QEquipo().Where(c => c.Id_Equipo == id_equipo).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AgregarEquipo(IEquipo equipo)
        {
            try
            {
                base.AgregarDatosAlta(equipo);
                T_EQUIPOS t_equipo = new T_EQUIPOS()
                                         {
                                             ESTADO = equipo.Estado,
                                             FEC_ALTA = equipo.FechaAlta,
                                             FEC_MODIF = equipo.FechaModificacion,
                                             USR_ALTA = equipo.UsuarioAlta,
                                             USR_MODIF = equipo.UsuarioModificacion,
                                             ID_ESTADO_EQUIPO = equipo.Id_Estado_Equipo,
                                             N_EQUIPOS = equipo.N_Equipos
                                         };

                mDb.AddToT_EQUIPOS(t_equipo);
                mDb.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ModificarEquipo(IEquipo equipo)
        {
            try
            {
                base.AgregarDatosModificacion(equipo);

                var t_supervisiones = mDb.T_EQUIPOS.Where(c => c.ID_EQUIPO == equipo.Id_Equipo).FirstOrDefault();

                t_supervisiones.FEC_MODIF = equipo.FechaModificacion;
                t_supervisiones.USR_MODIF = equipo.UsuarioModificacion;
                t_supervisiones.N_EQUIPOS = equipo.N_Equipos;
                t_supervisiones.ID_ESTADO_EQUIPO = equipo.Id_Estado_Equipo;

                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool EliminarEquipo(int id_equipo)
        {
            try
            {

                IComunDatos equipo = new ComunDatos();
                base.AgregarDatosEliminacion(equipo);

                var t_supervisiones = mDb.T_EQUIPOS.Where(c => c.ID_EQUIPO == id_equipo).FirstOrDefault();

                t_supervisiones.FEC_MODIF = equipo.FechaModificacion;
                t_supervisiones.USR_MODIF = equipo.UsuarioModificacion;
                t_supervisiones.ESTADO = equipo.Estado;

                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool CambiarEstadoEquipo(int id_equipo, int id_estado_equipo)
        {
            try
            {
                IComunDatos equipo = new ComunDatos();

                base.AgregarDatosModificacion(equipo);

                var t_supervisiones = mDb.T_EQUIPOS.Where(c => c.ID_EQUIPO == id_equipo).FirstOrDefault();

                t_supervisiones.FEC_MODIF = equipo.FechaModificacion;
                t_supervisiones.USR_MODIF = equipo.UsuarioModificacion;
                t_supervisiones.ID_ESTADO_EQUIPO = id_estado_equipo;

                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IEquipo> BusquedaEquipo(string nombreequipo)
        {
            try
            {
                return QEquipo().Where(c => c.N_Equipos == nombreequipo || nombreequipo == null).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
