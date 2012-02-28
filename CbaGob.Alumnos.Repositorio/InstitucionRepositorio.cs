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
    public class InstitucionRepositorio : BaseRepositorio,IInstitucionRepositorio
    {
        public CursosDB mDb;


        public InstitucionRepositorio()
        {
            mDb = new CursosDB();
        }


        private IQueryable<IInstitucion> QInstitucion()
        {
            try
            {
                var qIns = (from e in mDb.T_INSTITUCIONES
                            where e.ESTADO == "A"
                            select
                                new Institucion
                                    {
                                        Id_Institucion = e.ID_INSTITUCION,
                                        FechaAlta = e.FEC_ALTA,
                                        FechaModificacion = e.FEC_MODIF,
                                        Id_Domicilio = e.ID_DOMICILIO ?? 0,
                                        espropia = (e.INS_PROPIA == "1" ? "SI" : "NO"),
                                        Nombre_Institucion = e.N_INSTITUCION,
                                        UsuarioAlta = e.USR_ALTA,
                                        UsuarioModificacion = e.USR_MODIF,
                                        DireccionCompleta =
                                            e.T_DOMICILIO.PROVINCIA + "," + e.T_DOMICILIO.LOCALIDAD + "," +
                                            e.T_DOMICILIO.BARRIO + "," + e.T_DOMICILIO.CALLE + "," + e.T_DOMICILIO.NRO
                                    });
                return qIns;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IList<IInstitucion> GetInstituciones()
        {
            try
            {
                return  QInstitucion().ToList();;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IInstitucion GetInstitucion(int IdInstitucion)
        {
            try
            {
                var mInstirucion = QInstitucion().Where(c => c.Id_Institucion == IdInstitucion).SingleOrDefault();

                return mInstirucion;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region CRUD

        public bool AgregarInstitucion(IInstitucion institucion)
        {
            try
            {
                base.AgregarDatosAlta(institucion);

                T_INSTITUCIONES obj = new T_INSTITUCIONES()
                                          {
                                              ESTADO = "A",
                                              N_INSTITUCION = institucion.Nombre_Institucion,
                                              INS_PROPIA = institucion.espropia,
                                              USR_ALTA = institucion.UsuarioAlta,
                                              USR_MODIF = institucion.UsuarioModificacion,
                                              FEC_MODIF = institucion.FechaModificacion,
                                              FEC_ALTA = DateTime.Now,
                                              ID_DOMICILIO = institucion.Id_Domicilio
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

        public bool ModificarInstitucion(IInstitucion institucion)
        {
            try
            {
                base.AgregarDatosModificacion(institucion);

                var IN = mDb.T_INSTITUCIONES.FirstOrDefault(c => c.ID_INSTITUCION == institucion.Id_Institucion);

                IN.N_INSTITUCION = institucion.Nombre_Institucion;
                IN.ID_DOMICILIO = institucion.Id_Domicilio;
                IN.INS_PROPIA = institucion.espropia;
                IN.FEC_MODIF = institucion.FechaModificacion;
                IN.USR_MODIF = institucion.UsuarioModificacion;
                mDb.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool EliminarInstitucion(int idinstitucion)
        {
            try
            {
                IComunDatos comun = new ComunDatos();

                base.AgregarDatosEliminacion(comun);
                
                var IN = mDb.T_INSTITUCIONES.FirstOrDefault(c => c.ID_INSTITUCION == idinstitucion);

                IN.ESTADO = "I";
                IN.USR_MODIF = comun.UsuarioModificacion;
                IN.FEC_MODIF = comun.FechaModificacion;

                mDb.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
