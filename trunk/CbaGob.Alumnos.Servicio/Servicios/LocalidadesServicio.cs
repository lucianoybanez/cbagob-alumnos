using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class LocalidadesServicio : ILocalidadesServicio
    {
        private ILocalidadesRepositorio mLocalidadesRepositorio;


        public LocalidadesServicio()
        {
            mLocalidadesRepositorio = new LocalidadesRepositorio();
        }

        public IList<ILocalidades> getTodasByDepartamento(int Id_Departamento)
        {
            try
            {
                return mLocalidadesRepositorio.getTodasByDepartamento(Id_Departamento);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public ILocalidades GetUno(int IdLocalidad)
        {
            try
            {
                return mLocalidadesRepositorio.GetUno(IdLocalidad);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
