using System;
using System.Linq;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class ExamenRepositorio : BaseRepositorio, IExamenRepositorio
    {
        private CursosDB mDB;

        public ExamenRepositorio()
        {
            mDB = new CursosDB();
        }

        public IList<IExamen> GetExamenes()
        {
            var result = (from p in mDB.T_EXAMENES
                          where p.ESTADO == "A"
                          select new Examen
                                     {
                                         Estado = p.ESTADO,
                                         FechaAlta = p.FEC_ALTA,
                                         FechaModificacion = p.FEC_MODIF,
                                         FechaExamen = p.FEC_EXAMEN,
                                         IdExamen = p.ID_EXAMEN,
                                         IdInscripcion = p.ID_INSCRIPCION,
                                         Nota = p.NOTA,
                                         UsuarioAlta = p.USR_ALTA,
                                         UsuarioModificacion = p.USR_MODIF,
                                         NroExamen = p.NRO_EXAMEN
                                     }).Cast<IExamen>().ToList();
            return result;
        }

        public IExamen GetExamen(int idExamen)
        {
            var result = (from p in mDB.T_EXAMENES
                          where p.ID_EXAMEN == idExamen && p.ESTADO == "A"
                          select new Examen
                                     {
                                         Estado = p.ESTADO,
                                         FechaAlta = p.FEC_ALTA,
                                         FechaModificacion = p.FEC_MODIF,
                                         FechaExamen = p.FEC_EXAMEN,
                                         IdExamen = p.ID_EXAMEN,
                                         IdInscripcion = p.ID_INSCRIPCION,
                                         Nota = p.NOTA,
                                         UsuarioAlta = p.USR_ALTA,
                                         UsuarioModificacion = p.USR_MODIF,
                                         NroExamen = p.NRO_EXAMEN
                                     }).FirstOrDefault();
            return result;
        }

        public bool AgregarExamen(IExamen examen)
        {
            try
            {
                base.AgregarDatosAlta(examen);
                T_EXAMENES ex = new T_EXAMENES()
                {
                    ESTADO = examen.Estado,
                    FEC_ALTA = examen.FechaAlta,
                    FEC_EXAMEN = examen.FechaExamen,
                    FEC_MODIF = examen.FechaModificacion,
                    USR_MODIF = examen.UsuarioModificacion,
                    USR_ALTA = examen.UsuarioAlta,
                    ID_EXAMEN = examen.IdExamen,
                    ID_INSCRIPCION = examen.IdInscripcion,
                    NOTA = examen.Nota,
                    NRO_EXAMEN = examen.NroExamen,
                };
                mDB.AddToT_EXAMENES(ex);
                mDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ModificarExamen(IExamen examen)
        {
            try
            {
                base.AgregarDatosModificacion(examen);
                var ex = mDB.T_EXAMENES.Where(c => c.ID_EXAMEN == examen.IdExamen).FirstOrDefault();
                ex.ESTADO = examen.Estado;
                ex.FEC_EXAMEN = examen.FechaExamen;
                ex.FEC_MODIF = examen.FechaModificacion;
                ex.USR_MODIF = examen.UsuarioModificacion;
                ex.ID_EXAMEN = examen.IdExamen;
                ex.ID_INSCRIPCION = examen.IdInscripcion;
                ex.NOTA = examen.Nota;
                ex.NRO_EXAMEN = examen.NroExamen;
                mDB.AddToT_EXAMENES(ex);
                mDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarExamen(int idExamen)
        {
            try
            {
                IComunDatos datos = new ComunDatos();
                base.AgregarDatosEliminacion(datos);
                var examenes = mDB.T_EXAMENES.FirstOrDefault(c => c.ID_EXAMEN == idExamen);
                examenes.ESTADO = datos.Estado;
                examenes.FEC_MODIF = datos.FechaModificacion;
                examenes.USR_MODIF = datos.UsuarioModificacion;
                mDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}