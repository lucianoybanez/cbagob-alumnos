using System;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class PersonaServicio : IPersonaServicio
    {
        private IPersonaRepositorio PersonaRepositorio;

        public PersonaServicio(IPersonaRepositorio personaRepositorio)
        {
            PersonaRepositorio = personaRepositorio;
        }

        public UsuarioVista BuscarUsuario(UsuarioVista vista)
        {
            if (vista.SearchByDni)
            {
                vista.Usuarios = PersonaRepositorio.GetPersonasDni(vista.Dni.ToString());
            }
            else
            {
                vista.Usuarios = PersonaRepositorio.GetPersonasNombre(vista.Nombre);
            }
            return vista;
        }

        public UsuarioVista GetIndex()
        {
            UsuarioVista UsuarioVista = new UsuarioVista();
            UsuarioVista.SearchByDni = true;
            return UsuarioVista;
        }
    }
}