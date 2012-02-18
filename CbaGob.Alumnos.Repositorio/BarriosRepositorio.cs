using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class BarriosRepositorio : IBarriosRepositorio
    {
        private CursosDB mDB;

        public BarriosRepositorio()
        {
            mDB = new CursosDB();
        }

        public IList<IBarrios> GetTodasbyLocalidad(int IdLocalidad)
        {
            try
            {
                var ListBarrios = (from c in mDB.V_BARRIOS
                                   where c.ID_LOCALIDAD == IdLocalidad
                                   select new Barrios {ID_BARRIO = c.ID_BARRIO, N_BARRIO = c.N_BARRIO}).ToList().Cast
                    <IBarrios>().ToList();

                return ListBarrios;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public IBarrios GetUno(int IdBarrio)
        {
            try
            {
                var mBarrio = (from c in mDB.V_BARRIOS
                               where c.ID_BARRIO == IdBarrio
                               select new Barrios {ID_BARRIO = c.ID_BARRIO, N_BARRIO = c.N_BARRIO}).SingleOrDefault();

                return mBarrio;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
