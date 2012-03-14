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

        public EstablecimientoRepositorio(ILoggedUserHelper helper):base(helper)
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
                                 Id_Establecimiento = c.ID_ESTABLECIMIENTO,
                                 Id_Institucion = c.ID_INSTITUCION,
                                 NombreEstablecimiento = c.N_ESTABLECIMIENTO,
                                 UsuarioAlta = c.USR_ALTA,
                                 UsuarioModificacion = c.USR_MODIF,
                                 Provincia = c.PROVINCIA ?? "",
                                 Localidad = c.LOCALIDAD ?? "",
                                 Barrio = c.BARRIO ?? "",
                                 Calle = c.CALLE ?? "",
                                 Nro = c.NRO ?? 0,
                                 Depto = c.DEPTO ?? 0,
                                 Telefono = c.TELEFONO ?? "",
                                 Emial = c.EMAIL ?? "",
                                 Resposable = c.RESPONSABLE ?? "",
                                 Nro_Resolucion = c.NRO_RESOLUCION ?? "",
                                 NombreInstitucion = c.T_INSTITUCIONES.N_INSTITUCION,
                                 DomicilioCompleto =
                                     c.PROVINCIA ??
                                     "." + "," + c.LOCALIDAD ??
                                     "." + "," + c.BARRIO ?? "." + "," + c.CALLE ?? "."
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
                                                             ID_INSTITUCION = establecimiento.Id_Institucion,
                                                             N_ESTABLECIMIENTO = establecimiento.NombreEstablecimiento,
                                                             USR_ALTA = establecimiento.UsuarioAlta,
                                                             USR_MODIF = establecimiento.UsuarioModificacion,
                                                             RESPONSABLE = establecimiento.Resposable,
                                                             EMAIL = establecimiento.Emial,
                                                             TELEFONO = establecimiento.Telefono,
                                                             PROVINCIA = establecimiento.Provincia,
                                                             LOCALIDAD = establecimiento.Localidad,
                                                             BARRIO = establecimiento.Barrio,
                                                             NRO = establecimiento.Nro,
                                                             DEPTO = establecimiento.Depto,
                                                             CALLE = establecimiento.Calle,
                                                             NRO_RESOLUCION = establecimiento.Nro_Resolucion
                                                         };

                mDB.AddToT_ESTABLECIMINETOS(t_estableciento);
                mDB.SaveChanges();
                return true;

            }
            catch (Exception ex)
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

                modestablecimiento.ID_INSTITUCION = establecimiento.Id_Institucion;
                modestablecimiento.N_ESTABLECIMIENTO = establecimiento.NombreEstablecimiento;
                modestablecimiento.USR_MODIF = establecimiento.UsuarioModificacion;
                modestablecimiento.FEC_MODIF = establecimiento.FechaModificacion;
                modestablecimiento.RESPONSABLE = establecimiento.Resposable;
                modestablecimiento.TELEFONO = establecimiento.Telefono;
                modestablecimiento.EMAIL = establecimiento.Emial;
                modestablecimiento.BARRIO = establecimiento.Barrio;
                modestablecimiento.CALLE = establecimiento.Calle;
                modestablecimiento.LOCALIDAD = establecimiento.Localidad;
                modestablecimiento.NRO = establecimiento.Nro;
                modestablecimiento.DEPTO = establecimiento.Depto;
                modestablecimiento.PROVINCIA = establecimiento.Provincia;
                modestablecimiento.NRO_RESOLUCION = establecimiento.Nro_Resolucion;

                mDB.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool EliminarEstablecimiento(int id_establecimiento, string nroresolucion)
        {
            try
            {
                IComunDatos comun = new ComunDatos();

                base.AgregarDatosEliminacion(comun);

                var modestablecimiento = mDB.T_ESTABLECIMINETOS.FirstOrDefault(c => c.ID_ESTABLECIMIENTO == id_establecimiento);

                modestablecimiento.ESTADO = comun.Estado;
                modestablecimiento.USR_MODIF = comun.UsuarioModificacion;
                modestablecimiento.FEC_MODIF = comun.FechaModificacion;
                mDB.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
