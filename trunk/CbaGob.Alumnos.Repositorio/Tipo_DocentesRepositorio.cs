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
    public class Tipo_DocentesRepositorio : ITipo_DocentesRepositorio
    {
        private CursosDB mDb;

        public Tipo_DocentesRepositorio()
        {
            mDb = new CursosDB();
        }

        
        IQueryable <ITipo_Docentes> QTiposDocentes()
        {
            var a = (from c in mDb.T_TIPOS_DOCENTE
                     where c.ESTADO == "A"
                     select
                         new Tipo_Docentes {Id_Tipo_Docente = c.ID_TIPO_DOCENTE, NombreTipoDocente = c.N_TIPO_DOCENTE});

            return a;
        }



        public IList<ITipo_Docentes> GetTiposDocentes()
        {
            try
            {

                return QTiposDocentes().ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
