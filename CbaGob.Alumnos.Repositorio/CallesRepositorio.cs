using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class CallesRepositorio : ICallesRepositorio
    {
        private CursosDB mDb;
 
        public CallesRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<ICalles> GetTodasBYProDepLoca(string IdProvincia, int IdDepartamento, int IdLocalidad)
        {
            try
            {
                //var ListCalles = (from c in mDb.V_CALLES
                //                  where
                //                      c.ID_DEPARTAMENTO == IdDepartamento && c.ID_LOCALIDAD == IdLocalidad &&
                //                      c.ID_PROVINCIA == IdProvincia
                //                  select new Calles {ID_CALLE = c.ID_CALLE, N_CALLE = c.N_CALLE}).ToList().Cast<ICalles>
                //    ().ToList();
                return null;
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
                //var mCalles =
                //    (from c in mDb.V_CALLES
                //     where c.ID_CALLE == IdCalle
                //     select new Calles {ID_CALLE = c.ID_CALLE, N_CALLE = c.N_CALLE}).SingleOrDefault();
                return null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
