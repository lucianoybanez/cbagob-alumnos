using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class ProgramaRepositorio : IProgramaRepositorio
    {

        private CursosDB mDb;

        public ProgramaRepositorio()
        {
            mDb = new CursosDB();
        }


        public IList<IPrograma> GetProgramas()
        {
            var a = (from p in mDb.T_PROGRAMAS
                     select new Programa()
                                {
                                    IdPrograma = p.ID_PROGRAMA,
                                    Estado = p.ESTADO,
                                    FechaAlta = p.FEC_ALTA,
                                    FechaModificacion = p.FEC_MODIF,
                                    NombrePrograma = p.N_PROGRAMA,
                                    UsuarioAlta = p.USR_ALTA,
                                    UsuarioModificacion = p.USR_MODIF,
                                    Descripcion = p.DESCRIPCION
                                }).ToList().Cast<IPrograma>().ToList();
            return a;
        }

        public int AgregarPrograma(IPrograma programa)
        {
            throw new NotImplementedException();
        }

        public int ModificarPrograma(IPrograma programa)
        {
            throw new NotImplementedException();
        }

        public int EliminarPrograma(int idPrograma)
        {
            throw new NotImplementedException();
        }
    }
}