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
    public class ProvinciasServicio : IProvinciasServicio
    {
        private IProvinciasRepositorio mProvinciasRepositorio;


        public ProvinciasServicio()
        {
            mProvinciasRepositorio = new ProvinciasRepositorio();
        }

        public IList<IProvincias> GetTodas()
        {
            try
            {
                return mProvinciasRepositorio.GetTodas();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
