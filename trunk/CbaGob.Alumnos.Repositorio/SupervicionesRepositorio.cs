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
    public class SupervicionesRepositorio : BaseRepositorio, ISupervicionesRepositorio
    {

        private CursosDB mDb;

        public SupervicionesRepositorio()
        {
            mDb = new CursosDB();
        }

        private IQueryable<ISuperviciones> QSuperviciones()
        {
            try
            {
                var a = (from c in mDb.T_SUPERVICIONES
                         where c.ESTADO == "A"
                         select
                             new Superviciones
                             {
                                 Estado = c.ESTADO,
                                 Fec_Supervision = c.FEC_SUPERVISION,
                                 FechaAlta = c.FEC_ALTA,
                                 FechaModificacion = c.FEC_MODIF,
                                 Hs_Supervision = c.HS_SUPERVISION,
                                 Id_Grupo = c.ID_GRUPO,
                                 Id_Supervision = c.ID_SUPERVISION,
                                 Id_Supervisor = c.ID_SUPERVISOR,
                                 NombreCurso = c.T_GRUPOS.T_CONDICIONES_CURSO.T_CURSOS.N_CURSO,
                                 NombreInstitucion = c.T_GRUPOS.T_CONDICIONES_CURSO.T_INSTITUCIONES.N_INSTITUCION,
                                 NombrePersonaJuridica = c.T_SUPERVISORES.T_PERSONASJUR.RAZON_SOCIAL,   
                                 NombreGrupo = c.T_GRUPOS.N_GRUPO,
                                 UsuarioAlta = c.USR_ALTA,
                                 UsuarioModificacion = c.USR_MODIF,
                                 Observaciones = c.OBSERVACIONES
                             });

                return a;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IList<ISuperviciones> GetSuperviciones()
        {
            try
            {
                return QSuperviciones().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ISuperviciones GetSupervicion(int idsupervision)
        {
            try
            {
                return QSuperviciones().Where(c => c.Id_Supervision == idsupervision).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarSuperviciones(ISuperviciones supervicion)
        {
            try
            {
                base.AgregarDatosAlta(supervicion);
                T_SUPERVICIONES t_supervicion = new T_SUPERVICIONES()
                                                    {
                                                        ID_GRUPO = supervicion.Id_Grupo,
                                                        ID_SUPERVISOR = supervicion.Id_Supervisor,
                                                        ESTADO = supervicion.Estado,
                                                        FEC_ALTA = supervicion.FechaAlta,
                                                        FEC_SUPERVISION = supervicion.Fec_Supervision,
                                                        HS_SUPERVISION = supervicion.Hs_Supervision,
                                                        OBSERVACIONES = supervicion.Observaciones,
                                                        FEC_MODIF = supervicion.FechaModificacion,
                                                        USR_MODIF = supervicion.UsuarioModificacion,
                                                        USR_ALTA = supervicion.UsuarioAlta
                                                    };


                mDb.AddToT_SUPERVICIONES(t_supervicion);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool ModificarSuperviciones(ISuperviciones supervicion)
        {
            try
            {
                base.AgregarDatosModificacion(supervicion);

                var t_supervisiones = mDb.T_SUPERVICIONES.Where(c => c.ID_SUPERVISION == supervicion.Id_Supervision).FirstOrDefault();

                t_supervisiones.ID_GRUPO = supervicion.Id_Grupo;
                t_supervisiones.FEC_SUPERVISION = supervicion.Fec_Supervision;
                t_supervisiones.FEC_MODIF = supervicion.Fec_Supervision;
                t_supervisiones.USR_MODIF = supervicion.UsuarioModificacion;
                t_supervisiones.HS_SUPERVISION = supervicion.Hs_Supervision;
                t_supervisiones.OBSERVACIONES = supervicion.Observaciones;


                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool EliminarSuperviciones(int idsupervicion)
        {
            try
            {
                IComunDatos datos = new ComunDatos();
                base.AgregarDatosEliminacion(datos);

                var t_supervisiones = mDb.T_SUPERVICIONES.Where(c => c.ID_SUPERVISION == idsupervicion).FirstOrDefault();

                t_supervisiones.ESTADO = datos.Estado;
                t_supervisiones.FEC_MODIF = datos.FechaModificacion;
                t_supervisiones.USR_MODIF = datos.UsuarioModificacion;


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
