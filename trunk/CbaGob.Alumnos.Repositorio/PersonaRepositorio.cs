using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.DB;

namespace CbaGob.Alumnos.Repositorio
{
    public class PersonaRepositorio : BaseRepository,IPersonaRepositorio
    {
        public IList<IPersona> GetPersonasNombre(string nombre)
        {
            return DatosMock.GetPersonas().Where(c => c.PersonaNombre == nombre).ToList();
        }

        public IList<IPersona> GetPersonasDni(int dni)
        {
            return DatosMock.GetPersonas().Where(c => c.PersonaDni == dni).ToList();
        }
    }
}