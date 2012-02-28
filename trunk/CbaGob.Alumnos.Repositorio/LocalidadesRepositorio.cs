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
    public class LocalidadesRepositorio : ILocalidadesRepositorio
    {
        public CursosDB mDb;

        public LocalidadesRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<ILocalidades> getTodasByDepartamento(int IdDepartamento)
        {
            try
            {
                //var ListLocalidades = (from c in mDb.V_LOCALIDAES
                //                       where c.ID_DEPARTAMENTO == IdDepartamento
                //                       select
                //                           new Localidades {ID_LOCALIDAD = c.ID_LOCALIDAD, N_LOCALIDAD = c.N_LOCALIDAD})
                //    .ToList().Cast<ILocalidades>().ToList();

                return null;
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
                //var mLocalidades = (from c in mDb.V_LOCALIDAES
                //                    where c.ID_LOCALIDAD == IdLocalidad
                //                    select new Localidades {ID_LOCALIDAD = c.ID_LOCALIDAD, N_LOCALIDAD = c.N_LOCALIDAD})
                //    .SingleOrDefault();

                return null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
