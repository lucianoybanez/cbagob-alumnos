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
    public class Tipo_EstadoCivilRepositorio : ITipo_EstadoCivilRepositorio
    {
        private CursosDB mDB;

        public Tipo_EstadoCivilRepositorio()
        {
            mDB = new CursosDB();
        }


        private IQueryable<ITipo_EstadoCivil> QTiposEstadoCivil()
        {
            var a = (from c in mDB.T_TIPOS_ESTADO_CIVIL
                     where c.ESTADO == "A"
                     select new Tipo_EstadoCivil { Id_TipoEstadoCivil = c.ID_TIPO_ESTADO_CIVIL, Nombre_TipoEstadoCivil = c.N_TIPO_ESTADO_CIVIL });

            return a;
        }

        public IList<ITipo_EstadoCivil> GetEstadosCivil()
        {
            try
            {
                return QTiposEstadoCivil().ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
