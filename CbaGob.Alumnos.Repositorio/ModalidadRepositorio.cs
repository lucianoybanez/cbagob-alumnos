using System;
using System.Linq;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class ModalidadRepositorio : IModalidadRepositorio
    {
        private CursosDB mDb;

        public ModalidadRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<IModalidad> GetModalidades()
        {
            var a = (from p in mDb.T_MODALIDADES
                     select new Modalidad()
                     {
                         IdModalidad = p.ID_MODALIDAD,
                         Estado = p.ESTADO,
                         FechaAlta = p.FEC_ALTA,
                         FechaModificacion = p.FEC_MODIF,
                         NombreModalidad = p.N_MODALIDAD,
                         UsuarioAlta = p.USR_ALTA,
                         UsuarioModificacion = p.USR_MODIF
                     }).ToList().Cast<IModalidad>().ToList();
            return a;
        }

        public int AgregarModalidad(IModalidad modalidad)
        {
            throw new NotImplementedException();
        }

        public int ModificarModalidad(IModalidad modalidad)
        {
            throw new NotImplementedException();
        }

        public int EliminarModalidad(int idModalidad)
        {
            throw new NotImplementedException();
        }
    }
}