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
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class InstitucionServicio : BaseServicio, IInstitucionServicio
    {
        private IInstitucionRepositorio mInstitucionRepositorio;


        public InstitucionServicio()
        {
            mInstitucionRepositorio = new InstitucionRepositorio();
        }

        public IList<IInstitucion> GetTodas()
        {
            return mInstitucionRepositorio.GetInstituciones();

        }

        public InstitucionVista GetIndex()
        {

            InstitucionVista mInstitucionVista = new InstitucionVista();

            mInstitucionVista.ListaInstituciones = mInstitucionRepositorio.GetInstituciones();

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

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}
