using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class UsuarioServicio : BaseServicio, IUsuarioServicio
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
       

        public void Login(string nombre)
        {
            var usuario = UsuarioRepositorio.GetUsersByName(nombre,true);
            string dataCookie = usuario.NombreUsuario + "|" + usuario.Rol;
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

        public IUsuarioVista GetUsuario(int idusuario)
        {
            IUsuarioVista vista = new UsuarioVista();
            vista.Roles = GetRoles();
            if (idusuario!=0)
            {
                var usuario = UsuarioRepositorio.GetUserById(idusuario);
                if (usuario!=null)
                {
                    vista.Nombre = usuario.NombreUsuario;
                    vista.password = usuario.Password;
                    vista.idUsuario = usuario.IdUsuario;
                    vista.Roles.Selected = usuario.Rol;
                }
            }
            return vista;
        }


        public IComboBox GetRoles()
        {
            IComboBox combo = new ComboBox();
            var lista = new List<IComboItem>();
            lista.Add(new ComboItem() { description = RolTipo.Administrador.ToString(), id = (int)RolTipo.Administrador });
            lista.Add(new ComboItem() { description = RolTipo.Nivel2.ToString(), id = (int)RolTipo.Nivel2 });
            lista.Add(new ComboItem() { description = RolTipo.Nivel3.ToString(), id = (int)RolTipo.Nivel3 });
            lista.Add(new ComboItem() { description = RolTipo.Nivel4.ToString(), id = (int)RolTipo.Nivel4 });
            combo.Combo = lista;
            return combo;
        }


        public IUsuarioVista GetAllUsuarios(IPager pager)
        {
            IUsuarioVista vista = new UsuarioVista();
            if (pager== null)
            {
                var mpager = new Pager(UsuarioRepositorio.GetAllUsuarios(), "FormIndexUsuario", AutenticacionServicio.GetUrl("IndexPager", "Usuario"));
                vista.Usuarios = UsuarioRepositorio.GetAllUsuarios(mpager.Skip, mpager.PageSize);
                vista.pager = mpager;
            }
            else
            {
                vista.Usuarios = UsuarioRepositorio.GetAllUsuarios(pager.Skip, pager.PageSize);
                vista.pager = pager;

            }
            foreach (var usuario in vista.Usuarios)
            {
                usuario.Rol = ((RolTipo) (int.Parse(usuario.Rol))).ToString();
            }

  

            return vista;
        }

        public bool GuardarUsuario(IUsuarioVista usuario)
        {
            IUsuario mUsuario = new Usuario();
            mUsuario.IdUsuario = usuario.idUsuario;
            mUsuario.NombreUsuario = usuario.Nombre;
            mUsuario.Password = usuario.password;
            mUsuario.Rol = usuario.Roles.Selected;

            bool result = false;

            if (usuario.Accion == "Alta")
            {
                var getUsuario = UsuarioRepositorio.GetUsersByName(mUsuario.NombreUsuario,false);
                if (getUsuario!=null)
                {
                    usuario.Accion = "Modificar";
                }
                else
                {
                    result = UsuarioRepositorio.AgregarUsuario(mUsuario);
                }
            }
            if (usuario.Accion == "Modificar")
            {
                result = UsuarioRepositorio.ModificarUsuario(mUsuario);
            }
            if (!result)
            {
                base.AddError("Ocurrio un error al grabar el usuario");
            }
            return result;
        }

        public bool EliminarUsuario(int usuario)
        {
            bool result = UsuarioRepositorio.EliminarUsuario(usuario);
            if (!result)
            {
                base.AddError("Ocurrio un error al eliminar el usuario");
            }
            return result;
        }

        public IUsuarioVista GetUsuario(string nombre)
        {
            IUsuarioVista vista = new UsuarioVista();
            var usuario = UsuarioRepositorio.GetUsersByName(nombre, true);
            if (usuario!=null)
            {
                vista.Usuarios.Add(usuario);
            }
            return vista;
        }

        public bool IsCuentaValida(string username, string password)
        {
            bool ret = false;
            var user = UsuarioRepositorio.GetUserByNamePassword(username, password);
            if (user == null)
            {
                AddError(TypeError.NotExist, "El usuario no existe.");
            }
            else
            {
                ret = true;
            }
            return ret;
        }

    }
}