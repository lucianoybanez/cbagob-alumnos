using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;


namespace CbaGob.Alumnos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        public IUsuario GetUserById(int id)
        {
            return DatosMock.GetUsuarios().Where(c => c.PersonaID == id).SingleOrDefault();
        }

        public IUsuario GetUserByNamePassword(string name, string password)
        {
            return DatosMock.GetUsuarios().Where(c => c.PersonaUsuario == name && c.PersonaPassword == password).SingleOrDefault();
        }

        public IUsuario GetUsersByName(string nombre)
        {
            return DatosMock.GetUsuarios().Where(c => c.PersonaUsuario == nombre).SingleOrDefault();
        }



    }
}
