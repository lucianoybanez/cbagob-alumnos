using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class PersonaJuridicaRepositorio : IPersonaJuridicaRepositorio
    {
        public CursosDB mDb;


        public PersonaJuridicaRepositorio()
        {
            mDb = new CursosDB();
        }


       

        public IList<IPersonaJuridica> GetTodasByRazonSocial(string razonsocial)
        {
            try
            {

                var ListaPersonasJur = (from t in mDb.T_PERSONASJUR
                                        where t.RAZON_SOCIAL.StartsWith(razonsocial)
                                        select
                                            new PersonaJuridica
                                            {
                                                Cuit = t.CUIT,
                                                Razon_Social = t.RAZON_SOCIAL,
                                                Id_PersonaJur = t.ID_PERSONAJUR
                                            }).ToList().Cast<IPersonaJuridica>().ToList();



                return ListaPersonasJur;
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

                var PersonasJur = (from t in mDb.T_PERSONASJUR
                                   where t.ID_PERSONAJUR == Id_PersonaJuridica
                                   select
                                       new PersonaJuridica
                                           {
                                               Cuit = t.CUIT,
                                               Razon_Social = t.RAZON_SOCIAL,
                                               Id_PersonaJur = t.ID_PERSONAJUR
                                           }).SingleOrDefault();



                return PersonasJur;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Agregar()
        {
            throw new NotImplementedException();
        }

        public bool Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
