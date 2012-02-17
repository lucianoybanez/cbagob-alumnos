using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.DB;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class PersonaRepositorio : BaseRepository,IPersonaRepositorio
    {

        public CursosDB mDb;


        public PersonaRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<IPersona> GetTodas()
        {
            try
            {
                var ListaPersona = (from c in mDb.T_PERSONAS
                                    select
                                        new Persona
                                            {
                                                Cuil = c.CUIL,
                                                Nov_Apellido = c.NOV_APELLIDO,
                                                Nro_Documento = c.NRO_DOCUMENTO,
                                                Nov_Nombre = c.NOV_NOMBRE,
                                                Id_Persona = c.ID_PERSONA
                                            }).ToList().Cast<IPersona>().ToList();

                return ListaPersona;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IList<IPersona> GetTodasByNombre(string nombre)
        {
            //return DatosMock.GetPersonas().Where(c => c.PersonaNombre == nombre).ToList();
            return null;
        }

        public IList<IPersona> GetPersonasDni(int dni)
        {
            //return DatosMock.GetPersonas().Where(c => c.PersonaDni == dni).ToList();

            
            return null;
        }
    }
}