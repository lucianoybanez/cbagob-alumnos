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
    public class InstitucionRepositorio : BaseRepositorio, IInstitucionRepositorio
    {
        public CursosDB mDb;


        public InstitucionRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDb = new CursosDB();
        }


        private IQueryable<IInstitucion> QInstitucion()
        {

            var qIns = (from e in mDb.T_INSTITUCIONES
                        where e.ESTADO == "A"
                        select
                            new Institucion
                                {
                                    Id_Institucion = e.ID_INSTITUCION,
                                    FechaAlta = e.FEC_ALTA,
                                    FechaModificacion = e.FEC_MODIF,
                                    espropia = (e.INS_PROPIA == "1" ? "SI" : "NO"),
                                    Nombre_Institucion = e.N_INSTITUCION,
                                    UsuarioAlta = e.USR_ALTA,
                                    UsuarioModificacion = e.USR_MODIF,
                                    Provincia = e.PROVINCIA,
                                    Barrio = e.BARRIO,
                                    Localidad = e.LOCALIDAD,
                                    Calle = e.CALLE,
                                    Nro = e.NRO ?? 0,
                                    Depto = e.DEPTO ?? 0,
                                    Nro_Expediente = e.NRO_EXPEDIENTE,
                                    Nro_Resolucion = e.NRO_RESOLUCION,
                                    Telefono = e.TELEFONO

                                });
            return qIns;


        }

        public IList<IInstitucion> GetInstituciones()
        {

            return QInstitucion().ToList(); 

        }

        public IList<IInstitucion> GetInstituciones(int skip, int take)
        {
            return QInstitucion().OrderBy(c => c.Nombre_Institucion).Skip(skip).Take(take).ToList();
        }


        public int GetCountInstituciones()
        {
            return QInstitucion().Count(); 
        }

        public IInstitucion GetInstitucion(int IdInstitucion)
        {

            var mInstirucion = QInstitucion().Where(c => c.Id_Institucion == IdInstitucion).SingleOrDefault();

            return mInstirucion;

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
                                              NRO = institucion.Nro,
                                              PROVINCIA = institucion.Provincia,
                                              LOCALIDAD =  institucion.Localidad,
                                              BARRIO = institucion.Barrio,
                                              CALLE = institucion.Calle,
                                              DEPTO = institucion.Depto,
                                              NRO_EXPEDIENTE = institucion.Nro_Expediente,
                                              NRO_RESOLUCION = institucion.Nro_Resolucion,
                                              TELEFONO = institucion.Telefono
                                          };

                mDb.AddToT_INSTITUCIONES(obj);
                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ModificarInstitucion(IInstitucion institucion)
        {
            try
            {
                base.AgregarDatosModificacion(institucion);

                var IN = mDb.T_INSTITUCIONES.FirstOrDefault(c => c.ID_INSTITUCION == institucion.Id_Institucion);

                IN.N_INSTITUCION = institucion.Nombre_Institucion;
                IN.INS_PROPIA = institucion.espropia;
                IN.FEC_MODIF = institucion.FechaModificacion;
                IN.USR_MODIF = institucion.UsuarioModificacion;
                IN.NRO = institucion.Nro;
                IN.PROVINCIA = institucion.Provincia;
                IN.LOCALIDAD = institucion.Localidad;
                IN.BARRIO = institucion.Barrio;
                IN.CALLE = institucion.Calle;
                IN.DEPTO = institucion.Depto;
                IN.NRO_EXPEDIENTE = institucion.Nro_Expediente;
                IN.NRO_RESOLUCION = institucion.Nro_Resolucion;
                IN.TELEFONO = institucion.Telefono;
                mDb.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarInstitucion(int idinstitucion, string nro_resolucion)
        {
            try
            {
                IComunDatos comun = new ComunDatos();

                base.AgregarDatosEliminacion(comun);

                var IN = mDb.T_INSTITUCIONES.FirstOrDefault(c => c.ID_INSTITUCION == idinstitucion);

                IN.NRO_RESOLUCION = nro_resolucion;
                IN.ESTADO = "I";
                IN.USR_MODIF = comun.UsuarioModificacion;
                IN.FEC_MODIF = comun.FechaModificacion;

                mDb.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IList<IInstitucion> BuscarInstitucion(string nombreinstitucion)
        {
            try
            {
                return
                    QInstitucion().Where(c => c.Nombre_Institucion.ToLower().StartsWith(nombreinstitucion.ToLower())).
                        ToList();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion
    }
}
