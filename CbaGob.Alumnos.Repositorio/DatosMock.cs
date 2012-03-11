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

            users.Add(new Usuario() { IdUsuario = 1, NombreUsuario = "administrador", Password = "a123456", Rol = RolTipo.Administrador.ToString() });
            users.Add(new Usuario() { IdUsuario = 2, NombreUsuario = "luciano", Password = "a123456", Rol = RolTipo.Administrador.ToString() });
            users.Add(new Usuario() { IdUsuario = 3, NombreUsuario = "dario", Password = "a123456", Rol = RolTipo.Administrador.ToString() });
            users.Add(new Usuario() { IdUsuario = 4, NombreUsuario = "victor", Password = "a123456", Rol = RolTipo.Administrador.ToString() });
            users.Add(new Usuario() { IdUsuario = 4, NombreUsuario = "a", Password = "a", Rol = RolTipo.Nivel2.ToString() });
            return users;
        }


        public static IList<IPersona> GetPersonas()
        {
            IList<IPersona> lista = new List<IPersona>();
            return lista;
        } 


    }
}
