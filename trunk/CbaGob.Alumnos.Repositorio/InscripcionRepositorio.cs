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
    public class InscripcionRepositorio : BaseRepositorio, IInscripcionRepositorio
    {
        private CursosDB mDb;

        public InscripcionRepositorio()
        {
            mDb = new CursosDB();
        }

        private IQueryable<IInscripcion> QInscripcion()
        {
            var a = (from c in mDb.T_INSCRIPCIONES
                     where c.ESTADO == "A"
                     select
                         new Inscripcion
                             {
                                 Fecha = c.FECHA,
                                 FechaAlta = c.FEC_ALTA,
                                 FechaModificacion = c.FEC_MODIF,
                                 Id_Alumno = c.ID_ALUMNO,
                                 Nombre_Grupo = c.T_GRUPOS.N_GRUPO,
                                 Nombre_Curso = c.T_GRUPOS.T_CONDICIONES_CURSO.T_CURSOS.N_CURSO,
                                 UsuarioAlta = c.USR_ALTA,
                                 UsuarioModificacion = c.USR_MODIF,
                                 Descripcion = c.DESCRIPCION,
                                 Id_Grupo = c.ID_GRUPO,
                                 Id_Inscipcion = c.ID_INSCRIPCION
                             });
            return a;
        }


        public IList<IInscripcion> GetAllInscripcion()
        {
            try
            {
                return QInscripcion().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IInscripcion> GetAllInscripcionByAlumno(int id_alumno)
        {
            try
            {
                return QInscripcion().Where(c => c.Id_Alumno == id_alumno).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IInscripcion GetInscripcion(int id_inscripcion)
        {
            try
            {
                return QInscripcion().Where(c => c.Id_Inscipcion == id_inscripcion).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarInscripcion(IInscripcion inscripcion)
        {
            try
            {
                base.AgregarDatosModificacion(inscripcion);

                T_INSCRIPCIONES t_inscripcion = new T_INSCRIPCIONES
                                                    {
                                                        ID_ALUMNO = inscripcion.Id_Alumno,
                                                        ID_GRUPO = inscripcion.Id_Grupo,
                                                        ESTADO = inscripcion.Estado,
                                                        FEC_ALTA = inscripcion.FechaAlta,
                                                        FEC_MODIF = inscripcion.FechaModificacion,
                                                        FECHA = inscripcion.Fecha,
                                                        USR_ALTA = inscripcion.UsuarioAlta,
                                                        USR_MODIF = inscripcion.UsuarioModificacion,
                                                        DESCRIPCION = inscripcion.Descripcion
                                                    };

                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarInscripcion(IInscripcion inscripcion)
        {
            try
            {
                base.AgregarDatosModificacion(inscripcion);

                var t_inscripcion = mDb.T_INSCRIPCIONES.Where(c => c.ID_INSCRIPCION == inscripcion.Id_Inscipcion).FirstOrDefault();

                t_inscripcion.ID_ALUMNO = inscripcion.Id_Alumno;
                t_inscripcion.FECHA = inscripcion.Fecha;
                t_inscripcion.FEC_MODIF = inscripcion.FechaModificacion;
                t_inscripcion.USR_MODIF = inscripcion.UsuarioModificacion;
                t_inscripcion.ESTADO = inscripcion.Estado;
                t_inscripcion.ID_GRUPO = inscripcion.Id_Grupo;

                mDb.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool EliminarInscripcion(int id_inscripcion)
        {
            try
            {

                IComunDatos comundato = new ComunDatos();

                base.AgregarDatosEliminacion(comundato);

                var t_inscripcion = mDb.T_INSCRIPCIONES.Where(c => c.ID_INSCRIPCION == id_inscripcion).FirstOrDefault();


                t_inscripcion.ESTADO = comundato.Estado;
                t_inscripcion.FEC_MODIF = comundato.FechaModificacion;
                t_inscripcion.USR_MODIF = comundato.UsuarioModificacion;

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
