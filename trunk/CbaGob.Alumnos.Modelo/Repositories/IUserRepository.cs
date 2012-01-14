using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IUserRepository
    {
        IUser GetUserById(int id);
        IUser GetUserByName(string name);
        IUser GetUserByNamePassword(string name, string password);
    }
}
