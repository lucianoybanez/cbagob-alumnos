using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;

namespace CbaGob.Alumnos.Repositorio.Models
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
    }
}
