using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;

namespace CbaGob.Alumnos.Repositorio.Models
{
    public class CursosRepositorio : ICursosRepositorio
    {
        private CursosDB mDb;

        public CursosRepositorio()
        {
            mDb = new CursosDB();
        }


        public IList<ICursos> GetTodosbyInstitucion(int IdInstitucion)
        {
            try
            {
                var ListaCursos = (from c in mDb.T_CURSO
                                   join cc in mDb.T_CONDICIONES_CURSO on c.ID_CURSO equals cc.ID_CURSO
                                   where cc.ID_INSTITUCION == IdInstitucion
                                   select
                                       new Cursos
                                           {
                                               ID_CURSO = c.ID_CURSO,
                                               N_CURSO = c.N_CURSO,
                                               ESTADO = c.ESTADO,

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
                var ListaCursos = (from c in mDb.T_CURSO
                                   where c.ESTADO == "A"
                                   select
                                       new Cursos
                                       {
                                           ID_CURSO = c.ID_CURSO,
                                           N_CURSO = c.N_CURSO,
                                           ESTADO = c.ESTADO,

                                       }).ToList().Cast<ICursos>().ToList();
                return ListaCursos;
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
                var mCursos = (from c in mDb.T_CURSO
                               where c.ID_CURSO == IdCurso
                               select
                                   new Cursos
                                   {
                                       ID_CURSO = c.ID_CURSO,
                                       N_CURSO = c.N_CURSO,
                                       ESTADO = c.ESTADO,

                                   }).SingleOrDefault();
                return mCursos;
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
                T_CURSO mT_CURSOS = new T_CURSO()
                                         {
                                             N_CURSO = pCursos.N_CURSO,
                                             ESTADO = "A"
                                         };

                mDb.AddToT_CURSO(mT_CURSOS);
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
                var cur = mDb.T_CURSO.FirstOrDefault(c => c.ID_CURSO == pCursos.ID_CURSO);
                cur.N_CURSO = pCursos.N_CURSO;
               

                mDb.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(int IdCurso)
        {
            try
            {
                var cur = mDb.T_CURSO.FirstOrDefault(c => c.ID_CURSO == IdCurso);

                cur.ESTADO = "I";

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
