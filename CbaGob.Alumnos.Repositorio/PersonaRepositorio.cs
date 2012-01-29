using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.DB;

namespace CbaGob.Alumnos.Repositorio
{
    public class PersonaRepositorio : BaseRepository,IPersonaRepositorio
    {
        public IList<IPersona> GetPersonasNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IList<IPersona> GetPersonasDni(string dni)
        {
            throw new NotImplementedException();
        }
    }
}