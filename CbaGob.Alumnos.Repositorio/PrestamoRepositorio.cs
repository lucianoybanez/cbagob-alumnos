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
    public class PrestamoRepositorio : BaseRepositorio, IPrestamoRepositorio
    {
        private CursosDB mDb;

        public PrestamoRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDb = new CursosDB();
        }

        private IQueryable<IPrestamo> QPrestamo()
        {

            var a = (from c in mDb.T_PRESTAMOS
                     where c.ESTADO == "A"
                     select
                         new Prestamo
                             {
                                 Estado = c.ESTADO,
                                 Fec_Fin = c.FEC_FIN,
                                 Fec_Inicio = c.FEC_INICIO,
                                 UsuarioAlta = c.USR_ALTA,
                                 UsuarioModificacion = c.USR_MODIF,
                                 Id_Equipo = c.ID_EQUIPO,
                                 Id_Institucion = c.ID_INSTITUCION,
                                 Id_Prestamo = c.ID_PRESTAMO,
                                 NombreEquipo = c.T_EQUIPOS.N_EQUIPOS,
                                 NombreInstitucion = c.T_INSTITUCIONES.N_INSTITUCION,
                                 Observaciones = c.OBSERVACION,
                                 FechaAlta = c.FEC_ALTA,
                                 FechaModificacion = c.FEC_MODIF

                             });


            return a;
        }

        public IList<IPrestamo> GetPrestamos()
        {
            try
            {
                return QPrestamo().ToList();
            }
            catch (Exception ex)
            {
                    
                throw;
            }
        }

        public IList<IPrestamo> GetPrestamos(int skip, int take)
        {
            try
            {
                return QPrestamo().OrderBy(c => c.NombreInstitucion).Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int GetCountPrestamos()
        {
            try
            {
                return QPrestamo().Count();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IPrestamo> GetPrestamosByInstitucion(int id_institucion)
        {
            try
            {
                return QPrestamo().Where(c => c.Id_Institucion == id_institucion).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IPrestamo GetPrestamo(int id_prestamo)
        {
            try
            {
                return QPrestamo().Where(c => c.Id_Prestamo == id_prestamo).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool AgregarPresatmo(IPrestamo prestamo)
        {
            try
            {
                base.AgregarDatosAlta(prestamo);

                T_PRESTAMOS t_prestamo = new T_PRESTAMOS()
                                             {
                                                 ESTADO = prestamo.Estado,
                                                 FEC_ALTA = prestamo.FechaAlta,
                                                 FEC_MODIF = prestamo.FechaModificacion,
                                                 FEC_FIN = prestamo.Fec_Fin,
                                                 USR_ALTA = prestamo.UsuarioAlta,
                                                 USR_MODIF = prestamo.UsuarioModificacion,
                                                 OBSERVACION = prestamo.Observaciones,
                                                 ID_INSTITUCION = prestamo.Id_Institucion,
                                                 ID_EQUIPO = prestamo.Id_Equipo,
                                                 FEC_INICIO = prestamo.Fec_Inicio
                                             };
                mDb.AddToT_PRESTAMOS(t_prestamo);
                mDb.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool ModificarPresatmo(IPrestamo prestamo)
        {
            try
            {
                base.AgregarDatosModificacion(prestamo);

                var t_prestamo = mDb.T_PRESTAMOS.Where(c => c.ID_PRESTAMO == prestamo.Id_Prestamo).FirstOrDefault();

                t_prestamo.FEC_MODIF = prestamo.FechaModificacion;
                t_prestamo.USR_MODIF = prestamo.UsuarioModificacion;
                t_prestamo.ID_EQUIPO = prestamo.Id_Equipo;
                t_prestamo.ID_INSTITUCION = prestamo.Id_Institucion;
                t_prestamo.OBSERVACION = prestamo.Observaciones;

                mDb.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarPresatmo(int id_presatmo)
        {
            try
            {
                IComunDatos prestamo = new Prestamo();

                base.AgregarDatosEliminacion(prestamo);

                var t_prestamo = mDb.T_PRESTAMOS.Where(c => c.ID_PRESTAMO == id_presatmo).FirstOrDefault();

                t_prestamo.FEC_MODIF = prestamo.FechaModificacion;
                t_prestamo.USR_MODIF = prestamo.UsuarioModificacion;
                t_prestamo.ESTADO = prestamo.Estado;

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
