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


        public static IList<IPersona> GetPersonas()
        {
            IList<IPersona> lista = new List<IPersona>();
            lista.Add(new Persona() { CargoTipo = 1, CodigoPais = "AR", IdSexo = "M", NroDocumento = "DNI", Numero = 5, PersonaApellido = "Aranda", PersonaDni = 33333333,PersonaNacimiento = DateTime.Today,PersonaNombre = "Carlos"});
            lista.Add(new Persona() { CargoTipo = 1, CodigoPais = "AR", IdSexo = "M", NroDocumento = "DNI", Numero = 5, PersonaApellido = "Juarez", PersonaDni = 11111111, PersonaNacimiento = DateTime.Today, PersonaNombre = "Carlos" });
            lista.Add(new Persona() { CargoTipo = 1, CodigoPais = "AR", IdSexo = "M", NroDocumento = "DNI", Numero = 5, PersonaApellido = "Chavez", PersonaDni = 44444444, PersonaNacimiento = DateTime.Today, PersonaNombre = "Marcelo" });
            lista.Add(new Persona() { CargoTipo = 1, CodigoPais = "AR", IdSexo = "M", NroDocumento = "DNI", Numero = 5, PersonaApellido = "Trujillo", PersonaDni = 55555555, PersonaNacimiento = DateTime.Today, PersonaNombre = "Agustin" });
            return lista;
        } 


    }
}
