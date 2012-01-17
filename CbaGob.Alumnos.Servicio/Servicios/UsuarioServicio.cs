using System;
using System.Collections.Generic;
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

        public UsuarioServicio(IUsuarioRepositorio _usuarioRepositorio)
        {
           
            UsuarioRepositorio = _usuarioRepositorio;
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }

        public UsuarioVista GetIndex()
        {
            UsuarioVista UsuarioVista = new UsuarioVista();
            UsuarioVista.SearchByDni = true;
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
    }
}