using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class DepartamentosRepositorio : IDepartamentosRepositorio
    {
        public CursosDB mDb;
        
        public DepartamentosRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<IDepartamentos> GetTodasbyProvincia(string IdProvincia)
        {
            try
            {
                var ListDepartamento = (from c in mDb.V_DEPARTAMENTOS
                                        where c.ID_PROVINCIA == IdProvincia
                                        select
                                            new Departamentos
                                                {ID_DEPARTAMENTO = c.ID_DEPARTAMENTO, N_DEPARTAMENTO = c.N_DEPARTAMENTO})
                    .ToList().Cast<IDepartamentos>().ToList();


                return ListDepartamento;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public IDepartamentos GetUno(int IdDepartamento)
        {
            try
            {
                var mDepartamentos =
                    (from c in mDb.V_DEPARTAMENTOS
                     where c.ID_DEPARTAMENTO == IdDepartamento
                     select new Departamentos {ID_DEPARTAMENTO = c.ID_DEPARTAMENTO, N_DEPARTAMENTO = c.N_DEPARTAMENTO}).
                        SingleOrDefault();

                return mDepartamentos;

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
