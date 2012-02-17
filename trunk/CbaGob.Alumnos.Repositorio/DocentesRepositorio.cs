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
    public class DocentesRepositorio : IDocentesRepositorio
    {
        public CursosDB mDb;


        public DocentesRepositorio()
        {
            mDb = new CursosDB();
        }


        public IList<IDocentes> GetTodos()
        {
            try
            {
                
                var ListRetorno = (from e in mDb.T_DOCENTES
                                   join t in mDb.T_PERSONASJUR on e.ID_PERSONAJURIDICA equals t.ID_PERSONAJUR 
                                   where e.ESTADO == "A"
                                   select
                                       new Docentes
                                           {
                                               Id_PersonaJuridica = e.ID_PERSONAJURIDICA,
                                               Id_Cargo = e.ID_CARGO,
                                               Id_Domicilio = e.ID_DOMICILIO,
                                               N_Modalidad = e.N_MODALIDAD,
                                               Estado = e.ESTADO,
                                               FechaAlta = e.FEC_ALTA,
                                               FechaModificacion = e.FEC_MODIF,
                                               UsuarioAlta = e.USR_ALTA,
                                               UsuarioModificacion = e.USR_MODIF,
                                               Id_Docente = e.ID_DOCENTE,
                                               Razon_Social = t.RAZON_SOCIAL,
                                               Cuit = t.CUIT 
                                           }).ToList().Cast<IDocentes>().ToList();


                return ListRetorno;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IDocentes> GetTodosByRazonSocial(string razonsocial)
        {
            throw new NotImplementedException();
        }

        public IDocentes GetUno(int id_docente)
        {
            try
            {

                var Retorno = (from e in mDb.T_DOCENTES
                               join t in mDb.T_PERSONASJUR on e.ID_PERSONAJURIDICA equals t.ID_PERSONAJUR
                               where e.ESTADO == "A" && e.ID_DOCENTE == id_docente
                               select
                                   new Docentes
                                       {
                                           Id_PersonaJuridica = e.ID_PERSONAJURIDICA,
                                           Id_Cargo = e.ID_CARGO,
                                           Id_Domicilio = e.ID_DOMICILIO,
                                           N_Modalidad = e.N_MODALIDAD,
                                           Estado = e.ESTADO,
                                           FechaAlta = e.FEC_ALTA,
                                           FechaModificacion = e.FEC_MODIF,
                                           UsuarioAlta = e.USR_ALTA,
                                           UsuarioModificacion = e.USR_MODIF,
                                           Id_Docente = e.ID_DOCENTE,
                                           Razon_Social = t.RAZON_SOCIAL,
                                           Cuit = t.CUIT
                                       }).SingleOrDefault();


                return Retorno;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Agregar(IDocentes docente)
        {
            try
            {
                T_DOCENTES T_Docentes = new T_DOCENTES()
                                            {
                                                ESTADO = "A",
                                                FEC_ALTA = DateTime.Now,
                                                USR_ALTA = "Test",
                                                FEC_MODIF = DateTime.Now,
                                                USR_MODIF = "Test",
                                                ID_CARGO = docente.Id_Cargo,
                                                ID_DOMICILIO = docente.Id_Domicilio,
                                                ID_PERSONAJURIDICA = docente.Id_PersonaJuridica,
                                                N_MODALIDAD = docente.N_Modalidad
                                            };


                mDb.AddToT_DOCENTES(T_Docentes);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool Modificar(IDocentes docente)
        {
            try
            {
                var doc = mDb.T_DOCENTES.FirstOrDefault(c => c.ID_DOCENTE == docente.Id_Docente);
                doc.ID_CARGO = docente.Id_Cargo;
                doc.ID_DOMICILIO = docente.Id_Domicilio;
                doc.N_MODALIDAD = docente.N_Modalidad;
                doc.ID_PERSONAJURIDICA = docente.Id_PersonaJuridica;
                doc.FEC_MODIF = System.DateTime.Now;
                doc.USR_MODIF = "Test";
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool Eliminar(int id_docente)
        {
            try
            {
                var doc = mDb.T_DOCENTES.FirstOrDefault(c => c.ID_DOCENTE == id_docente);
                doc.ESTADO = "I";
                doc.FEC_MODIF = System.DateTime.Now;
                doc.USR_MODIF = "Test";
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
