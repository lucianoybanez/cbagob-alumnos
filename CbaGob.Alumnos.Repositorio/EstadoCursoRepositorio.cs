using System;
using System.Linq;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public class EstadoCursoRepositorio : IEstadoCursoRepositorio
    {
        private CursosDB mDB;

        public EstadoCursoRepositorio()
        {
            mDB = new CursosDB();
        }

        public IList<IEstadoCurso> GetEstadosCursos()
        {
            var ret = (from p in mDB.T_ESTADOS_CURSO
                       select new EstadoCurso
                                  {
                                      Estado = p.ESTADO,
                                      FechaAlta = p.FEC_ALTA,
                                      FechaModificacion = p.FEC_MODIF,
                                      IdEstadoCurso = p.ID_ESTADO_CURSO,
                                      NombreEstadoCurso = p.N_ESTADO,
                                      UsuarioAlta = p.USR_ALTA,
                                      UsuarioModificacion = p.USR_MODIF
                                  }).ToList().Cast<IEstadoCurso>().ToList();
            return ret;
        }

        public bool AgregarEstadoCurso(IEstadoCurso estadoCurso)
        {
            throw new NotImplementedException();
        }

        public bool ModificarEstadoCurso(IEstadoCurso estadoCurso)
        {
            throw new NotImplementedException();
        }

        public bool ElimiarEstadoCurso(int idEstadoCurso)
        {
            throw new NotImplementedException();
        }
    }
}