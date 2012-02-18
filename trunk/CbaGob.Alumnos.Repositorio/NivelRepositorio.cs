using System;
using System.Linq;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class NivelRepositorio : INivelRepositorio
    {
        private CursosDB mDb;

        public NivelRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<INivel> GetNiveles()
        {
            var a = (from p in mDb.T_NIVELES
                     select new Nivel()
                     {
                         IdNivel = p.ID_NIVEL,
                         Estado = p.ESTADO,
                         FechaAlta = p.FEC_ALTA,
                         FechaModificacion = p.FEC_MODIF,
                         NombreNivel = p.N_NIVEL,
                         UsuarioAlta = p.USR_ALTA,
                         UsuarioModificacion = p.USR_MODIF
                     }).ToList().Cast<INivel>().ToList();
            return a;
        }

        public int AgregarNivel(INivel nivel)
        {
            throw new NotImplementedException();
        }

        public int ModificarNivel(INivel nivel)
        {
            throw new NotImplementedException();
        }

        public int EliminarNivel(int idNivel)
        {
            throw new NotImplementedException();
        }
    }
}