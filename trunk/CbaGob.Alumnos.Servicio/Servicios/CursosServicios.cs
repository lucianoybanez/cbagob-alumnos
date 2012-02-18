using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Repositorio.Models;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class CursosServicios : ICursosServicios
    {
        private ICursosRepositorio mCursosRepositorio;
        
        public CursosServicios()
        {
            mCursosRepositorio = new CursosRepositorio();
        }

        public IList<ICursos> GetTodosbyInstitucion(int IdInstitucion)
        {
            try
            {
                return mCursosRepositorio.GetTodosbyInstitucion(IdInstitucion);
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
                return mCursosRepositorio.GetTodos();
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
                return mCursosRepositorio.GetUno(IdCurso);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICursosVista GetUnaVista(int id)
        {
            try
            {
                ICursos mCursos;

                mCursos = mCursosRepositorio.GetUno(id);

                ICursosVista mCursosVista = new CursosVista();

                mCursosVista.ID_CURSO = mCursos.ID_CURSO;
                mCursosVista.N_CURSO = mCursos.N_CURSO;
                mCursosVista.NRORESOLUCION = mCursos.NRORESOLUCION;

                return mCursosVista;
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
                return mCursosRepositorio.Agregar(pCursos);
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
                return mCursosRepositorio.Modificar(pCursos);
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
                return mCursosRepositorio.Eliminar(IdCurso);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
