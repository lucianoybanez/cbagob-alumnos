using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
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
                var ListaCursos = (from c in mDb.T_CURSOS
                                   join cc in mDb.T_CONDICIONES_CURSO on c.ID_CURSO equals cc.ID_CURSO
                                   where cc.ID_INSTITUCION == IdInstitucion
                                   select
                                       new Cursos
                                           {
                                               ID_CURSO = c.ID_CURSO,
                                               N_CURSO = c.N_CURSO,
                                               ESTADO = c.ESTADO,
                                               NRORESOLUCION = c.NRORESOLUCION ?? 0

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
                var ListaCursos = (from c in mDb.T_CURSOS
                                   where c.ESTADO == "A"
                                   select
                                       new Cursos
                                       {
                                           ID_CURSO = c.ID_CURSO,
                                           N_CURSO = c.N_CURSO,
                                           ESTADO = c.ESTADO,
                                           NRORESOLUCION = c.NRORESOLUCION ?? 0
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
                var mCursos = (from c in mDb.T_CURSOS
                               where c.ID_CURSO == IdCurso
                               select
                                   new Cursos
                                   {
                                       ID_CURSO = c.ID_CURSO,
                                       N_CURSO = c.N_CURSO,
                                       ESTADO = c.ESTADO,
                                       NRORESOLUCION = c.NRORESOLUCION ?? 0

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
                T_CURSOS mT_CURSOS = new T_CURSOS()
                                         {
                                             N_CURSO = pCursos.N_CURSO,
                                             ESTADO = "A",
                                             NRORESOLUCION = pCursos.NRORESOLUCION,
                                             FEC_ALTA = System.DateTime.Now,
                                             USR_ALTA = "Test",
                                             FEC_MODIF = System .DateTime.Now,
                                             USR_MODIF = "Test"
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
                var cur = mDb.T_CURSOS.FirstOrDefault(c => c.ID_CURSO == pCursos.ID_CURSO);
                cur.N_CURSO = pCursos.N_CURSO;
                cur.NRORESOLUCION = pCursos.NRORESOLUCION;
                cur.FEC_MODIF = System.DateTime.Now;
                cur.USR_MODIF = "Test";
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
                var cur = mDb.T_CURSOS.FirstOrDefault(c => c.ID_CURSO == IdCurso);
                cur.ESTADO = "I";
                cur.FEC_MODIF = System.DateTime.Now;
                cur.USR_MODIF = "Test";
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
