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
    public class AreaTipoCursoRepositorio : BaseRepositorio, IAreaTipoCursoRepositorio
    {
        private CursosDB mDB;

        public AreaTipoCursoRepositorio(ILoggedUserHelper helper)
            : base(helper)
        {
            mDB = new CursosDB();
            mDB.ContextOptions.LazyLoadingEnabled = false;
        }

        IQueryable<IAreaTipoCurso> QAreaTipoCurso()
        {
            var a = (from c in mDB.T_AREAS_TIPOS_CURSO
                     where c.ESTADO == "A"
                     select
                         new AreaTipoCurso
                             {
                                 Id_Area_Tipo_Curso = c.ID_AREA_TIPO_CURSO,
                                 Nombre_AreaTipoCurso = c.N_AREA_TIPO_CURSO,
                                 Nro_Resolucion = c.NRO_RESOLUCION
                             });

            return a;
        }

        public IList<IAreaTipoCurso> GetAreasTipoCurso()
        {
            try
            {
                return QAreaTipoCurso().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IAreaTipoCurso GetAreaTipoCargo(int id_area_tipo_curso)
        {
            try
            {
                return QAreaTipoCurso().Where(c => c.Id_Area_Tipo_Curso == id_area_tipo_curso).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCountAreasTipoCurso()
        {
            try
            {
                return QAreaTipoCurso().Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IAreaTipoCurso> GetAreasTipoCurso(int skip, int take)
        {
            try
            {
                return QAreaTipoCurso().OrderBy(c => c.Nombre_AreaTipoCurso).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarAreaTipoCargo(IAreaTipoCurso areatipocargo)
        {
            try
            {
                base.AgregarDatosAlta(areatipocargo);

                T_AREAS_TIPOS_CURSO t_area_tipo_cargo = new T_AREAS_TIPOS_CURSO
                                                            {
                                                                ESTADO = areatipocargo.Estado,
                                                                FEC_ALTA = areatipocargo.FechaAlta,
                                                                FEC_MODIF = areatipocargo.FechaModificacion,
                                                                USR_ALTA = areatipocargo.UsuarioAlta,
                                                                USR_MODIF = areatipocargo.UsuarioModificacion,
                                                                NRO_RESOLUCION = areatipocargo.Nro_Resolucion,
                                                                N_AREA_TIPO_CURSO = areatipocargo.Nombre_AreaTipoCurso
                                                            };


                mDB.AddToT_AREAS_TIPOS_CURSO(t_area_tipo_cargo);
                mDB.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarAreaTipoCargo(IAreaTipoCurso areatipocargo)
        {
            try
            {
                base.AgregarDatosModificacion(areatipocargo);

                var updateareatipocargo = mDB.T_AREAS_TIPOS_CURSO.FirstOrDefault(c => c.ID_AREA_TIPO_CURSO == areatipocargo.Id_Area_Tipo_Curso);

                updateareatipocargo.FEC_MODIF = areatipocargo.FechaModificacion;
                updateareatipocargo.USR_MODIF = areatipocargo.UsuarioModificacion;
                updateareatipocargo.N_AREA_TIPO_CURSO = areatipocargo.Nombre_AreaTipoCurso;

                mDB.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool EliminarAreaTipoCargo(int id_areatipocargo, string nro_resolucion)
        {
            try
            {
                IComunDatos areatipocargo = new ComunDatos();

                base.AgregarDatosEliminacion(areatipocargo);

                var updateareatipocargo = mDB.T_AREAS_TIPOS_CURSO.FirstOrDefault(c => c.ID_AREA_TIPO_CURSO == id_areatipocargo);

                updateareatipocargo.FEC_MODIF = areatipocargo.FechaModificacion;
                updateareatipocargo.USR_MODIF = areatipocargo.UsuarioModificacion;
                updateareatipocargo.NRO_RESOLUCION = nro_resolucion;
                updateareatipocargo.ESTADO = areatipocargo.Estado;

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
