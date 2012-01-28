using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class UsuarioServicio : BaseService, IUsuarioServicio
    {
        private IUsuarioRepositorio UsuarioRepositorio;

        private IAutenticacionServicio AutenticacionServicio;

        public UsuarioServicio(IUsuarioRepositorio _usuarioRepositorio, IAutenticacionServicio _autenticacionServicio)
        {
            UsuarioRepositorio = _usuarioRepositorio;
            AutenticacionServicio = _autenticacionServicio;
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }

        public UsuarioVista GetIndex()
        {
            UsuarioVista UsuarioVista = new UsuarioVista();
            UsuarioVista.SearchByDni = true;
            UsuarioVista.data = GetCookieData();
            return UsuarioVista;
        }

        public UsuarioVista BuscarUsuarioNombre(string nombre)
        {
            UsuarioVista UsuarioVista = new UsuarioVista
            {
                Nombre = nombre,
                Usuarios = UsuarioRepositorio.GetUsersByName(nombre),
            };
            return UsuarioVista;
        }

        public UsuarioVista BuscarUsuarioDni(int dni)
        {
            throw new NotImplementedException();
        }

        public UsuarioVista BuscarUsuario(UsuarioVista vista)
        {
            if (vista.SearchByDni)
            {
                vista.Usuarios = UsuarioRepositorio.GetUsersByDni(vista.Dni);
            }
            else
            {
                vista.Usuarios = UsuarioRepositorio.GetUsersByName(vista.Nombre);
            }
            return vista;
        }

        public void Login(string nombre)
        {
            var usuario = UsuarioRepositorio.GetUsersByName(nombre).FirstOrDefault();
            string dataCookie = usuario.Nombre + "|" + usuario.Roles.FirstOrDefault().Descrition;
            AutenticacionServicio.SignIn(nombre,dataCookie);
        }

        public ICookieData GetCookieData()
        {
            string userData = AutenticacionServicio.GetUserData();
            string[] pieces = userData.Split('|');
            ICookieData a = new CookieData()
                                {
                                    Usuario = pieces[0],
                                    Rol = pieces[1]
                                };
            return a;
        }

        public bool IsCuentaValida(string username, string password)
        {
            bool ret = false;
            var user = UsuarioRepositorio.GetUserByNamePassword(username, password);
            if (user == null)
            {
                AddError(TypeError.NotExist, "The User don't exist.");
            }
            else
            {
                ret = true;
            }
            return ret;
        }

    }
}