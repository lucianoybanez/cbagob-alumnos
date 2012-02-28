using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class InstitucionServicio : IInstitucionServicio
    {
        private IInstitucionRepositorio mInstitucionRepositorio;


        public InstitucionServicio()
        {
            mInstitucionRepositorio = new InstitucionRepositorio();
        }

        public IList<IInstitucion> GetTodas()
        {
            try
            {
                return mInstitucionRepositorio.GetInstituciones();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public InstitucionVista GetIndex()
        {
            try
            {

                InstitucionVista mInstitucionVista = new InstitucionVista();

                mInstitucionVista.ListaInstituciones = mInstitucionRepositorio.GetInstituciones();

                return mInstitucionVista;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public IInstitucion GetUna(int IdInstitucion)
        {
            throw new NotImplementedException();
        }

        public IInstitucionVista GetUnaVista(int IdInstitucion)
        {
            try
            {
                IInstitucionVista model = new InstitucionVista();

                IInstitucion mInstitucion;

                mInstitucion = mInstitucionRepositorio.GetInstitucion(IdInstitucion);

                model.espropia = (mInstitucion.espropia == "SI" ? true : false);
                model.Id_Institucion = mInstitucion.Id_Institucion;
                model.Nombre_Institucion = mInstitucion.Nombre_Institucion;
                model.Id_Domicilio = mInstitucion.Id_Domicilio;
                model.DireccionCompleta = mInstitucion.DireccionCompleta;
               
                return model;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarInstitucion(IInstitucion pInstitucion)
        {
            try
            {
                return mInstitucionRepositorio.AgregarInstitucion(pInstitucion);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool ModificarInstitucion(IInstitucion pInstitucion)
        {
            try
            {
                return mInstitucionRepositorio.ModificarInstitucion(pInstitucion);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public bool EliminarInstitucion(int IdInstitucion)
        {
            return mInstitucionRepositorio.EliminarInstitucion(IdInstitucion);
        }
    }
}
