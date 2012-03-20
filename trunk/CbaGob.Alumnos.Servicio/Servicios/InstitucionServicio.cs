using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
    public class InstitucionServicio : BaseServicio, IInstitucionServicio
    {
        private IInstitucionRepositorio mInstitucionRepositorio;

        private IAutenticacionServicio Aut;

        private IUsuarioServicio usuarioservice;

        public InstitucionServicio(IInstitucionRepositorio mInstitucionRepositorio, IAutenticacionServicio aut, IUsuarioServicio pusuarioservice)
        {
            this.mInstitucionRepositorio = mInstitucionRepositorio;
            Aut = aut;
            usuarioservice = pusuarioservice;
        }

        public IList<IInstitucion> GetTodas()
        {
            return mInstitucionRepositorio.GetInstituciones();

        }

        public InstitucionVista GetInstituciones()
        {
            InstitucionVista mInstitucionVista = new InstitucionVista();

            mInstitucionVista.ListaInstituciones = mInstitucionRepositorio.GetInstituciones();

            return mInstitucionVista;
        }

        public InstitucionVista GetIndex()
        {

            InstitucionVista mInstitucionVista = new InstitucionVista();

            var pager = new Pager(mInstitucionRepositorio.GetCountInstituciones(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexInstituciones", Aut.GetUrl("IndexPager", "Instituciones"));

            mInstitucionVista.pager = pager;

            mInstitucionVista.ListaInstituciones = mInstitucionRepositorio.GetInstituciones(pager.Skip, pager.PageSize);

            return mInstitucionVista;

        }

        public InstitucionVista GetIndex(IPager page)
        {
            InstitucionVista mInstitucionVista = new InstitucionVista();

            mInstitucionVista.pager = page;

            mInstitucionVista.ListaInstituciones = mInstitucionRepositorio.GetInstituciones(page.Skip, page.PageSize);

            return mInstitucionVista;
        }

        public IInstitucion GetUna(int IdInstitucion)
        {
            throw new NotImplementedException();
        }

        public IInstitucionVista GetUnaVista(int IdInstitucion)
        {

            IInstitucionVista model = new InstitucionVista();

            IInstitucion mInstitucion;

            mInstitucion = mInstitucionRepositorio.GetInstitucion(IdInstitucion);

            model.espropia = (mInstitucion.espropia == "SI" ? true : false);
            model.Id_Institucion = mInstitucion.Id_Institucion;
            model.Nombre_Institucion = mInstitucion.Nombre_Institucion;
            model.Provincia = mInstitucion.Provincia;
            model.Localidad = mInstitucion.Localidad;
            model.Calle = mInstitucion.Calle;
            model.Barrio = mInstitucion.Barrio;
            model.Nro = mInstitucion.Nro;
            model.Nro_Expediente = mInstitucion.Nro_Expediente;
            model.Nro_Resolucion = mInstitucion.Nro_Resolucion;
            model.Depto = mInstitucion.Depto;
            model.Telefono = mInstitucion.Telefono;

            return model;


        }

        public bool AgregarInstitucion(IInstitucion pInstitucion)
        {
            bool result = mInstitucionRepositorio.AgregarInstitucion(pInstitucion);
            if (!result)
            {
                base.AddError("Error: No pueden existir dos Instituciones Iguales.");
                base.AddError("Error: Dos Instituciones no pueden tener el mismo domicilio.");
            }
            return result;
        }

        public bool ModificarInstitucion(IInstitucion pInstitucion)
        {
            bool result = mInstitucionRepositorio.ModificarInstitucion(pInstitucion);
            if (!result)
            {
                base.AddError("Error: No pueden existir dos Instituciones Iguales.");
                base.AddError("Error: Dos Instituciones no pueden tener el mismo domicilio.");
            }
            return result;

        }

        public bool EliminarInstitucion(int IdInstitucion, string nro_resolucion)
        {
            bool result = mInstitucionRepositorio.EliminarInstitucion(IdInstitucion, nro_resolucion);
            if (!result)
            {
                base.AddError("Error: No se pudo eliminar la Institucion.");
            }
            return result;
        }

        public InstitucionVista BuscarInstitucion(string nombreinstitucion)
        {
            try
            {
                InstitucionVista mInstitucionVista = new InstitucionVista();
                

                if (nombreinstitucion != null)
                {
                    
                    //mInstitucionVista.ListaInstituciones = mInstitucionRepositorio.BuscarInstitucion(nombreinstitucion);

                    var pager = new Pager(mInstitucionRepositorio.BuscarInstitucion(nombreinstitucion).Count(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexInstituciones", Aut.GetUrl("IndexPager", "Instituciones"));

                    mInstitucionVista.ListaInstituciones = mInstitucionRepositorio.BuscarInstitucion(nombreinstitucion,
                                                                                                     pager.Skip,
                                                                                                     pager.PageSize);

                    mInstitucionVista.pager = pager;
                }
                else
                {
                   
                    var pager = new Pager(mInstitucionRepositorio.GetInstituciones().Count(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexInstituciones", Aut.GetUrl("IndexPager", "Instituciones"));

                    mInstitucionVista.ListaInstituciones = mInstitucionRepositorio.GetInstituciones(pager.Skip, pager.PageSize);

                    mInstitucionVista.pager = pager;
                }

                
                //var pager = new Pager(mInstitucionRepositorio.GetCountInstituciones(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexInstituciones", Aut.GetUrl("IndexPager", "Instituciones"));
                

                return mInstitucionVista;
            }
            catch (Exception ex)
            {
                base.AddError("Error: No se pudo eliminar la Institucion.");
                return null;
            }
        }

        public InstitucionVista BuscarInstitucion(IPager page, string nombreinstitucion)
        {
            try
            {
                InstitucionVista mInstitucionVista = new InstitucionVista();

                mInstitucionVista.ListaInstituciones = mInstitucionRepositorio.BuscarInstitucion(nombreinstitucion,
                                                                                                    page.Skip,
                                                                                                    page.PageSize);

                mInstitucionVista.pager = page;

                return mInstitucionVista;
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}
