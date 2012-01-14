using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IUsuarioRepositorio
    {
        IUsuario GetUserById(int id);
        IList<IUsuario> GetUserByName(string name);
        IUsuario GetUserByNamePassword(string name, string password);
    }
}
