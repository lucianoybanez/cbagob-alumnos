using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class CursosRepositorio : BaseRepositorio, ICursosRepositorio
    {
        private CursosDB mDb;

        public CursosRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDb = new CursosDB();
        }

        private IQueryable<ICursos> QCursos()
        {
            var a = (from c in mDb.T_CURSOS
                     where c.ESTADO == "A"
                     select
                         new Cursos
                             {
                                 ID_CURSO = c.ID_CURSO,
                                 N_CURSO = c.N_CURSO,
                                 ESTADO = c.ESTADO,
                                 NRORESOLUCION = c.NRO_RESOLUCION,
                                 Id_Area_Tipo_Curso = c.ID_AREA_TIPO_CURSO,
                                 NombreAreaTipoCurso = c.T_AREAS_TIPOS_CURSO.N_AREA_TIPO_CURSO
                             });
            return a;
        }

        public IList<ICursos> GetTodosbyInstitucion(int IdInstitucion)
        {
            try
            {
                var ListaCursos = (from c in mDb.T_CURSOS
                                   join cc in mDb.T_CONDICIONES_CURSO on c.ID_CURSO equals cc.ID_CURSO
                                   where cc.ID_INSTITUCION == IdInstitucion
                                   select
                                       new Cursos
                                           {
                                               ID_CURSO = c.ID_CURSO,
                                               N_CURSO = c.N_CURSO,
                                               ESTADO = c.ESTADO,
                                               NRORESOLUCION = c.NRO_RESOLUCION,
                                               Id_Area_Tipo_Curso = c.ID_AREA_TIPO_CURSO

                                           }).ToList().Cast<ICursos>().ToList();
                return ListaCursos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<ICursos> GetTodos()
        {
            try
            {
                return QCursos().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<ICursos> GetTodos(int skip, int take)
        {
            try
            {
                return QCursos().OrderBy(c => c.N_CURSO).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCountCursos()
        {
            try
            {
                return QCursos().Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICursos GetUno(int IdCurso)
        {
            try
            {
                return QCursos().Where(c => c.ID_CURSO == IdCurso).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Agregar(ICursos pCursos)
        {
            try
            {
                base.AgregarDatosAlta(pCursos);

                T_CURSOS mT_CURSOS = new T_CURSOS()
                                         {
                                             N_CURSO = pCursos.N_CURSO,
                                             ESTADO = pCursos.Estado,
                                             NRO_RESOLUCION = pCursos.NRORESOLUCION,
                                             FEC_ALTA = pCursos.FechaAlta,
                                             USR_ALTA = pCursos.UsuarioAlta,
                                             FEC_MODIF = pCursos.FechaModificacion,
                                             USR_MODIF = pCursos.UsuarioModificacion,
                                             ID_AREA_TIPO_CURSO = pCursos.Id_Area_Tipo_Curso
                                         };

                mDb.AddToT_CURSOS(mT_CURSOS);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(ICursos pCursos)
        {
            try
            {
                base.AgregarDatosModificacion(pCursos);

                var cur = mDb.T_CURSOS.FirstOrDefault(c => c.ID_CURSO == pCursos.ID_CURSO);
                cur.N_CURSO = pCursos.N_CURSO;
                cur.NRO_RESOLUCION = pCursos.NRORESOLUCION;
                cur.FEC_MODIF = pCursos.FechaModificacion;
                cur.USR_MODIF = pCursos.UsuarioModificacion;
                cur.ID_AREA_TIPO_CURSO = pCursos.Id_Area_Tipo_Curso;
                mDb.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(int IdCurso, string nroresolucion)
        {
            try
            {
                IComunDatos datos = new ComunDatos();
                base.AgregarDatosEliminacion(datos);

                var cur = mDb.T_CURSOS.FirstOrDefault(c => c.ID_CURSO == IdCurso);
                cur.ESTADO = datos.Estado;
                cur.NRO_RESOLUCION = nroresolucion;
                cur.FEC_MODIF = datos.FechaModificacion;
                cur.USR_MODIF = datos.UsuarioModificacion;
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
