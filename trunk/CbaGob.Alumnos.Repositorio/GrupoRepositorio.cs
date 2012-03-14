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
    public class GrupoRepositorio : BaseRepositorio, IGrupoRepositorio
    {
        private CursosDB mDB;

        public GrupoRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDB = new CursosDB();
            mDB.ContextOptions.LazyLoadingEnabled = false;
        }

        #region "Get"

        private IQueryable<IGrupo> QGrupo()
        {
            var g = (from d in mDB.T_GRUPOS
                     where d.ESTADO == "A"
                     select
                         new Grupo
                             {

                                 Id_Condicion_Curso = d.ID_CONDICION_CURSO,
                                 Id_Establecimiento = d.ID_ESTABLECIMIENTO,
                                 Id_Grupo = d.ID_GRUPO,
                                 Capacidad = d.CAPACIDAD ?? 0,
                                 NombreEstablecimiento = d.T_ESTABLECIMINETOS.N_ESTABLECIMIENTO,
                                 FechaAlta = d.FEC_ALTA,
                                 FechaModificacion = d.FEC_MODIF ?? System.DateTime.Now,
                                 UsuarioAlta = d.USR_ALTA,
                                 UsuarioModificacion = d.USR_MODIF,
                                 NombreGrupo = d.N_GRUPO,
                                 Nombre_Curso = d.T_CONDICIONES_CURSO.T_CURSOS.N_CURSO,
                                 Id_Institucion = d.T_CONDICIONES_CURSO.ID_INSTITUCION,
                                 Nombre_Institucion = d.T_CONDICIONES_CURSO.T_INSTITUCIONES.N_INSTITUCION,
                                 Provincia = d.T_ESTABLECIMINETOS.PROVINCIA,
                                 Localidad = d.T_ESTABLECIMINETOS.LOCALIDAD,
                                 Barrio = d.T_ESTABLECIMINETOS.BARRIO,
                                 Calle = d.T_ESTABLECIMINETOS.CALLE,
                                 Nro = d.T_ESTABLECIMINETOS.NRO ?? 0,
                                 Nro_Resolucion = d.NRO_RESOLUCION


                             });

            return g;
        }

        public IGrupo GetGrupo(int id_grupo)
        {
            try
            {
                var resultado = QGrupo().Where(c => c.Id_Grupo == id_grupo).FirstOrDefault();
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IGrupo> GetAllGrupo()
        {
            try
            {
                var resultado = QGrupo().ToList();
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IGrupo> GetAllGrupoByCurso(int id_condicioncurso)
        {
            try
            {
                var resultado = QGrupo().Where(c => c.Id_Condicion_Curso == id_condicioncurso).ToList();
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region CRUD
        public bool AgregarGrupo(IGrupo grupo)
        {
            try
            {
                base.AgregarDatosAlta(grupo);
                T_GRUPOS t_grupo = new T_GRUPOS()
                                       {
                                           CAPACIDAD = grupo.Capacidad,
                                           ID_CONDICION_CURSO = grupo.Id_Condicion_Curso,
                                           ID_ESTABLECIMIENTO = grupo.Id_Establecimiento,
                                           FEC_ALTA = grupo.FechaAlta,
                                           FEC_MODIF = grupo.FechaModificacion,
                                           USR_ALTA = grupo.UsuarioAlta,
                                           USR_MODIF = grupo.UsuarioModificacion,
                                           ESTADO = grupo.Estado,
                                           N_GRUPO = grupo.NombreGrupo,
                                           NRO_RESOLUCION = grupo.Nro_Resolucion
                                       };

                mDB.AddToT_GRUPOS(t_grupo);
                mDB.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarGrupo(IGrupo grupo)
        {
            try
            {
                base.AgregarDatosModificacion(grupo);
                var t_grupo = mDB.T_GRUPOS.Where(c => c.ID_GRUPO == grupo.Id_Grupo).FirstOrDefault();

                t_grupo.ID_CONDICION_CURSO = grupo.Id_Condicion_Curso;
                t_grupo.ID_ESTABLECIMIENTO = grupo.Id_Establecimiento;
                t_grupo.CAPACIDAD = grupo.Capacidad;
                t_grupo.N_GRUPO = grupo.NombreGrupo;
                t_grupo.FEC_MODIF = grupo.FechaModificacion;
                t_grupo.USR_MODIF = grupo.UsuarioModificacion;
                t_grupo.NRO_RESOLUCION = grupo.Nro_Resolucion;

                mDB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool EliminarGrupo(int id_grupo, string nro_resolucion)
        {
            try
            {
                IComunDatos comun = new ComunDatos();

                base.AgregarDatosEliminacion(comun);
                var t_grupo = mDB.T_GRUPOS.Where(c => c.ID_GRUPO == id_grupo).FirstOrDefault();

                t_grupo.ESTADO = comun.Estado;
                t_grupo.FEC_MODIF = comun.FechaModificacion;
                t_grupo.USR_MODIF = comun.UsuarioModificacion;
                t_grupo.NRO_RESOLUCION = nro_resolucion;

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
