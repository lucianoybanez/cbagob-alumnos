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
                     join alumnos in mDb.T_ALUMNOS on c.ID_ALUMNO equals alumnos.ID_ALUMNO
                     join personas in mDb.T_PERSONAS on alumnos.ID_PERSONA equals personas.ID_PERSONA
                     where c.ESTADO == "A"
                     select
                         new Inscripcion
                             {
                                 Fecha = c.FECHA,
                                 FechaAlta = c.FEC_ALTA,
                                 FechaModificacion = c.FEC_MODIF,
                                 Id_Alumno = c.ID_ALUMNO,
                                 NombreCurso = c.T_CONDICIONES_CURSO.T_CURSOS.N_CURSO,
                                 UsuarioAlta = c.USR_ALTA,
                                 UsuarioModificacion = c.USR_MODIF,
                                 Descripcion = c.DESCRIPCION,
                                 Id_Condicion_Curso = c.ID_CONDICION_CURSO,
                                 IdInscripcion = c.ID_INSCRIPCION,
                                 ApellidoAlumno = personas.NOV_APELLIDO,
                                 NombreAlumno = personas.NOV_NOMBRE,
                                 Estado = c.ESTADO,
                                 IdCurso = c.T_CONDICIONES_CURSO.ID_CURSO,
                                 IdEstadoCurso = c.T_CONDICIONES_CURSO.ID_ESTADO_CURSO,
                                 IdInstitucion = c.T_CONDICIONES_CURSO.ID_INSTITUCION,
                                 IdModalidad = c.T_CONDICIONES_CURSO.ID_MODALIDAD,
                                 IdNivel = c.T_CONDICIONES_CURSO.ID_MODALIDAD,
                                 NombreModalidad = c.T_CONDICIONES_CURSO.T_MODALIDADES.N_MODALIDAD,
                                 NombreEstadoCurso = c.T_CONDICIONES_CURSO.T_ESTADOS_CURSO.N_ESTADO_CURSO,
                                 NombreInstitucion = c.T_CONDICIONES_CURSO.T_INSTITUCIONES.N_INSTITUCION,
                                 NombreNivel = c.T_CONDICIONES_CURSO.T_NIVELES.N_NIVEL
                             });
            return a;
        }


        public IList<IInscripcion> GetAllInscripcion()
        {
            return QInscripcion().ToList();
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

        public IList<IInscripcion> GetAllInscripcionByGrupo(int idGrupo)
        {
            var inscripciones = (from c in mDb.T_INSCRIPCIONES
                                 join alu in mDb.T_ALUMNOS on c.ID_ALUMNO equals alu.ID_ALUMNO
                                 join per in mDb.T_PERSONAS on alu.ID_PERSONA equals per.ID_PERSONA
                                // where c.ESTADO == "A" && c.ID_GRUPO == idGrupo
                                 select
                                     new Inscripcion
                                     {
                                         Fecha = c.FECHA,
                                         FechaAlta = c.FEC_ALTA,
                                         FechaModificacion = c.FEC_MODIF,
                                         Id_Alumno = c.ID_ALUMNO,
                                    //     Nombre_Grupo = c.T_GRUPOS.N_GRUPO,
                                      //   Nombre_Curso = c.T_GRUPOS.T_CONDICIONES_CURSO.T_CURSOS.N_CURSO,
                                         UsuarioAlta = c.USR_ALTA,
                                         UsuarioModificacion = c.USR_MODIF,
                                         Descripcion = c.DESCRIPCION,
                                    //     Id_Grupo = c.ID_GRUPO,
                                         IdInscripcion = c.ID_INSCRIPCION,
                                    //     Nov_Apellido = per.NOV_APELLIDO,
                                         NombreAlumno = per.NOV_NOMBRE
                                     }).ToList().Cast<IInscripcion>().ToList();
            return inscripciones;
        }

        public int GetInscripcionIdByAlumnoGrupo(int idGrupo, int idAlumno)
        {
          //  var inscripciones = mDb.T_INSCRIPCIONES.Where(c => c.ID_ALUMNO == idAlumno && c.ID_GRUPO == idGrupo).FirstOrDefault();
          //  if (inscripciones != null)
            {
               // return inscripciones.ID_INSCRIPCION;
            }
            return 0;
        }

        public IInscripcion GetInscripcion(int id_inscripcion)
        {
            try
            {
                return QInscripcion().Where(c => c.IdInscripcion == id_inscripcion).FirstOrDefault();
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
                                                        ID_CONDICION_CURSO = inscripcion.Id_Condicion_Curso,
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

                var t_inscripcion = mDb.T_INSCRIPCIONES.Where(c => c.ID_INSCRIPCION == inscripcion.IdInscripcion).FirstOrDefault();

                t_inscripcion.ID_ALUMNO = inscripcion.Id_Alumno;
                t_inscripcion.FECHA = inscripcion.Fecha;
                t_inscripcion.FEC_MODIF = inscripcion.FechaModificacion;
                t_inscripcion.USR_MODIF = inscripcion.UsuarioModificacion;
                t_inscripcion.ESTADO = inscripcion.Estado;
                t_inscripcion.ID_CONDICION_CURSO = inscripcion.Id_Condicion_Curso;

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
