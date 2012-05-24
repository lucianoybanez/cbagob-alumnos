using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class PersonaJuridicaServicio : IPersonaJuridicaServicio
    {
        private IPersonaJuridicaRepositorio personajuridicarepositorio;


        public PersonaJuridicaServicio()
        {
            personajuridicarepositorio = new PersonaJuridicaRepositorio();
        }

        public IList<IPersonaJuridica> GetTodasByRazonSocial(string razonsocial)
        {
            try
            {
                return personajuridicarepositorio.GetTodasByRazonSocial(razonsocial);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IPersonaJuridica GetUno(int Id_PersonaJuridica)
        {
            try
            {
                return personajuridicarepositorio.GetUno(Id_PersonaJuridica);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Agregar()
        {
            try
            {
                return personajuridicarepositorio.Agregar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar()
        {
            try
            {
                return personajuridicarepositorio.Modificar();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
