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
    public class CargosRepositorio : ICargosRepositorio
    {
        private CursosDB mDB;

        public CargosRepositorio()
        {
            mDB = new CursosDB();
        }

        public IList<ICargos> GetTodosCargos()
        {
            try
            {
                var ListaCargos =
                    (from a in mDB.T_CARGOS
                     where a.ESTADO == "A"
                     select new Cargos {Id_Cargo = a.ID_CARGO, N_Cargo = a.N_CARGO}).ToList().Cast<ICargos>().ToList();

                return ListaCargos;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
