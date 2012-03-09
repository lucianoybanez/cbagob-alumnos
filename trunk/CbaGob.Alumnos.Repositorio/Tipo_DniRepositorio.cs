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
    public class Tipo_DniRepositorio : ITipo_DniRepositorio
    {

        private CursosDB mDB;

        public Tipo_DniRepositorio()
        {
            mDB = new CursosDB();
        }


        private IQueryable<ITipo_Dni> QTiposDni()
        {
            var a = (from c in mDB.T_TIPOS_DNI
                     where c.ESTADO == "A"
                     select new Tipo_Dni {Id_TipoDni = c.ID_TIPO_DNI, Nombre_TipoDni = c.N_TIPO_DNI});

            return a;
        }

        public IList<ITipo_Dni> GetTiposDni()
        {
            try
            {
                return QTiposDni().ToList();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
