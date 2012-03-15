using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class ModalidadServicio : BaseServicio, IModalidadServicio
    {
        private IModalidadRepositorio modalidadrepositorio;

        private IAutenticacionServicio Aut;

        public ModalidadServicio(IModalidadRepositorio modalidadrepositorio, IAutenticacionServicio aut)
        {
            this.modalidadrepositorio = modalidadrepositorio;
            Aut = aut;
        }

        public IModalidadesVista GetModalidades()
        {
            try
            {
                IModalidadesVista vista = new ModalidadesVista();
                var pager = new Pager(modalidadrepositorio.GetCountModalidad(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexModalidades", Aut.GetUrl("IndexPager", "Modalidad"));

                vista.Pager = pager;

                vista.ListaModalidad = modalidadrepositorio.GetModalidades(pager.Skip, pager.PageSize);

                return vista;
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;
            }
        }

        public IModalidadesVista GetModalidades(IPager pager)
        {
            try
            {
                IModalidadesVista vista = new ModalidadesVista();

                vista.Pager = pager;

                vista.ListaModalidad = modalidadrepositorio.GetModalidades(pager.Skip, pager.PageSize);

                return vista;
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;
            }
        }

        public IModalidadVista GetModalidad(int id_modalidad)
        {
            try
            {
                IModalidadVista vista = new ModalidadVista();

                IModalidad modalidad = modalidadrepositorio.GetModalidad(id_modalidad);

                vista.IdModalidad = modalidad.IdModalidad;
                vista.NombreModalidad = modalidad.NombreModalidad;
                vista.Nro_Resolucion = modalidad.Nro_Resolucion;

                return vista;
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;
            }
        }

        public bool AgregarModalidad(IModalidadVista modalidad)
        {
            try
            {
                IModalidadVista vista = new ModalidadVista();

                IModalidad addmodalidad = new Modalidad();

                addmodalidad.IdModalidad = modalidad.IdModalidad;
                addmodalidad.NombreModalidad = modalidad.NombreModalidad;
                addmodalidad.Nro_Resolucion = modalidad.Nro_Resolucion;

                return modalidadrepositorio.AgregarModalidad(addmodalidad);
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return false;
            }
        }

        public bool ModificarModalidad(IModalidadVista modalidad)
        {
            try
            {
                IModalidadVista vista = new ModalidadVista();

                IModalidad addmodalidad = new Modalidad();

                addmodalidad.IdModalidad = modalidad.IdModalidad;
                addmodalidad.NombreModalidad = modalidad.NombreModalidad;
                addmodalidad.Nro_Resolucion = modalidad.Nro_Resolucion;

                return modalidadrepositorio.ModificarModalidad(addmodalidad);
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return false;
            }
        }

        public bool EliminarModalidad(int idModalidad, string nro_resolucion)
        {
            try
            {

                return modalidadrepositorio.EliminarModalidad(idModalidad, nro_resolucion);
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
