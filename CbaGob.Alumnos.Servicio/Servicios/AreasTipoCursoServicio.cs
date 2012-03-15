using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class AreasTipoCursoServicio : BaseServicio, IAreasTipoCursoServicio
    {
        private IAreaTipoCursoRepositorio areatipocursorepositorio;

        private IAutenticacionServicio Aut;

        public AreasTipoCursoServicio(IAreaTipoCursoRepositorio Areatipocursorepositorio, IAutenticacionServicio aut)
        {
            areatipocursorepositorio = Areatipocursorepositorio;
            Aut = aut;
        }


        public IAreasTipoCursoVista GetAreasTipoCurso()
        {
            try
            {
                IAreasTipoCursoVista Vista = new AreasTipoCursoVista();

                var pager = new Pager(areatipocursorepositorio.GetCountAreasTipoCurso(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexAreaTipoCursos", Aut.GetUrl("IndexPager", "AreaTipoCurso"));

                Vista.Pager = pager;
                
                Vista.ListaAreaTipoCurso = areatipocursorepositorio.GetAreasTipoCurso(pager.Skip, pager.PageSize);

                return Vista;
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;

            }
        }

        public IAreasTipoCursoVista GetAreasTipoCurso(IPager pager)
        {
            try
            {
                IAreasTipoCursoVista Vista = new AreasTipoCursoVista();

                Vista.Pager = pager;

                Vista.ListaAreaTipoCurso = areatipocursorepositorio.GetAreasTipoCurso(pager.Skip, pager.PageSize);

                return Vista;
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;

            }
        }

        public IAreaTipoCursoVista GetAreaTipoCurso(int id_area_tipo_curso)
        {
            try
            {
                IAreaTipoCursoVista Vista = new AreaTipoCursoVista();

                IAreaTipoCurso areatipocurso = areatipocursorepositorio.GetAreaTipoCargo(id_area_tipo_curso);

                Vista.Id_Area_Tipo_Curso = areatipocurso.Id_Area_Tipo_Curso;
                Vista.Nombre_AreaTipoCurso = areatipocurso.Nombre_AreaTipoCurso;
                Vista.Nro_Resolucion = areatipocurso.Nro_Resolucion;

                return Vista;
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;

            }
        }

        public bool AgregarAreaTipoCargo(IAreaTipoCursoVista areatipocargo)
        {
            try
            {

                IAreaTipoCurso addareatipocurso = new AreaTipoCurso();

                addareatipocurso.Id_Area_Tipo_Curso = areatipocargo.Id_Area_Tipo_Curso;
                addareatipocurso.Nombre_AreaTipoCurso = areatipocargo.Nombre_AreaTipoCurso;
                addareatipocurso.Nro_Resolucion = areatipocargo.Nro_Resolucion;

                return areatipocursorepositorio.AgregarAreaTipoCargo(addareatipocurso);
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return false;

            }
        }

        public bool ModificarAreaTipoCargo(IAreaTipoCursoVista areatipocargo)
        {
            try
            {

                IAreaTipoCurso addareatipocurso = new AreaTipoCurso();

                addareatipocurso.Id_Area_Tipo_Curso = areatipocargo.Id_Area_Tipo_Curso;
                addareatipocurso.Nombre_AreaTipoCurso = areatipocargo.Nombre_AreaTipoCurso;
                addareatipocurso.Nro_Resolucion = areatipocargo.Nro_Resolucion;

                return areatipocursorepositorio.ModificarAreaTipoCargo(addareatipocurso);
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return false;

            }
        }

        public bool EliminarAreaTipoCargo(int id_areatipocargo, string nro_resolucion)
        {
            try
            {
                return areatipocursorepositorio.EliminarAreaTipoCargo(id_areatipocargo, nro_resolucion);
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return false;

            }
        }

        public IList<IErrores> GetErrors()
        {
            return Errors;
        }
    }
}
