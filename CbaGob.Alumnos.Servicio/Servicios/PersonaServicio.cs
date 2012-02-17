using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class PersonaServicio : IPersonaServicio
    {
        private IPersonaRepositorio PersonaRepositorio;

        public PersonaServicio()
        {
            PersonaRepositorio = new PersonaRepositorio();
        }

        public UsuarioVista BuscarUsuario(UsuarioVista vista)
        {
            if (vista.SearchByDni)
            {
                vista.Usuarios = PersonaRepositorio.GetPersonasDni(vista.Dni);
            }
            else
            {
                vista.Usuarios = PersonaRepositorio.GetTodasByNombre(vista.Nombre);
            }
            return vista;
        }

        public UsuarioVista GetIndex()
        {
            UsuarioVista UsuarioVista = new UsuarioVista();
            UsuarioVista.SearchByDni = true;
            return UsuarioVista;
        }

        public IList<IPersona> GetTodas()
        {
            try
            {
                return PersonaRepositorio.GetTodas();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IList<IPersona> GetTodasByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IList<IPersona> GetPersonasDni(int dni)
        {
            throw new NotImplementedException();
        }

        public IPersona GetUno(int id_persona)
        {
            try
            {
                return PersonaRepositorio.GetUno(id_persona);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}