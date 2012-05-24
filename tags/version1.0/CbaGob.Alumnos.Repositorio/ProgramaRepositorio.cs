using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class ProgramaRepositorio : BaseRepositorio, IProgramaRepositorio
    {

        private CursosDB mDb;

        public ProgramaRepositorio(ILoggedUserHelper helper)
            : base(helper)
        {
            mDb = new CursosDB();
        }


        private IQueryable<IPrograma> QPrograma()
        {
            var a = (from c in mDb.T_PROGRAMAS
                     where c.ESTADO == "A"
                     select
                         new Programa
                             {
                                 Descripcion = c.DESCRIPCION,
                                 IdPrograma = c.ID_PROGRAMA,
                                 NombrePrograma = c.N_PROGRAMA,
                                 Nro_resolucion = c.NRO_RESOLUCION
                             }
                    );

            return a;
        }



        public IList<IPrograma> GetProgramas()
        {
            try
            {
                return QPrograma().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IPrograma GetPrograma(int idprograma)
        {
            try
            {
                return QPrograma().Where(c => c.IdPrograma == idprograma).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCountPrograma()
        {
            try
            {
                return QPrograma().Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IPrograma> GetProgramas(int skip, int take)
        {
            try
            {
                return QPrograma().OrderBy(c => c.NombrePrograma).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarPrograma(IPrograma programa)
        {
            try
            {
                base.AgregarDatosAlta(programa);

                T_PROGRAMAS t_programa = new T_PROGRAMAS
                                             {
                                                 ESTADO = programa.Estado,
                                                 N_PROGRAMA = programa.NombrePrograma,
                                                 NRO_RESOLUCION = programa.Nro_resolucion,
                                                 USR_ALTA = programa.UsuarioAlta,
                                                 FEC_ALTA = programa.FechaAlta,
                                                 USR_MODIF = programa.UsuarioModificacion,
                                                 FEC_MODIF = programa.FechaModificacion,
                                             };

                mDb.AddToT_PROGRAMAS(t_programa);
                mDb.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarPrograma(IPrograma programa)
        {
            try
            {
                base.AgregarDatosModificacion(programa);


                var updatecargo = mDb.T_PROGRAMAS.FirstOrDefault(c => c.ID_PROGRAMA == programa.IdPrograma);

                updatecargo.FEC_MODIF = programa.FechaModificacion;
                updatecargo.USR_MODIF = programa.UsuarioModificacion;
                updatecargo.N_PROGRAMA = programa.NombrePrograma;


                mDb.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarPrograma(int idPrograma, string nro_resolucion)
        {
            try
            {
                IComunDatos programa = new ComunDatos();

                base.AgregarDatosEliminacion(programa);


                var updatecargo = mDb.T_PROGRAMAS.FirstOrDefault(c => c.ID_PROGRAMA == idPrograma);

                updatecargo.ESTADO = programa.Estado;
                updatecargo.FEC_MODIF = programa.FechaModificacion;
                updatecargo.USR_MODIF = programa.UsuarioModificacion;
                updatecargo.NRO_RESOLUCION = nro_resolucion;

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