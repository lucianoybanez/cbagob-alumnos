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
                                               INST_ID = e.INST_ID,
                                               FechaAlta = e.FEC_ALTA,
                                               FechaModificacion = e.FEC_MODIF,
                                               ID_CALLE = e.ID_CALLE,
                                               ID_LOCALIDAD = e.ID_LOCALIDAD,
                                               ID_PROVINCIA = e.ID_PROVINCIA,
                                               INS_PROPIA = (e.INS_PROPIA == "1" ? "SI" : "NO"),
                                               INST_NOMBRE = e.INST_NOMBRE,
                                               INST_NRO = e.INST_NRO,
                                               INST_TELEFONO = e.INST_TELEFONO,
                                               UsuarioAlta = e.USUARIO_ALTA,
                                               UsuarioModificacion = e.USUARIO_MODIF,
                                               ID_DEPARTAMENTO = e.ID_DEPARTAMENTO,
                                               ID_BARRIO = e.ID_BARRIO
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
                                    where e.INST_ID == INST_ID && e.ESTADO == "A"
                                    select new Institucion
                                               {
                                                   INST_ID = e.INST_ID,
                                                   FechaAlta = e.FEC_ALTA,
                                                   FechaModificacion = e.FEC_MODIF,
                                                   ID_CALLE = e.ID_CALLE,
                                                   ID_LOCALIDAD = e.ID_LOCALIDAD,
                                                   ID_PROVINCIA = e.ID_PROVINCIA,
                                                   INS_PROPIA = (e.INS_PROPIA == "1" ? "SI" : "NO"),
                                                   INST_NOMBRE = e.INST_NOMBRE,
                                                   INST_NRO = e.INST_NRO,
                                                   INST_TELEFONO = e.INST_TELEFONO,
                                                   UsuarioAlta = e.USUARIO_ALTA,
                                                   UsuarioModificacion = e.USUARIO_MODIF,
                                                   ID_DEPARTAMENTO = e.ID_DEPARTAMENTO,
                                                   ID_BARRIO = e.ID_BARRIO
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
                                              INST_NOMBRE = pInstitucion.INST_NOMBRE,
                                              INST_NRO = pInstitucion.INST_NRO,
                                              INST_TELEFONO = pInstitucion.INST_TELEFONO,
                                              INS_PROPIA = pInstitucion.INS_PROPIA,
                                              ID_PROVINCIA = pInstitucion.ID_PROVINCIA,
                                              ID_BARRIO = pInstitucion.ID_BARRIO,
                                              ID_CALLE = pInstitucion.ID_CALLE,
                                              ID_DEPARTAMENTO = pInstitucion.ID_DEPARTAMENTO,
                                              ID_LOCALIDAD = pInstitucion.ID_LOCALIDAD,
                                              USUARIO_ALTA= "Test",
                                              USUARIO_MODIF = "Test",
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
                var IN = mDb.T_INSTITUCIONES.FirstOrDefault(c => c.INST_ID == pInstitucion.INST_ID);

                IN.INST_NOMBRE = pInstitucion.INST_NOMBRE;

                mDb.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool EliminarInstitucion(int INST_ID)
        {
            try
            {
                var IN = mDb.T_INSTITUCIONES.FirstOrDefault(c => c.INST_ID == INST_ID);

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
