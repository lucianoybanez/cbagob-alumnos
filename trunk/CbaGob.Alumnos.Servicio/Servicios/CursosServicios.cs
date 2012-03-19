using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Repositorio.Models;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class CursosServicios : BaseServicio, ICursosServicios
    {
        private ICursosRepositorio mCursosRepositorio;
        private IAreasTipoCursoServicio areacursoservicio;
        private IAutenticacionServicio Aut;


        public CursosServicios(ICursosRepositorio mCursosRepositorio, IAreasTipoCursoServicio areacursoservicio, IAutenticacionServicio aut)
        {
            this.mCursosRepositorio = mCursosRepositorio;
            this.areacursoservicio = areacursoservicio;
            Aut = aut;
        }

        public ICursosVista GetTodosbyInstitucion(int IdInstitucion)
        {
            try
            {
                ICursosVista vista = new CursosVista();
                
                vista.ListaCursos = mCursosRepositorio.GetTodosbyInstitucion(IdInstitucion);

                return vista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICursosVista GetTodos()
        {
            try
            {
                ICursosVista vista = new CursosVista();

                var pager = new Pager(mCursosRepositorio.GetCountCursos(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexCursos", Aut.GetUrl("IndexPager", "Cursos"));

                vista.ListaCursos = mCursosRepositorio.GetTodos(pager.Skip, pager.PageSize);

                vista.Pager = pager;

                return vista;
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

                CargarAreas(mCursosVista, areacursoservicio.GetAreasTipoCurso().ListaAreaTipoCurso);

                mCursosVista.AreasTipoCursos.Selected = mCursos.Id_Area_Tipo_Curso.ToString();

                return mCursosVista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICursosVista GetTodos(IPager Pager)
        {
            try
            {
                ICursosVista vista = new CursosVista();

                vista.ListaCursos = mCursosRepositorio.GetTodos(Pager.Skip, Pager.PageSize);

                vista.Pager = Pager;

                return vista;
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
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool Modificar(ICursos pCursos)
        {
            try
            {
                return mCursosRepositorio.Modificar(pCursos);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool Eliminar(int IdCurso, string nroresolucion)
        {
            try
            {
                return mCursosRepositorio.Eliminar(IdCurso, nroresolucion);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }

        private static void CargarAreas(ICursosVista vista, IList<IAreaTipoCurso> areastipo)
        {
            foreach (var est in areastipo)
            {
                vista.AreasTipoCursos.Combo.Add(new ComboItem()
                {
                    id = est.Id_Area_Tipo_Curso,
                    description = est.Nombre_AreaTipoCurso
                });
            }
        }

        public ICursosVista GetVistaIndex()
        {
            try
            {

                ICursosVista mCursosVista = new CursosVista();

                CargarAreas(mCursosVista, areacursoservicio.GetAreasTipoCurso().ListaAreaTipoCurso);


                return mCursosVista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
