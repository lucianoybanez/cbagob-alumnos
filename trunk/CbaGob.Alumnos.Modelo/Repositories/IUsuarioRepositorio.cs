using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IUsuarioRepositorio
    {
        IUsuario GetUserById(int id);
        IUsuario GetUserByNamePassword(string name, string password);
        IUsuario GetUsersByName(string nombre, bool activo);
        IList<IUsuario> GetAllUsuarios(int skip, int take);
        int GetAllUsuarios();
        bool AgregarUsuario(IUsuario usuario);
        bool ModificarUsuario(IUsuario usuario);
        bool EliminarUsuario(int usuario);
        IList<IRol> GetTodosRoles();
    }
}
