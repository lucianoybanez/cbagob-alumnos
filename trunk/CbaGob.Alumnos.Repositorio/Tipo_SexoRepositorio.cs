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
    public class Tipo_SexoRepositorio : ITipo_SexoRepositorio
    {
         private CursosDB mDB;

         public Tipo_SexoRepositorio()
        {
            mDB = new CursosDB();
        }


        private IQueryable<ITipo_Sexo> QTiposSexo()
        {
            var a = (from c in mDB.T_TIPOS_SEXO
                     where c.ESTADO == "A"
                     select new Tipo_Sexo { Id_TipoSexo = c.ID_TIPO_SEXO, Nombre_TipoSexo = c.N_TIPO_SEXO });

            return a;
        }

        public IList<ITipo_Sexo> GetTiposSexo()
        {
            try
            {
                return QTiposSexo().ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        
    }
}
