using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;
using StructureMap;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class UsuarioServicio : BaseServicio, IUsuarioServicio
    {
        private IUsuarioRepositorio UsuarioRepositorio;
        private IAutenticacionServicio AutenticacionServicio;
        private string rol;
        private string nombreusuario;

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
            var usuario = UsuarioRepositorio.GetUsersByName(nombre, true);
            string dataCookie = usuario.NombreUsuario + "|" + usuario.Rol;
            AutenticacionServicio.SignIn(nombre, dataCookie);
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
            if (idusuario != 0)
            {
                var usuario = UsuarioRepositorio.GetUserById(idusuario);
                if (usuario != null)
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
            var roles = UsuarioRepositorio.GetTodosRoles();
            IComboBox combo = new ComboBox();
            var usuario = GetCookieData();
            rol = usuario.Rol;
            var lista = new List<IComboItem>();
            foreach (var role in roles)
            {
                lista.Add(new ComboItem()
                              {
                                  id = role.RolId,
                                  description = role.Descripcion
                              });
            }

            if (rol == "Supervisor")
            { combo.Combo = lista; }
            else
            {
                combo.Combo = lista.Where(c => c.description == "Capacitador").ToList();
            }

            return combo;
        }

        public IUsuarioVista GetRepresentante(string nombre)
        {
            IUsuarioVista vista = new UsuarioVista();
            if (nombre != "")
            {
                var usuario = UsuarioRepositorio.GetRepresentante(nombre);
                if (usuario != null)
                {
                    vista.Nombre = usuario.NombreUsuario;
                    vista.password = usuario.Password;
                    vista.idUsuario = usuario.IdUsuario;
                    vista.Roles.Selected = usuario.Rol;
                    vista.Representante = usuario.UsuarioResponsable;

                }
            }
            return vista;
        }

        public IUsuarioVista GetAllUsuarios(IPager pager)
        {
            IUsuarioVista vista = new UsuarioVista();

            var usuario = GetCookieData();
            rol = usuario.Rol;
            nombreusuario = usuario.Usuario;

            int cantidadpaginas = 0;

            if (rol == "Supervisor")
            {
                cantidadpaginas = UsuarioRepositorio.GetAllUsuarios();
            }
            else
            {
                cantidadpaginas =
                    UsuarioRepositorio.GetUsuarios().Where(c => c.UsuarioAlta == nombreusuario).Count();
            }



            if (pager == null)
            {
                var mpager = new Pager(cantidadpaginas, "FormIndexUsuario", AutenticacionServicio.GetUrl("IndexPager", "Usuario"));
                if (rol == "Supervisor")
                {
                    vista.Usuarios = UsuarioRepositorio.GetAllUsuarios(mpager.Skip, mpager.PageSize);
                }
                else
                {
                    vista.Usuarios =
                        UsuarioRepositorio.GetUsuarios().Where(c => c.UsuarioAlta == nombreusuario).OrderBy(
                            c => c.NombreUsuario).Skip(mpager.Skip).Take(mpager.PageSize).ToList();

                }
                vista.pager = mpager;
            }
            else
            {

                if (rol == "Supervisor")
                {
                    vista.Usuarios = UsuarioRepositorio.GetAllUsuarios(pager.Skip, pager.PageSize);
                }
                else
                {
                    vista.Usuarios =
                         UsuarioRepositorio.GetUsuarios().Where(c => c.UsuarioAlta == nombreusuario).OrderBy(
                             c => c.NombreUsuario).Skip(pager.Skip).Take(pager.PageSize).ToList();

                }
                vista.pager = pager;

            }

            return vista;
        }

        public bool GuardarUsuario(IUsuarioVista usuario)
        {
            IUsuario mUsuario = new Usuario();
            mUsuario.IdUsuario = usuario.idUsuario;
            mUsuario.NombreUsuario = usuario.Nombre;
            mUsuario.Password = usuario.password;
            mUsuario.IdRol = int.Parse(usuario.Roles.Selected);

            var usuarioget = GetCookieData();
            rol = usuarioget.Rol;
            nombreusuario = usuarioget.Usuario;

            int cantidadpaginas = 0;

            if (rol == "ResponsableIFP")
            {
                mUsuario.UsuarioResponsable = nombreusuario;
            }

            bool result = false;

            if (usuario.Accion == "Alta")
            {
                var getUsuario = UsuarioRepositorio.GetUsersByName(mUsuario.NombreUsuario, false);
                if (getUsuario != null)
                {
                    mUsuario.IdUsuario = getUsuario.IdUsuario;
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
            if (usuario != null)
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


    public class LoggedUserHelper : ILoggedUserHelper
    {

        private IAutenticacionServicio AutenticacionServicio;

        public LoggedUserHelper(IAutenticacionServicio autenticacionServicio)
        {
            AutenticacionServicio = autenticacionServicio;
        }

        public string GetLoggedUsuario()
        {
            try
            {
                string userData = AutenticacionServicio.GetUserData();
                string[] pieces = userData.Split('|');
                ICookieData a = new CookieData()
                {
                    Usuario = pieces[0],
                    Rol = pieces[1]
                };
                return a.Usuario;
            }
            catch (Exception)
            {

                return "Usuario no logueado";
            }
        }
    }

}