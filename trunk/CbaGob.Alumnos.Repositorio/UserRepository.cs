using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.DB;

namespace CbaGob.Alumnos.Repositorio
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository()
            : base()
        {

        }

        public IUser GetUserById(int id)
        {
            return usersMock().Where(c => c.Id == id).SingleOrDefault();
        }

        public IUser GetUserByName(string name)
        {
            return usersMock().Where(c => c.Name == name).SingleOrDefault();
        }

        public IUser GetUserByNamePassword(string name, string password)
        {
            return usersMock().Where(c => c.Name == name && c.Password==password).SingleOrDefault();
        }


        private IList<IUser> usersMock()
        {
            IList<IUser> users = new List<IUser>();

            Rol adminrol = new Rol() {Id = 1,Descrition = "Administrador" };
            Rol Nivel2 = new Rol() {Id = 2,Descrition = "Nivel2" };
            Rol Nivel3 = new Rol() {Id = 3,Descrition = "Nivel1" };

            IList<Rol> listRol1 = new List<Rol>();
            listRol1.Add(adminrol);
            listRol1.Add(Nivel2);

            IList<Rol> listRol2 = new List<Rol>();
            listRol2.Add(adminrol);


            users.Add(new User() {Id = 1, Name = "admin", Password = "a123456", Rols = listRol1 });
            users.Add(new User() {Id = 2, Name = "Luciano", Password = "a123456", Rols = listRol2 });
            users.Add(new User() {Id = 3, Name = "Juan Jose", Password = "a123456" });
            users.Add(new User() {Id = 4, Name = "Chango", Password = "a123456" });
            return users;
        }
    }
}
