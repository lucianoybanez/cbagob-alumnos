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
    public class AreaTipoCursoRepositorio : BaseRepositorio, IAreaTipoCursoRepositorio
    {
        private CursosDB mDB;

        public AreaTipoCursoRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDB = new CursosDB();
            mDB.ContextOptions.LazyLoadingEnabled = false;
        }

        IQueryable <IAreaTipoCurso> QAreaTipoCurso()
        {
            var a = (from c in mDB.T_AREAS_TIPOS_CURSO
                     where c.ESTADO == "A"
                     select
                         new AreaTipoCurso
                             {Id_Area_Tipo_Curso = c.ID_AREA_TIPO_CURSO, Nombre_AreaTipoCurso = c.N_AREA_TIPO_CURSO});

            return a;
        }



        public IList<IAreaTipoCurso> GetAreasTipoCurso()
        {
            try
            {
                return QAreaTipoCurso().ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
