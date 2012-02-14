using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class InstitucionRepositorio : IInstitucionRepositorio
    {
        public CursosDB mDb;


        public InstitucionRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<IInstitucion> GetTodas()
        {
            try
            {
                var ListRetorno = (from e in mDb.T_INSTITUCIONES
                                   where e.ESTADO == "A"
                                   select
                                       new Institucion
                                           {
                                               ID_INSTITUCION = e.ID_INSTITUCION,
                                               FechaAlta = e.FEC_ALTA,
                                               FechaModificacion = e.FEC_MODIF,
                                               ID_DOMICILIO = e.ID_DOMICILIO ?? 0,
                                               INS_PROPIA = (e.INS_PROPIA == "1" ? "SI" : "NO"),
                                               N_INSTITUCION = e.N_INSTITUCION,
                                               UsuarioAlta = e.USR_ALTA,
                                               UsuarioModificacion = e.USR_MODIF,
                                           }).ToList().Cast<IInstitucion>().ToList
                    ();

                return ListRetorno;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public IInstitucion GetUna(int INST_ID)
        {
            try
            {
                var mInstirucion = (from e in mDb.T_INSTITUCIONES
                                    where e.ID_INSTITUCION == INST_ID && e.ESTADO == "A"
                                    select new Institucion
                                               {
                                                   ID_INSTITUCION = e.ID_INSTITUCION,
                                                   FechaAlta = e.FEC_ALTA,
                                                   FechaModificacion = e.FEC_MODIF,
                                                   ID_DOMICILIO = e.ID_DOMICILIO ?? 0,
                                                   INS_PROPIA = (e.INS_PROPIA == "1" ? "SI" : "NO"),
                                                   N_INSTITUCION = e.N_INSTITUCION,
                                                   UsuarioAlta = e.USR_ALTA,
                                                   UsuarioModificacion = e.USR_MODIF,
                                               }).SingleOrDefault();

                return mInstirucion;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public bool AgregarInstitucion(IInstitucion pInstitucion)
        {
            try
            {
                T_INSTITUCIONES obj = new T_INSTITUCIONES()
                                          {
                                              ESTADO = "A",
                                              FEC_ALTA = DateTime.Now,
                                              N_INSTITUCION = pInstitucion.N_INSTITUCION,
                                              INS_PROPIA = pInstitucion.INS_PROPIA,
                                              USR_ALTA= "Test",
                                              USR_MODIF = "Test",
                                              FEC_MODIF = DateTime.Now
                                          };

                mDb.AddToT_INSTITUCIONES(obj);
                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public bool ModificarInstitucion(IInstitucion pInstitucion)
        {
            try
            {
                var IN = mDb.T_INSTITUCIONES.FirstOrDefault(c => c.ID_INSTITUCION == pInstitucion.ID_INSTITUCION);

                IN.N_INSTITUCION = pInstitucion.N_INSTITUCION;
                IN.FEC_MODIF = DateTime.Now;
                IN.ID_DOMICILIO = pInstitucion.ID_DOMICILIO;
                IN.USR_MODIF = "Test";
                mDb.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public bool EliminarInstitucion(int INST_ID)
        {
            try
            {
                var IN = mDb.T_INSTITUCIONES.FirstOrDefault(c => c.ID_INSTITUCION == INST_ID);

                IN.ESTADO = "I";

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
