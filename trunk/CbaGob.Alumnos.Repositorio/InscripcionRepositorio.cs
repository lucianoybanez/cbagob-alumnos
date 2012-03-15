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

        public InscripcionRepositorio(ILoggedUserHelper helper):base(helper)
        {
            mDb = new CursosDB();
        }

        #region  'Inscripciones'

        private IQueryable<IInscripcion> QInscripcion(string estado)
        {
            var a = (from c in mDb.T_INSCRIPCIONES
                     where c.ESTADO == estado
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
                                 ApellidoAlumno = c.T_ALUMNOS.APELLIDO,
                                 NombreAlumno = c.T_ALUMNOS.NOMBRE,
                                 Estado = c.ESTADO,
                                 IdCurso = c.T_CONDICIONES_CURSO.ID_CURSO,
                                 IdEstadoCurso = c.T_CONDICIONES_CURSO.ID_ESTADO_CURSO,
                                 IdInstitucion = c.T_CONDICIONES_CURSO.ID_INSTITUCION,
                                 IdModalidad = c.T_CONDICIONES_CURSO.ID_MODALIDAD,
                                 IdNivel = c.T_CONDICIONES_CURSO.ID_NIVEL,
                                 NombreModalidad = c.T_CONDICIONES_CURSO.T_MODALIDADES.N_MODALIDAD,
                                 NombreEstadoCurso = c.T_CONDICIONES_CURSO.T_ESTADOS_CURSO.N_ESTADO_CURSO,
                                 NombreInstitucion = c.T_CONDICIONES_CURSO.T_INSTITUCIONES.N_INSTITUCION,
                                 NombreNivel = c.T_CONDICIONES_CURSO.T_NIVELES.N_NIVEL,
                                 NombrePrograma = c.T_CONDICIONES_CURSO.T_PROGRAMAS.N_PROGRAMA,
                                 idPrograma = c.T_CONDICIONES_CURSO.ID_PROGRAMA,
                                 Dni = c.T_ALUMNOS.NRO_DOCUMENTO,
                                 FechaFin = c.T_CONDICIONES_CURSO.FEC_FIN,
                                 FechaIncio = c.T_CONDICIONES_CURSO.FEC_INICIO,
                                 NroResolucion = c.T_CONDICIONES_CURSO.NRO_RESOLUCION
                             });
            return a;
        }

        public IList<IInscripcion> GetAllInscripcion(int skip, int take)
        {
            return QInscripcion("A").OrderBy(c => c.NombreInstitucion).Skip(skip).Take(take).ToList();
        }

        public int GetAllInscripcion()
        {
            return QInscripcion("A").Count();
        }

        public IList<IInscripcion> GetAllInscripcionByAlumno(int id_alumno)
        {

            return QInscripcion("A").Where(c => c.Id_Alumno == id_alumno).ToList();

        }

        public IList<IInscripcion> GetAllInscripcionByGrupo(int idGrupo)
        {
            var inscripciones = (from c in mDb.T_INSCRIPCIONES
                                 join alu in mDb.T_ALUMNOS on c.ID_ALUMNO equals alu.ID_ALUMNO
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
                                         NombreAlumno = alu.NOMBRE
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

            return QInscripcion("A").Where(c => c.IdInscripcion == id_inscripcion).FirstOrDefault();

        }

        public IInscripcion GetInscripcion(int id_condicionCurso, int idAlumno)
        {
            return QInscripcion("I").Where(c => c.Id_Alumno == idAlumno && c.Id_Condicion_Curso == id_condicionCurso).
                    FirstOrDefault();
        }

        public IList<IInscripcion> GetAllInscripcionBy(string nombre, string apellido, string dni, string institucion)
        {
            apellido = apellido == "" ? null : apellido;
            nombre = nombre == "" ? null : nombre;

            if (!string.IsNullOrEmpty(dni))
            {
                return QInscripcion("A").Where(c => c.Dni == dni).ToList();
            }
            if (!string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(apellido))
            {
                return QInscripcion("A").Where(c => (c.NombreAlumno.ToLower().StartsWith(nombre.ToLower()) || nombre == null) && (c.ApellidoAlumno.ToLower().StartsWith(apellido.ToLower()) || apellido == null)).ToList();
            }
            if (!string.IsNullOrEmpty(institucion))
            {
                return QInscripcion("A").Where(c => c.NombreInstitucion.ToLower().StartsWith(institucion.ToLower())).ToList();
            }
            return null;
        }

        public IList<IInscripcionReporte> GetAllInscripcionBy(int CondicionCurso)
        {
            var a = (from p in mDb.T_INSCRIPCIONES
                     where p.ID_CONDICION_CURSO == CondicionCurso
                     select new InscripcionReporte
                                {
                                    CUIL = p.T_ALUMNOS.CUIL,
                                    FechaNacimiento = p.T_ALUMNOS.FEC_NACIMIENTO,
                                    Telefono = p.T_ALUMNOS.NRO_TELEFONO,
                                    Sexo = p.T_ALUMNOS.ID_TIPO_SEXO ?? 1,
                                    NombreAlumno = p.T_ALUMNOS.APELLIDO + ", " + p.T_ALUMNOS.NOMBRE,
                                    ClasesAsistidas =
                                        p.T_PRESENTISMO.Where(c => c.ID_INSCRIPCION == p.ID_INSCRIPCION).Select(
                                            c => c.CLASES_ASISTIDAS).FirstOrDefault(),
                                    Estado =
                                        p.ESTADO=="A",
                                    Notas =
                                        p.T_EXAMENES.Where(c => c.ID_INSCRIPCION == p.ID_INSCRIPCION).Sum(c => c.NOTA) == null ? 0 : p.T_EXAMENES.Where(c => c.ID_INSCRIPCION == p.ID_INSCRIPCION).Sum(c => c.NOTA),


                                }).ToList().Cast<IInscripcionReporte>().ToList();
            return a;
        }

     

        #endregion

        #region 'CRUD Inscripciones'

        public bool AgregarInscripcion(IInscripcion inscripcion)
        {
            try
            {
                base.AgregarDatosAlta(inscripcion);

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
                mDb.AddToT_INSCRIPCIONES(t_inscripcion);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarInscripcion(IInscripcion inscripcion)
        {
            try
            {
                base.AgregarDatosModificacion(inscripcion);
                var t_inscripcion = mDb.T_INSCRIPCIONES.Where(c => c.ID_INSCRIPCION == inscripcion.IdInscripcion).FirstOrDefault();
                t_inscripcion.FEC_MODIF = inscripcion.FechaModificacion;
                t_inscripcion.USR_MODIF = inscripcion.UsuarioModificacion;
                t_inscripcion.ESTADO = inscripcion.Estado;
                t_inscripcion.DESCRIPCION = inscripcion.Descripcion;
                t_inscripcion.FECHA = inscripcion.Fecha;
                mDb.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
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

                return false;
            }
        }


        #endregion

        #region 'Presentismo'

        public bool GuardarPresentismo(IPresentismo presentismo)
        {
            try
            {
                base.AgregarDatosAlta(presentismo);

                T_PRESENTISMO obj = new T_PRESENTISMO()
                {
                    ESTADO = presentismo.Estado,
                    USR_ALTA = presentismo.UsuarioAlta,
                    USR_MODIF = presentismo.UsuarioModificacion,
                    FEC_MODIF = presentismo.FechaModificacion,
                    FEC_ALTA = presentismo.FechaAlta,
                    CLASES_ASISTIDAS = presentismo.ClasesAsistidas,
                    ID_INSCRIPCION = presentismo.IdInscripcion,
                };

                mDb.AddToT_PRESENTISMO(obj);
                mDb.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ModificarPresentismo(IPresentismo presentismo)
        {
            try
            {
                base.AgregarDatosModificacion(presentismo);

                var IN = mDb.T_PRESENTISMO.FirstOrDefault(c => c.ID_PRESENTISMO == presentismo.IdPresentismo);
                IN.FEC_MODIF = presentismo.FechaModificacion;
                IN.USR_MODIF = presentismo.UsuarioModificacion;
                IN.ESTADO = presentismo.Estado;
                IN.CLASES_ASISTIDAS = presentismo.ClasesAsistidas;
                mDb.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IPresentismo GetPresentismo(int idInscripcion)
        {
            var a = (from c in mDb.T_PRESENTISMO
                     where c.ESTADO == "A" && c.ID_INSCRIPCION == idInscripcion
                     select
                         new Presentismo()
                         {
                             FechaAlta = c.FEC_ALTA,
                             FechaModificacion = c.FEC_MODIF,
                             UsuarioAlta = c.USR_ALTA,
                             UsuarioModificacion = c.USR_MODIF,
                             IdInscripcion = c.ID_INSCRIPCION,
                             Estado = c.ESTADO,
                             ClasesAsistidas = c.CLASES_ASISTIDAS,
                             IdPresentismo = c.ID_PRESENTISMO,
                         }).FirstOrDefault();
            return a;
        }

        #endregion


    }
}
