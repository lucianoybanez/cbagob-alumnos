using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class DepartamentosServicios : IDepartamentosServicios
    {
        private IDepartamentosRepositorio mDepartamentosRepostorio; 

        public DepartamentosServicios()
        {
            mDepartamentosRepostorio = new DepartamentosRepositorio();
        }

        public IList<IDepartamentos> GetTodasbyProvincia(string IdProvincia)
        {
            try
            {
                return mDepartamentosRepostorio.GetTodasbyProvincia(IdProvincia);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
