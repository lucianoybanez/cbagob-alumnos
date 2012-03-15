using System;
using System.Linq;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class ModalidadRepositorio : BaseRepositorio, IModalidadRepositorio
    {
        private CursosDB mDb;

        public ModalidadRepositorio(ILoggedUserHelper helper)
            : base(helper)
        {
            mDb = new CursosDB();
        }


        private IQueryable<IModalidad> QModalidad()
        {
            var a = (from c in mDb.T_MODALIDADES
                     where c.ESTADO == "A"
                     select
                         new Modalidad
                             {
                                 NombreModalidad = c.N_MODALIDAD,
                                 Nro_Resolucion = c.NRO_RESOLUCION,
                                 IdModalidad = c.ID_MODALIDAD
                             });

            return a;
        }


        public IList<IModalidad> GetModalidades()
        {
            try
            {
                return QModalidad().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IModalidad> GetModalidades(int skip, int take)
        {
            try
            {
                return QModalidad().OrderBy(c => c.NombreModalidad).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCountModalidad()
        {
            try
            {
                return QModalidad().Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IModalidad GetModalidad(int id_modalidad)
        {
            try
            {
                return QModalidad().Where(c => c.IdModalidad == id_modalidad).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarModalidad(IModalidad modalidad)
        {
            try
            {
                base.AgregarDatosAlta(modalidad);

                T_MODALIDADES t_modalidad = new T_MODALIDADES
                                                {
                                                    ESTADO = modalidad.Estado,
                                                    FEC_ALTA = modalidad.FechaAlta,
                                                    N_MODALIDAD = modalidad.NombreModalidad,
                                                    NRO_RESOLUCION = modalidad.Nro_Resolucion,
                                                    USR_ALTA = modalidad.UsuarioAlta,
                                                    USR_MODIF = modalidad.UsuarioModificacion,
                                                    FEC_MODIF = modalidad.FechaModificacion
                                                };

                mDb.AddToT_MODALIDADES(t_modalidad);
                mDb.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarModalidad(IModalidad modalidad)
        {
            try
            {
                base.AgregarDatosModificacion(modalidad);

                var updatemodalidad = mDb.T_MODALIDADES.FirstOrDefault(c => c.ID_MODALIDAD == modalidad.IdModalidad);

                updatemodalidad.FEC_MODIF = modalidad.FechaModificacion;
                updatemodalidad.USR_MODIF = modalidad.UsuarioModificacion;
                updatemodalidad.N_MODALIDAD = modalidad.NombreModalidad;
                

                mDb.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarModalidad(int idModalidad, string nro_resolucion)
        {
            try
            {
                IComunDatos modalidad = new ComunDatos();
                
                base.AgregarDatosEliminacion(modalidad);

                var updatemodalidad = mDb.T_MODALIDADES.FirstOrDefault(c => c.ID_MODALIDAD == idModalidad);

                updatemodalidad.ESTADO = modalidad.Estado;
                updatemodalidad.FEC_MODIF = modalidad.FechaModificacion;
                updatemodalidad.USR_MODIF = modalidad.UsuarioModificacion;
                updatemodalidad.NRO_RESOLUCION = nro_resolucion;


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