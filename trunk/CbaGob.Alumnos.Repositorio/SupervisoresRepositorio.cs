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

        public SupervisoresRepositorio()
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
                                     Id_Domicilio = c.ID_DOMICILIO,
                                     Id_PersonaJuridica = c.ID_PERSONAJUR,
                                     Id_Supervisor = c.ID_SUPERVISOR,
                                     RazonSocial = c.T_PERSONASJUR.RAZON_SOCIAL,
                                     Cuit = c.T_PERSONASJUR.CUIT,
                                     DatosCompletoPersonajur = c.T_PERSONASJUR.CUIT + "," + c.T_PERSONASJUR.RAZON_SOCIAL,
                                     DomicilioCompleto =
                                         c.T_DOMICILIO.PROVINCIA + "," + c.T_DOMICILIO.LOCALIDAD + "," +
                                         c.T_DOMICILIO.BARRIO + "," + c.T_DOMICILIO.CALLE + "," + c.T_DOMICILIO.NRO
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

        public IList<ISupervisores> GetSupervisoresByRazonSocial(string razonsocial)
        {
            try
            {
                var listaretorno = QSupervisores().Where(c => c.RazonSocial.StartsWith(razonsocial)).ToList();
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
                                                        ID_DOMICILIO = supervisor.Id_Domicilio,
                                                        ID_PERSONAJUR = supervisor.Id_PersonaJuridica,
                                                        ESTADO = supervisor.Estado,
                                                        USR_ALTA = supervisor.UsuarioAlta,
                                                        USR_MODIF = supervisor.UsuarioModificacion,
                                                        FEC_ALTA = supervisor.FechaAlta,
                                                        FEC_MODIF = supervisor.FechaModificacion
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

                t_supervisor.ID_DOMICILIO = supervisor.Id_Domicilio;
                t_supervisor.ID_PERSONAJUR = supervisor.Id_PersonaJuridica;
                t_supervisor.USR_MODIF = supervisor.UsuarioModificacion;
                t_supervisor.FEC_MODIF = supervisor.FechaModificacion;

                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool EliminarSupervisor(int idsupervisor)
        {
            try
            {
                IComunDatos supervisor = new ComunDatos();
                base.AgregarDatosEliminacion(supervisor);

                var t_supervisor = mDb.T_SUPERVISORES.Where(c => c.ID_SUPERVISOR == idsupervisor).FirstOrDefault();

                t_supervisor.ESTADO = supervisor.Estado;
                t_supervisor.USR_MODIF = supervisor.UsuarioModificacion;
                t_supervisor.FEC_MODIF = supervisor.FechaModificacion;

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
