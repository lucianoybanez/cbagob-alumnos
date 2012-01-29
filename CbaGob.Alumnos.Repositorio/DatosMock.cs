using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Repositorio
{
    public static class DatosMock
    {
        public static IList<IUsuario> GetUsuarios()
        {
            IList<IUsuario> users = new List<IUsuario>();

            Rol adminrol = new Rol() { RolId = 1, RolTipo = "Administrador" };
            Rol Nivel2 = new Rol() { RolId = 2, RolTipo = "Nivel2" };

            users.Add(new Usuario() { PersonaID = 1, PersonaUsuario = "admin", PersonaPassword = "a123456", Rol = adminrol });
            users.Add(new Usuario() { PersonaID = 2, PersonaUsuario = "Luciano", PersonaPassword = "a123456", Rol = Nivel2 });
            users.Add(new Usuario() { PersonaID = 3, PersonaUsuario = "Juan Jose", PersonaPassword = "a123456" });
            users.Add(new Usuario() { PersonaID = 4, PersonaUsuario = "Chango", PersonaPassword = "a123456" });
            return users;
        }
    }
}
