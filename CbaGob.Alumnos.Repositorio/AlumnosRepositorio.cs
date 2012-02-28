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


        public AlumnosRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<IAlumnos> GetTodos()
        {
            try
            {
                var ListaAlumno =
                    (from c in mDb.T_ALUMNOS
                     join e in mDb.T_PERSONAS on c.ID_PERSONA equals e.ID_PERSONA
                     where c.ESTADO == "A"
                     select
                         new Alumno
                             {
                                 Cuil = e.CUIL,
                                 Fecha_Nacimiento = e.FECHA_NACIMIENTO ?? System.DateTime.Now,
                                 Id_Alumno = c.ID_ALUMNO,
                                 Id_Persona = c.ID_PERSONA ?? 0,
                                 Id_Estado_Civil = e.ID_ESTADO_CIVIL,
                                 Id_Sexo = e.ID_SEXO,
                                 Id_Tipo_Documento = e.ID_TIPO_DOCUMENTO,
                                 Nov_Nombre = e.NOV_NOMBRE,
                                 Nov_Apellido = e.NOV_APELLIDO,
                                 Nro_Documento = e.NRO_DOCUMENTO
                             }).ToList().Cast<IAlumnos>().ToList();
                return ListaAlumno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IAlumnos> GetTodosByNombreApellido(string nombre, string apellido)
        {
            throw new NotImplementedException();
        }

        public IList<IAlumnos> GetTodosByDni(string dni)
        {
            throw new NotImplementedException();
        }

        public IList<IAlumnos> GetTodosByCondicionCurso(int id_condicion_curso)
        {
            try
            {
                var ListaAlumno =
                    (from c in mDb.T_ALUMNOS
                     join e in mDb.T_PERSONAS on c.ID_PERSONA equals e.ID_PERSONA
                     join cu in mDb.T_INSCRIPCIONES on c.ID_ALUMNO equals cu.ID_ALUMNO
                     where c.ESTADO == "A" && cu.ID_CONDICION_CURSO == id_condicion_curso
                     select
                         new Alumno
                             {
                                 Cuil = e.CUIL,
                                 Fecha_Nacimiento = e.FECHA_NACIMIENTO ?? System.DateTime.Now,
                                 Id_Alumno = c.ID_ALUMNO,
                                 Id_Persona = c.ID_PERSONA ?? 0,
                                 Id_Estado_Civil = e.ID_ESTADO_CIVIL,
                                 Id_Sexo = e.ID_SEXO,
                                 Id_Tipo_Documento = e.ID_TIPO_DOCUMENTO,
                                 Nov_Nombre = e.NOV_NOMBRE,
                                 Nov_Apellido = e.NOV_NOMBRE,
                                 Nro_Documento = e.NRO_DOCUMENTO
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
                     join e in mDb.T_PERSONAS on c.ID_PERSONA equals e.ID_PERSONA
                     join cu in mDb.T_INSCRIPCIONES on c.ID_ALUMNO equals cu.ID_ALUMNO
                     where
                         c.ESTADO == "A" && cu.ID_CONDICION_CURSO == id_condicion_curso &&
                         !(from d in mDb.T_ALUMONOS_GRUPO where d.ESTADO == "A" select d.ID_CONDICION_CURSO).Contains(
                             cu.ID_CONDICION_CURSO)
                     select
                         new Alumno
                             {
                                 Cuil = e.CUIL,
                                 Fecha_Nacimiento = e.FECHA_NACIMIENTO ?? System.DateTime.Now,
                                 Id_Alumno = c.ID_ALUMNO,
                                 Id_Persona = c.ID_PERSONA ?? 0,
                                 Id_Estado_Civil = e.ID_ESTADO_CIVIL,
                                 Id_Sexo = e.ID_SEXO,
                                 Id_Tipo_Documento = e.ID_TIPO_DOCUMENTO,
                                 Nov_Nombre = e.NOV_NOMBRE,
                                 Nov_Apellido = e.NOV_NOMBRE,
                                 Nro_Documento = e.NRO_DOCUMENTO
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
                     join e in mDb.T_PERSONAS on c.ID_PERSONA equals e.ID_PERSONA
                     join alcu in mDb.T_ALUMONOS_GRUPO on c.ID_ALUMNO equals alcu.ID_ALUMNO
                     where c.ESTADO == "A" && alcu.ID_GRUPO == id_grupo && alcu.ID_CONDICION_CURSO == id_condicion_curso && alcu.ESTADO == "A"
                     select
                         new Alumno
                         {
                             Cuil = e.CUIL,
                             Fecha_Nacimiento = e.FECHA_NACIMIENTO ?? System.DateTime.Now,
                             Id_Alumno = c.ID_ALUMNO,
                             Id_Persona = c.ID_PERSONA ?? 0,
                             Id_Estado_Civil = e.ID_ESTADO_CIVIL,
                             Id_Sexo = e.ID_SEXO,
                             Id_Tipo_Documento = e.ID_TIPO_DOCUMENTO,
                             Nov_Nombre = e.NOV_NOMBRE,
                             Nov_Apellido = e.NOV_NOMBRE,
                             Nro_Documento = e.NRO_DOCUMENTO
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
                var alumno =
                    (from c in mDb.T_ALUMNOS
                     join e in mDb.T_PERSONAS on c.ID_PERSONA equals e.ID_PERSONA
                     where c.ESTADO == "A" && c.ID_ALUMNO == id_alumno
                     select
                         new Alumno
                             {
                                 Cuil = e.CUIL,
                                 Fecha_Nacimiento = e.FECHA_NACIMIENTO ?? System.DateTime.Now,
                                 Id_Alumno = c.ID_ALUMNO,
                                 Id_Persona = c.ID_PERSONA ?? 0,
                                 Id_Estado_Civil = e.ID_ESTADO_CIVIL,
                                 Id_Sexo = e.ID_SEXO,
                                 Id_Tipo_Documento = e.ID_TIPO_DOCUMENTO,
                                 Nov_Nombre = e.NOV_NOMBRE,
                                 Nov_Apellido = e.NOV_NOMBRE,
                                 Nro_Documento = e.NRO_DOCUMENTO
                             }).SingleOrDefault();
                return alumno;
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
                T_ALUMNOS T_Alumnos = new T_ALUMNOS()
                                          {
                                              ESTADO = "A",
                                              FEC_ALTA = DateTime.Now,
                                              USR_ALTA = "Test",
                                              FEC_MODIF = DateTime.Now,
                                              USR_MODIF = "Test",
                                              ID_PERSONA = alumno.Id_Persona
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
                var alu = mDb.T_ALUMNOS.FirstOrDefault(c => c.ID_ALUMNO == alumno.Id_Alumno);
                alu.ID_PERSONA = alumno.Id_Persona;
                alu.FEC_MODIF = System.DateTime.Now;
                alu.USR_MODIF = "Test";
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(int id_alumno)
        {
            try
            {
                var alu = mDb.T_ALUMNOS.FirstOrDefault(c => c.ID_ALUMNO == id_alumno);
                alu.ESTADO = "I";
                alu.FEC_MODIF = System.DateTime.Now;
                alu.USR_MODIF = "Test";
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
    }
}
