using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;


namespace CbaGob.Alumnos.Repositorio
{
    public class PersonaRepositorio : IPersonaRepositorio
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
                                                Id_Persona = c.ID_PERSONA,
                                                Id_Estado_Civil = c.ID_ESTADO_CIVIL,
                                                Id_Sexo = c.ID_SEXO,
                                                Id_Tipo_Documento = c.ID_TIPO_DOCUMENTO
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

        public IPersona GetUno(int id_persona)
        {
            try
            {
                var persona = (from c in mDb.T_PERSONAS
                                    where c.ID_PERSONA == id_persona
                                    select
                                        new Persona
                                            {
                                                Cuil = c.CUIL,
                                                Nov_Apellido = c.NOV_APELLIDO,
                                                Nro_Documento = c.NRO_DOCUMENTO,
                                                Nov_Nombre = c.NOV_NOMBRE,
                                                Id_Persona = c.ID_PERSONA,
                                                Id_Estado_Civil = c.ID_ESTADO_CIVIL,
                                                Id_Sexo = c.ID_SEXO,
                                                Id_Tipo_Documento = c.ID_TIPO_DOCUMENTO
                                            }).SingleOrDefault();

                return persona;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}