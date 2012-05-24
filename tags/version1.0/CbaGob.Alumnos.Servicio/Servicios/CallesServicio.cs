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
    public class CallesServicio : ICallesServicio
    {
        private ICallesRepositorio mCallesRepositorio;

        public CallesServicio()
        {
            mCallesRepositorio = new CallesRepositorio();
        }

        public IList<ICalles> GetTodasBYProDepLoca(string IdProvincia, int IdDepartamento, int IdLocalidad)
        {
            try
            {
                return mCallesRepositorio.GetTodasBYProDepLoca(IdProvincia, IdDepartamento, IdLocalidad);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public ICalles GetUno(int IdCalle)
        {
            try
            {
                return mCallesRepositorio.GetUno(IdCalle);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
