using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class BarriosServicio : IBarriosServicio
    {
        private IBarriosRepositorio mBarriosRepositorio;
 
        public BarriosServicio()
        {
            mBarriosRepositorio = new BarriosRepositorio();
        }

        public IList<IBarrios> GetTodasbyLocalidad(int IdLocalidad)
        {
            try
            {
                return mBarriosRepositorio.GetTodasbyLocalidad(IdLocalidad);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IBarrios GetUno(int IdBarrio)
        {
            try
            {
                return mBarriosRepositorio.GetUno(IdBarrio);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
