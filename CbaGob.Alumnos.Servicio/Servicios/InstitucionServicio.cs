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
                return mInstitucionRepositorio.GetTodas();
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

                mInstitucionVista.ListaInstituciones = mInstitucionRepositorio.GetTodas();

                return mInstitucionVista;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public IInstitucion GetUna(int INST_ID)
        {
            throw new NotImplementedException();
        }

        public IInstitucionVista GetUnaVista(int INST_ID)
        {
            try
            {
                IInstitucionVista model = new InstitucionVista();

                IInstitucion mInstitucion;

                mInstitucion = mInstitucionRepositorio.GetUna(INST_ID);

                model.ID_BARRIO = mInstitucion.ID_BARRIO;
                model.ID_CALLE = mInstitucion.ID_CALLE;
                model.ID_DEPARTAMENTO = mInstitucion.ID_DEPARTAMENTO;
                model.ID_LOCALIDAD = mInstitucion.ID_LOCALIDAD;
                model.INS_PROPIA = (mInstitucion.INS_PROPIA == "SI" ? true : false);
                model.INST_ID = mInstitucion.INST_ID;
                model.INST_NOMBRE = mInstitucion.INST_NOMBRE;
                model.INST_NRO = mInstitucion.INST_NRO;
                model.INST_TELEFONO = mInstitucion.INST_TELEFONO;
                model.ID_PROVINCIA = mInstitucion.ID_PROVINCIA;

                IProvinciasServicio mProvinciasServicio = new ProvinciasServicio();

                model.ListaProvincias = mProvinciasServicio.GetTodas();

                IDepartamentosServicios mDepartamentosServicios = new DepartamentosServicios();

                model.ListaDepartamento = mDepartamentosServicios.GetTodasbyProvincia(mInstitucion.ID_PROVINCIA);

                ILocalidadesServicio mLocalidadesServicio = new LocalidadesServicio();

                model.ListaLocalidades = mLocalidadesServicio.getTodasByDepartamento(mInstitucion.ID_DEPARTAMENTO);

                ICallesServicio mCallesServicio = new CallesServicio();

                model.ListaCalles = mCallesServicio.GetTodasBYProDepLoca(mInstitucion.ID_PROVINCIA,
                                                                         mInstitucion.ID_DEPARTAMENTO,
                                                                         mInstitucion.ID_LOCALIDAD);

                IBarriosServicio mBarriosServicio = new BarriosServicio();

                model.ListaBarrios = mBarriosServicio.GetTodasbyLocalidad(mInstitucion.ID_LOCALIDAD);

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

        public bool EliminarInstitucion(int INST_ID)
        {
            throw new NotImplementedException();
        }
    }
}
