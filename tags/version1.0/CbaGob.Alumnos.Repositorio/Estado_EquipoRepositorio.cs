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
    public class Estado_EquipoRepositorio : IEstado_EquipoRepositorio
    {
        private CursosDB mDb;

        public Estado_EquipoRepositorio()
        {
            mDb = new CursosDB();
        }
        
        private IQueryable<IEstado_Equipo> QEstado_Equipo()
        {
            var a = (from c in mDb.T_ESTADOS_EQUIPO
                     where c.ESTADO == "A"
                     select
                         new Estado_Equipo
                             {Id_Estado_Equipo = c.ID_ESTADO_EQUIPO, Nombre_Estado_Equipo = c.N_ESTADO_EQUIPO});

            return a;
        }


        public IList<IEstado_Equipo> GetEstadosEquipo()
        {
            try
            {
                return QEstado_Equipo().ToList();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
