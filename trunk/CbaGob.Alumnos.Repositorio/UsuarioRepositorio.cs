using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.DB;

namespace CbaGob.Alumnos.Repositorio
{
    public class UsuarioRepositorio : BaseRepository, IUsuarioRepositorio
    {

        public UsuarioRepositorio()
            : base()
        {

        }

        public IUsuario GetUserById(int id)
        {
            return usersMock().Where(c => c.Id == id).SingleOrDefault();
        }

        public IList<IUsuario> GetUserByName(string name)
        {
            return usersMock().Where(c => c.Nombre == name).ToList();
        }

        public IUsuario GetUserByNamePassword(string name, string password)
        {
            return usersMock().Where(c => c.Nombre == name && c.Password==password).SingleOrDefault();
        }


        private IList<IUsuario> usersMock()
        {
            IList<IUsuario> users = new List<IUsuario>();

            Rol adminrol = new Rol() {Id = 1,Descrition = "Administrador" };
            Rol Nivel2 = new Rol() {Id = 2,Descrition = "Nivel2" };
            Rol Nivel3 = new Rol() {Id = 3,Descrition = "Nivel1" };

            IList<Rol> listRol1 = new List<Rol>();
            listRol1.Add(adminrol);
            listRol1.Add(Nivel2);

            IList<Rol> listRol2 = new List<Rol>();
            listRol2.Add(adminrol);


            users.Add(new Usuario() {Id = 1, Nombre = "admin", Password = "a123456", Roles = listRol1 });
            users.Add(new Usuario() {Id = 2, Nombre = "Luciano", Password = "a123456", Roles = listRol2 });
            users.Add(new Usuario() {Id = 3, Nombre = "Juan Jose", Password = "a123456" });
            users.Add(new Usuario() {Id = 4, Nombre = "Chango", Password = "a123456" });
            users.Add(new Usuario() { Id = 5, Nombre = "Chango", Password = "chango 2" });
            users.Add(new Usuario() { Id = 6, Nombre = "Chango", Password = "cahngo 3" });
            return users;
        }
    }
}
