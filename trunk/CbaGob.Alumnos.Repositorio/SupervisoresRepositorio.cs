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
    public class SupervisoresRepositorio : BaseRepositorio, ISupervisoresRepositorio
    {
        private CursosDB mDb;

        public SupervisoresRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDb = new CursosDB();
        }


        private IQueryable<ISupervisores> QSupervisores()
        {
            try
            {
                var a = (from c in mDb.T_SUPERVISORES
                         where c.ESTADO == "A"
                         select
                             new Supervisores
                                 {
                                     Id_Supervisor = c.ID_SUPERVISOR,
                                     Razon_Social = c.RAZON_SOCIAL,
                                     Cuil_Cuit = c.CUIL_CUIT,
                                     DatosCompletoPersonajur = c.CUIL_CUIT + "," + c.RAZON_SOCIAL,
                                     Provincia = c.PROVINCIA,
                                     Localidad = c.LOCALIDAD,
                                     Barrio = c.BARRIO,
                                     Calle = c.CALLE,
                                     Nro = c.NRO ?? 0,
                                     Nro_Resolucion = c.NRO_RESOLUCION,
                                     UsuarioAlta = c.USR_ALTA

                                 });

                return a;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IList<ISupervisores> GetSupervisores()
        {
            try
            {
                var listaretorno = QSupervisores().ToList();
                return listaretorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<ISupervisores> GetSupervisores(int skip, int take)
        {
            try
            {
                var listaretorno = QSupervisores().OrderBy( c => c.Razon_Social).Skip(skip).Take(take).ToList();
                return listaretorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCountSupervisor()
        {
            try
            {
                return QSupervisores().Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<ISupervisores> GetSupervisoresByRazonSocial(string razonsocial)
        {
            try
            {
                var listaretorno = QSupervisores().Where(c => c.Razon_Social.StartsWith(razonsocial)).ToList();
                return listaretorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ISupervisores GetSupervisor(int idsupervisor)
        {
            try
            {
                var retorno = QSupervisores().Where(c => c.Id_Supervisor == idsupervisor).SingleOrDefault();
                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarSupervisor(ISupervisores supervisor)
        {
            try
            {
                base.AgregarDatosAlta(supervisor);
                T_SUPERVISORES t_supervisores = new T_SUPERVISORES()
                                                    {
                                                        ESTADO = supervisor.Estado,
                                                        USR_ALTA = supervisor.UsuarioAlta,
                                                        USR_MODIF = supervisor.UsuarioModificacion,
                                                        FEC_ALTA = supervisor.FechaAlta,
                                                        FEC_MODIF = supervisor.FechaModificacion,
                                                        RAZON_SOCIAL = supervisor.Razon_Social,
                                                        CUIL_CUIT = supervisor.Cuil_Cuit,
                                                        PROVINCIA = supervisor.Provincia,
                                                        LOCALIDAD = supervisor.Localidad,
                                                        BARRIO = supervisor.Barrio,
                                                        CALLE = supervisor.Calle,
                                                        NRO = supervisor.Nro,
                                                        NRO_RESOLUCION = supervisor.Nro_Resolucion

                                                    };

                mDb.AddToT_SUPERVISORES(t_supervisores);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool ModificarSupervisor(ISupervisores supervisor)
        {
            try
            {
                base.AgregarDatosModificacion(supervisor);

                var t_supervisor = mDb.T_SUPERVISORES.Where(c => c.ID_SUPERVISOR == supervisor.Id_Supervisor).FirstOrDefault();


                t_supervisor.USR_MODIF = supervisor.UsuarioModificacion;
                t_supervisor.FEC_MODIF = supervisor.FechaModificacion;
                t_supervisor.RAZON_SOCIAL = supervisor.Razon_Social;
                t_supervisor.CUIL_CUIT = supervisor.Cuil_Cuit;
                t_supervisor.PROVINCIA = supervisor.Provincia;
                t_supervisor.LOCALIDAD = supervisor.Localidad;
                t_supervisor.BARRIO = supervisor.Barrio;
                t_supervisor.CALLE = supervisor.Calle;
                t_supervisor.NRO = supervisor.Nro;
                t_supervisor.NRO_RESOLUCION = supervisor.Nro_Resolucion;

                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool EliminarSupervisor(int idsupervisor, string nro_resolucion)
        {
            try
            {
                IComunDatos supervisor = new ComunDatos();
                base.AgregarDatosEliminacion(supervisor);

                var t_supervisor = mDb.T_SUPERVISORES.Where(c => c.ID_SUPERVISOR == idsupervisor).FirstOrDefault();

                t_supervisor.ESTADO = supervisor.Estado;
                t_supervisor.USR_MODIF = supervisor.UsuarioModificacion;
                t_supervisor.FEC_MODIF = supervisor.FechaModificacion;
                t_supervisor.NRO_RESOLUCION = nro_resolucion;

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
