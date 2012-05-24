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
    public class AlumnosRepositorio : BaseRepositorio, IAlumnosRepositorio
    {
        public CursosDB mDb;

        public AlumnosRepositorio(ILoggedUserHelper helper)
            : base(helper)
        {

            mDb = new CursosDB();
        }

        IQueryable<IAlumnos> QAlumnos()
        {
            var a = (from c in mDb.T_ALUMNOS
                     where c.ESTADO == "A"
                     select
                         new Alumno
                             {
                                 Cuil = c.CUIL,
                                 Apellido = c.APELLIDO,
                                 Nombre = c.NOMBRE,
                                 Estado = c.ESTADO,
                                 Estado_Civil = c.T_TIPOS_ESTADO_CIVIL.N_TIPO_ESTADO_CIVIL,
                                 Fecha_Nacimiento = c.FEC_NACIMIENTO ?? System.DateTime.Now,
                                 Id_Alumno = c.ID_ALUMNO,
                                 Id_Tipo_Dni = c.ID_TIPO_DNI ?? 0,
                                 Id_Tipo_Estado_Civil = c.ID_TIPO_ESTADO_CIVIL ?? 0,
                                 Id_Tipo_Sexo = c.ID_TIPO_SEXO ?? 0,
                                 Nro_Documento = c.NRO_DOCUMENTO,
                                 FechaAlta = c.FEC_ALTA,
                                 FechaModificacion = c.FEC_MODIF,
                                 Sexo = c.T_TIPOS_SEXO.N_TIPO_SEXO,
                                 Tipo_Dni = c.T_TIPOS_DNI.N_TIPO_DNI,
                                 UsuarioAlta = c.USR_ALTA,
                                 UsuarioModificacion = c.USR_MODIF,
                                 Nro_Resolucion = c.NRO_RESOLUCION,
                                 Nro_Telefono = c.NRO_TELEFONO,
                                 Nro_Celular = c.NRO_CELULAR,
                                 Provincia = c.PROVINCIA,
                                 Localidad = c.LOCALIDAD,
                                 Barrio = c.BARRIO,
                                 Calle = c.CALLE,
                                 Nro = c.NRO ?? 0,
                                 Depto = c.DEPTO ?? 0,

                             });

            return a;
        }

        public IList<IAlumnos> GetTodos()
        {
            try
            {
                return QAlumnos().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IAlumnos> GetTodos(int skip, int take)
        {
            try
            {
                return QAlumnos().OrderBy(c => c.Nombre).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {
                throw;

            }
        }

        public int GetCountAlumnos()
        {
            try
            {
                return QAlumnos().ToList().Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IAlumnos> GetTodosByNombreApellido(string nombre, string apellido)
        {
            nombre = nombre == "" ? null : nombre;
            apellido = apellido == "" ? null : apellido;
            return QAlumnos().Where(c => (c.Nombre.ToLower().StartsWith(nombre.ToLower()) || nombre == null) && (c.Apellido.ToLower().StartsWith(apellido.ToLower()) || apellido == null)).ToList();
        }

        public IList<IAlumnos> GetTodosByDni(string dni)
        {
            try
            {
                return QAlumnos().Where(c => c.Nro_Documento == dni).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IAlumnos> GetTodosByCondicionCurso(int id_condicion_curso)
        {
            try
            {

                //var dario = (from a in mdb.T_FICHAS
                //             join t in mdb.T_LOCALIDADES on t.ID_LOCALIDAD equals a.ID_LOCALIDAD
                //             select new Ficha { }).ToList();

                var ListaAlumno =
                    (from c in mDb.T_ALUMNOS
                     join cu in mDb.T_INSCRIPCIONES on c.ID_ALUMNO equals cu.ID_ALUMNO
                     where c.ESTADO == "A" && cu.ID_CONDICION_CURSO == id_condicion_curso
                     select
                         new Alumno
                             {
                                 Cuil = c.CUIL,
                                 Apellido = c.APELLIDO,
                                 Nombre = c.NOMBRE,
                                 Estado = c.ESTADO,
                                 Estado_Civil = c.T_TIPOS_ESTADO_CIVIL.N_TIPO_ESTADO_CIVIL,
                                 Fecha_Nacimiento = c.FEC_NACIMIENTO ?? System.DateTime.Now,
                                 Id_Alumno = c.ID_ALUMNO,
                                 Id_Tipo_Dni = c.ID_TIPO_DNI ?? 0,
                                 Id_Tipo_Estado_Civil = c.ID_TIPO_ESTADO_CIVIL ?? 0,
                                 Id_Tipo_Sexo = c.ID_TIPO_SEXO ?? 0,
                                 Nro_Documento = c.NRO_DOCUMENTO,
                                 FechaAlta = c.FEC_ALTA,
                                 FechaModificacion = c.FEC_MODIF,
                                 Sexo = c.T_TIPOS_SEXO.N_TIPO_SEXO,
                                 Tipo_Dni = c.T_TIPOS_DNI.N_TIPO_DNI,
                                 UsuarioAlta = c.USR_ALTA,
                                 UsuarioModificacion = c.USR_MODIF
                             }).ToList().Cast<IAlumnos>().ToList();
                return ListaAlumno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IAlumnos> GetTodosAlumnosSinGrupo(int id_condicion_curso)
        {
            try
            {
                var ListaAlumno =
                    (from c in mDb.T_ALUMNOS
                     join cu in mDb.T_INSCRIPCIONES on c.ID_ALUMNO equals cu.ID_ALUMNO
                     where
                         c.ESTADO == "A" && cu.ID_CONDICION_CURSO == id_condicion_curso &&
                         !(from d in mDb.T_ALUMONOS_GRUPO where d.ESTADO == "A" select d.ID_ALUMNO).Contains(
                             cu.ID_ALUMNO)
                     select
                         new Alumno
                             {
                                 Cuil = c.CUIL,
                                 Apellido = c.APELLIDO,
                                 Nombre = c.NOMBRE,
                                 Estado = c.ESTADO,
                                 Estado_Civil = c.T_TIPOS_ESTADO_CIVIL.N_TIPO_ESTADO_CIVIL,
                                 Fecha_Nacimiento = c.FEC_NACIMIENTO ?? System.DateTime.Now,
                                 Id_Alumno = c.ID_ALUMNO,
                                 Id_Tipo_Dni = c.ID_TIPO_DNI ?? 0,
                                 Id_Tipo_Estado_Civil = c.ID_TIPO_ESTADO_CIVIL ?? 0,
                                 Id_Tipo_Sexo = c.ID_TIPO_SEXO ?? 0,
                                 Nro_Documento = c.NRO_DOCUMENTO,
                                 FechaAlta = c.FEC_ALTA,
                                 FechaModificacion = c.FEC_MODIF,
                                 Sexo = c.T_TIPOS_SEXO.N_TIPO_SEXO,
                                 Tipo_Dni = c.T_TIPOS_DNI.N_TIPO_DNI,
                                 UsuarioAlta = c.USR_ALTA,
                                 UsuarioModificacion = c.USR_MODIF,
                                 Nro_Resolucion = c.NRO_RESOLUCION
                             }).ToList().Cast<IAlumnos>().ToList();
                return ListaAlumno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IAlumnos> GetTodosAlumnosEnGrupo(int id_grupo, int id_condicion_curso)
        {
            try
            {
                var ListaAlumno =
                    (from c in mDb.T_ALUMNOS
                     join alcu in mDb.T_ALUMONOS_GRUPO on c.ID_ALUMNO equals alcu.ID_ALUMNO
                     where c.ESTADO == "A" && alcu.ID_GRUPO == id_grupo && alcu.ID_CONDICION_CURSO == id_condicion_curso && alcu.ESTADO == "A"
                     select
                         new Alumno
                         {
                             Cuil = c.CUIL,
                             Apellido = c.APELLIDO,
                             Nombre = c.NOMBRE,
                             Estado = c.ESTADO,
                             Estado_Civil = c.T_TIPOS_ESTADO_CIVIL.N_TIPO_ESTADO_CIVIL,
                             Fecha_Nacimiento = c.FEC_NACIMIENTO ?? System.DateTime.Now,
                             Id_Alumno = c.ID_ALUMNO,
                             Id_Tipo_Dni = c.ID_TIPO_DNI ?? 0,
                             Id_Tipo_Estado_Civil = c.ID_TIPO_ESTADO_CIVIL ?? 0,
                             Id_Tipo_Sexo = c.ID_TIPO_SEXO ?? 0,
                             Nro_Documento = c.NRO_DOCUMENTO,
                             FechaAlta = c.FEC_ALTA,
                             FechaModificacion = c.FEC_MODIF,
                             Sexo = c.T_TIPOS_SEXO.N_TIPO_SEXO,
                             Tipo_Dni = c.T_TIPOS_DNI.N_TIPO_DNI,
                             UsuarioAlta = c.USR_ALTA,
                             UsuarioModificacion = c.USR_MODIF,
                             Nro_Resolucion = c.NRO_RESOLUCION
                         }).ToList().Cast<IAlumnos>().ToList();
                return ListaAlumno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IAlumnos GetUno(int id_alumno)
        {
            try
            {
                return QAlumnos().Where(c => c.Id_Alumno == id_alumno).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Agregar(IAlumnos alumno)
        {
            try
            {
                base.AgregarDatosAlta(alumno);


                T_ALUMNOS T_Alumnos = new T_ALUMNOS()
                                          {
                                              ESTADO = alumno.Estado,
                                              FEC_ALTA = alumno.FechaAlta,
                                              USR_ALTA = alumno.UsuarioAlta,
                                              FEC_MODIF = alumno.FechaModificacion,
                                              USR_MODIF = alumno.UsuarioModificacion,
                                              CUIL = alumno.Cuil,
                                              FEC_NACIMIENTO = alumno.Fecha_Nacimiento,
                                              NOMBRE = alumno.Nombre,
                                              APELLIDO = alumno.Apellido,
                                              NRO_DOCUMENTO = alumno.Nro_Documento,
                                              ID_TIPO_DNI = alumno.Id_Tipo_Dni,
                                              ID_TIPO_ESTADO_CIVIL = alumno.Id_Tipo_Estado_Civil,
                                              ID_TIPO_SEXO = alumno.Id_Tipo_Sexo,
                                              NRO_RESOLUCION = alumno.Nro_Resolucion,
                                              NRO_TELEFONO = alumno.Nro_Telefono,
                                              NRO_CELULAR = alumno.Nro_Celular,
                                              PROVINCIA =alumno.Provincia,
                                              LOCALIDAD = alumno.Localidad,
                                              BARRIO = alumno.Barrio,
                                              CALLE = alumno.Calle,
                                              NRO = alumno.Nro,
                                              DEPTO = alumno.Depto

                                          };


                mDb.AddToT_ALUMNOS(T_Alumnos);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(IAlumnos alumno)
        {
            try
            {
                base.AgregarDatosAlta(alumno);
                var alu = mDb.T_ALUMNOS.FirstOrDefault(c => c.ID_ALUMNO == alumno.Id_Alumno);
                alu.FEC_MODIF = alumno.FechaModificacion;
                alu.USR_MODIF = alumno.Estado;
                alu.CUIL = alumno.Cuil;
                alu.FEC_NACIMIENTO = alumno.Fecha_Nacimiento;
                alu.NOMBRE = alumno.Nombre;
                alu.APELLIDO = alumno.Apellido;
                alu.NRO_DOCUMENTO = alumno.Nro_Documento;
                alu.ID_TIPO_DNI = alumno.Id_Tipo_Dni;
                alu.ID_TIPO_ESTADO_CIVIL = alumno.Id_Tipo_Estado_Civil;
                alu.ID_TIPO_SEXO = alumno.Id_Tipo_Sexo;
                alu.NRO_RESOLUCION = alumno.Nro_Resolucion;
                alu.NRO_TELEFONO = alumno.Nro_Telefono;
                alu.NRO_CELULAR = alumno.Nro_Celular;
                alu.PROVINCIA = alumno.Provincia;
                alu.LOCALIDAD = alumno.Localidad;
                alu.BARRIO = alumno.Barrio;
                alu.CALLE = alumno.Calle;
                alu.NRO = alumno.Nro;
                alu.DEPTO = alumno.Depto;
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(int id_alumno, string nro_resolucion)
        {
            try
            {
                IComunDatos datos = new ComunDatos();
                base.AgregarDatosEliminacion(datos);

                var alu = mDb.T_ALUMNOS.FirstOrDefault(c => c.ID_ALUMNO == id_alumno);
                alu.ESTADO = datos.Estado;
                alu.FEC_MODIF = datos.FechaModificacion;
                alu.USR_MODIF = datos.UsuarioModificacion;
                alu.NRO_RESOLUCION = nro_resolucion;
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AsiganraGrupo(int id_grupo, int id_alumno, int id_condicion_curso)
        {
            try
            {
                IComunDatos datos = new ComunDatos();
                base.AgregarDatosAlta(datos);

                T_ALUMONOS_GRUPO t_alumnos_grupo = new T_ALUMONOS_GRUPO()
                                                       {
                                                           ID_CONDICION_CURSO = id_condicion_curso,
                                                           ID_ALUMNO = id_alumno,
                                                           ID_GRUPO = id_grupo,
                                                           ESTADO = datos.Estado,
                                                           FEC_ALTA = datos.FechaAlta,
                                                           FEC_MODIF = datos.FechaModificacion,
                                                           USR_MODIF = datos.UsuarioModificacion,
                                                           USR_ALTA = datos.UsuarioAlta
                                                       };


                mDb.AddToT_ALUMONOS_GRUPO(t_alumnos_grupo);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DesasignaraGrupo(int id_grupo, int id_alumno, int id_condicion_curso)
        {
            IComunDatos datos = new ComunDatos();
            base.AgregarDatosEliminacion(datos);

            var alu =
                mDb.T_ALUMONOS_GRUPO.FirstOrDefault(
                    c =>
                    c.ID_ALUMNO == id_alumno && c.ID_GRUPO == id_grupo && c.ID_CONDICION_CURSO == id_condicion_curso &&
                    c.ESTADO == "A");
            alu.ESTADO = datos.Estado;
            alu.FEC_MODIF = datos.FechaModificacion;
            alu.USR_MODIF = datos.UsuarioModificacion;
            mDb.SaveChanges();
            return true;

        }

        public IList<IAlumnos> BuscarAlumnos(string nombre, string apellido, string dni, string cuil)
        {
            try
            {
                nombre = nombre == "" ? null : nombre;
                apellido = apellido == "" ? null : apellido;
                dni = dni == "" ? null : dni;
                cuil = cuil == "" ? null : cuil;

                return QAlumnos().Where(c => (c.Nombre.ToLower().StartsWith(nombre.ToLower()) || nombre == null) && (c.Apellido.ToLower().StartsWith(apellido.ToLower()) || apellido == null) && (c.Cuil.ToLower().StartsWith(cuil.ToLower()) || cuil == null) && (c.Nro_Documento.ToLower().StartsWith(dni.ToLower()) || dni == null)).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IAlumnos> BuscarAlumnos(string nombre, string apellido, string dni, string cuil, int skip, int take)
        {
            try
            {
                nombre = nombre == "" ? null : nombre;
                apellido = apellido == "" ? null : apellido;
                dni = dni == "" ? null : dni;
                cuil = cuil == "" ? null : cuil;

                return
                    QAlumnos().Where(
                        c =>
                        (c.Nombre.ToLower().StartsWith(nombre.ToLower()) || nombre == null) &&
                        (c.Apellido.ToLower().StartsWith(apellido.ToLower()) || apellido == null) &&
                        (c.Cuil.ToLower().StartsWith(cuil.ToLower()) || cuil == null) &&
                        (c.Nro_Documento.ToLower().StartsWith(dni.ToLower()) || dni == null)).OrderBy(c => c.Nombre).
                        Skip(skip).Take(take).
                        ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
