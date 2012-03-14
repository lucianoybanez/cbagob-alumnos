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
    public class HorarioRepositorio : BaseRepositorio, IHorarioRepositorio
    {
        public CursosDB mDb;

        public HorarioRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDb = new CursosDB();
        }

        private IQueryable<IHorario> QHorario()
        {
            var a = (from c in mDb.T_HORARIOS
                     where c.ESTADO == "A"
                     select
                         new Horario
                             {
                                 Año = c.HR_AÑO,
                                 Dia_Semana = c.HR_DIASEMANA,
                                 Hora_Fin = c.HR_FIN,
                                 Hora_Inicio = c.HR_FIN,
                                 Mes = c.HR_MES,
                                 Id_Horario = c.ID_HORARIO
                             });
            return a;
        }

        public IList<IHorario> GetHorarios()
        {
            try
            {
                return QHorario().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IHorario> GetHorariosForGrupo(int id_grupo)
        {
            try
            {
                var ListRetorno = (from c in mDb.T_HORARIOS
                                   where
                                       c.ESTADO == "A" &&
                                       !(from d in mDb.T_GRUPOS_HORARIO
                                         where d.ESTADO == "A" && d.ID_GRUPO == id_grupo
                                         select d.ID_HORARIO).Contains(c.ID_HORARIO)
                                   select
                                       new Horario
                                           {
                                               Año = c.HR_AÑO,
                                               Dia_Semana = c.HR_DIASEMANA,
                                               Hora_Fin = c.HR_FIN,
                                               Hora_Inicio = c.HR_INICIO,
                                               Mes = c.HR_MES,
                                               Id_Horario = c.ID_HORARIO
                                           }).ToList().Cast<IHorario>().ToList();


                return ListRetorno;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IHorario> GetHorariosByGrupo(int id_grupo)
        {
            try
            {
                var ListRetorno = (from c in mDb.T_HORARIOS
                                   where
                                       c.ESTADO == "A" &&
                                       (from d in mDb.T_GRUPOS_HORARIO
                                        where d.ESTADO == "A" && d.ID_GRUPO == id_grupo
                                        select d.ID_HORARIO).Contains(c.ID_HORARIO)
                                   select
                                       new Horario
                                       {
                                           Año = c.HR_AÑO,
                                           Dia_Semana = c.HR_DIASEMANA,
                                           Hora_Fin = c.HR_FIN,
                                           Hora_Inicio = c.HR_INICIO,
                                           Mes = c.HR_MES,
                                           Id_Horario = c.ID_HORARIO
                                       }).ToList().Cast<IHorario>().ToList();


                return ListRetorno;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool AgregarHorarioAGrupo(int id_grupo, int id_horario)
        {
            try
            {
                IComunDatos datos = new ComunDatos();
                base.AgregarDatosAlta(datos);

                T_GRUPOS_HORARIO t_grupo_horario = new T_GRUPOS_HORARIO();

                t_grupo_horario.ID_GRUPO = id_grupo;
                t_grupo_horario.ID_HORARIO = id_horario;
                t_grupo_horario.ESTADO = datos.Estado;
                t_grupo_horario.FEC_ALTA = datos.FechaAlta;
                t_grupo_horario.USR_ALTA = datos.UsuarioAlta;
                t_grupo_horario.FEC_BAJA = datos.FechaModificacion;
                t_grupo_horario.USR_BAJA = datos.UsuarioModificacion;

                mDb.AddToT_GRUPOS_HORARIO(t_grupo_horario);
                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public bool SacarHorarioAGrupo(int id_grupo, int id_horario)
        {
            try
            {
                var t_grupo_horario = mDb.T_GRUPOS_HORARIO.Where(c => c.ID_GRUPO == id_grupo && c.ID_HORARIO == id_horario).FirstOrDefault();

                mDb.DeleteObject(t_grupo_horario);
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
