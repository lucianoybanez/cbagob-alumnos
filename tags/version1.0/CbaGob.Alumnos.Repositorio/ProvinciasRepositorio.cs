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
    public class ProvinciasRepositorio : IProvinciasRepositorio
    {
        public CursosDB mDb;

        public ProvinciasRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<IProvincias> GetTodas()
        {
            try
            {
                //var ListProvincias =
                //    (from r in mDb.V_PROVINCIAS
                //     select new Provincias {ID_PROVINCIA = r.ID_PROVINCIA, N_PROVINCIA = r.N_PROVINCIA}).ToList().Cast
                //        <IProvincias>().ToList();

                return null;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

       

        public IProvincias GetUno(string IdProvincia)
        {
            try
            {
                //var mProvincias = (from c in mDb.V_PROVINCIAS
                //                   where c.ID_PROVINCIA == IdProvincia
                //                   select new Provincias {ID_PROVINCIA = c.ID_PROVINCIA, N_PROVINCIA = c.N_PROVINCIA}).
                //    SingleOrDefault();

                return null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
