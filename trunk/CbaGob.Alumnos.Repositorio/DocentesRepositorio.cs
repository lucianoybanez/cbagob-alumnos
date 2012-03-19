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
    public class DocentesRepositorio : BaseRepositorio, IDocentesRepositorio
    {
        public CursosDB mDb;

        public DocentesRepositorio(ILoggedUserHelper helper)
            : base(helper)
        {
            mDb = new CursosDB();
        }

        IQueryable<IDocentes> QDocentes()
        {
            var a = (from c in mDb.T_DOCENTES
                     where c.ESTADO == "A"
                     select new Docentes
                                {
                                    Id_Cargo = c.ID_CARGO,
                                    N_Modalidad = c.N_MODALIDAD,
                                    Estado = c.ESTADO,
                                    FechaAlta = c.FEC_ALTA,
                                    FechaModificacion = c.FEC_MODIF,
                                    UsuarioAlta = c.USR_ALTA,
                                    UsuarioModificacion = c.USR_MODIF,
                                    Id_Docente = c.ID_DOCENTE,
                                    RazonSoial = c.RAZON_SOCIAL,
                                    Cuit_Cuil = c.CUIT_CUIL,
                                    Reproca = c.REPROCA,
                                    Nro_Resolucion = c.NRO_RESOLUCION,
                                    Provincia = c.PROVINCIA,
                                    Barrio = c.BARRIO,
                                    Localidad = c.LOCALIDAD,
                                    Nro = c.NRO ?? 0,
                                    Calle = c.CALLE,
                                    id_tipo_docente = c.ID_TIPO_DOCENTE,
                                    NombreTipoDocente = c.T_TIPOS_DOCENTE.N_TIPO_DOCENTE,
                                    Resolucion_Reproca = c.ROSOL_REPROCA,
                                    Dni = c.DNI,
                                    NombreCargo = c.T_CARGOS.N_CARGO,
                                    FechaNacimiento = c.FEC_NACIMIENTO ?? System.DateTime.Now,
                                    Telefono = c.TELEFONO
                                });

            return a;
        }

        public IList<IDocentes> GetTodos()
        {
            try
            {

                return QDocentes().ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IDocentes> GetTodos(int skip, int take)
        {
            try
            {

                return QDocentes().OrderBy(c => c.RazonSoial).Skip(skip).Take(take).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IDocentes> GetTodosByRazonSocial(string razonsocial)
        {
            return QDocentes().Where(c => c.RazonSoial.StartsWith(razonsocial)).ToList();
        }

        public int GetCountDocentes()
        {
            try
            {
                return QDocentes().Count();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IDocentes GetUno(int id_docente)
        {
            try
            {

                return QDocentes().Where(c => c.Id_Docente == id_docente).SingleOrDefault();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Agregar(IDocentes docente)
        {
            try
            {
                base.AgregarDatosAlta(docente);

                T_DOCENTES T_Docentes = new T_DOCENTES()
                                            {
                                                ESTADO = docente.Estado,
                                                FEC_ALTA = docente.FechaAlta,
                                                USR_ALTA = docente.UsuarioAlta,
                                                FEC_MODIF = docente.FechaModificacion,
                                                USR_MODIF = docente.UsuarioModificacion,
                                                ID_CARGO = docente.Id_Cargo,
                                                N_MODALIDAD = docente.N_Modalidad,
                                                REPROCA = docente.Reproca,
                                                PROVINCIA = docente.Provincia,
                                                LOCALIDAD = docente.Localidad,
                                                BARRIO = docente.Barrio,
                                                CALLE = docente.Calle,
                                                NRO = docente.Nro,
                                                NRO_RESOLUCION = docente.Nro_Resolucion,
                                                ID_TIPO_DOCENTE = docente.id_tipo_docente,
                                                ROSOL_REPROCA = docente.Resolucion_Reproca,
                                                CUIT_CUIL = docente.Cuit_Cuil,
                                                DNI = docente.Dni,
                                                RAZON_SOCIAL = docente.RazonSoial,
                                                FEC_NACIMIENTO = docente.FechaNacimiento,
                                                TELEFONO = docente.Telefono
                                            };


                mDb.AddToT_DOCENTES(T_Docentes);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Modificar(IDocentes docente)
        {

            base.AgregarDatosModificacion(docente);

            try
            {
                var doc = mDb.T_DOCENTES.FirstOrDefault(c => c.ID_DOCENTE == docente.Id_Docente);

                doc.ESTADO = docente.Estado;
                doc.FEC_MODIF = docente.FechaModificacion;
                doc.USR_MODIF = docente.UsuarioModificacion;
                doc.ID_CARGO = docente.Id_Cargo;
                doc.N_MODALIDAD = docente.N_Modalidad;
                doc.REPROCA = docente.Reproca;
                doc.PROVINCIA = docente.Provincia;
                doc.LOCALIDAD = docente.Localidad;
                doc.BARRIO = docente.Barrio;
                doc.CALLE = docente.Calle;
                doc.NRO = docente.Nro;
                doc.NRO_RESOLUCION = docente.Nro_Resolucion;
                doc.ID_TIPO_DOCENTE = docente.id_tipo_docente;
                doc.ROSOL_REPROCA = docente.Resolucion_Reproca;

                doc.CUIT_CUIL = docente.Cuit_Cuil;
                doc.DNI = docente.Dni;
                doc.RAZON_SOCIAL = docente.RazonSoial;
                doc.FEC_NACIMIENTO = docente.FechaNacimiento;
                doc.TELEFONO = docente.Telefono;

                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(int id_docente, string nroresolucion)
        {
            try
            {
                IComunDatos datos = new ComunDatos();

                base.AgregarDatosEliminacion(datos);

                var doc = mDb.T_DOCENTES.FirstOrDefault(c => c.ID_DOCENTE == id_docente);
                doc.ESTADO = datos.Estado;
                doc.FEC_MODIF = datos.FechaModificacion;
                doc.USR_MODIF = datos.UsuarioModificacion;
                doc.NRO_RESOLUCION = nroresolucion;

                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IDocentes> GetDocentesNotInGrupo(int id_grupo)
        {
            try
            {
                var ListRetorno = (from c in mDb.T_DOCENTES
                                   where
                                       c.ESTADO == "A" &&
                                       !(from d in mDb.T_DOCENTES_GRUPO
                                         where d.ESTADO == "A" && d.ID_GRUPO == id_grupo
                                         select d.ID_DOCENTE).Contains(c.ID_DOCENTE)
                                   select
                                       new Docentes
                                           {
                                               Id_Cargo = c.ID_CARGO,
                                               N_Modalidad = c.N_MODALIDAD,
                                               Estado = c.ESTADO,
                                               FechaAlta = c.FEC_ALTA,
                                               FechaModificacion = c.FEC_MODIF,
                                               UsuarioAlta = c.USR_ALTA,
                                               UsuarioModificacion = c.USR_MODIF,
                                               Id_Docente = c.ID_DOCENTE,
                                               RazonSoial = c.RAZON_SOCIAL,
                                               Cuit_Cuil = c.CUIT_CUIL,
                                               Reproca = c.REPROCA,
                                               Nro_Resolucion = c.NRO_RESOLUCION,
                                               Provincia = c.PROVINCIA,
                                               Barrio = c.BARRIO,
                                               Localidad = c.LOCALIDAD,
                                               Nro = c.NRO ?? 0,
                                               Calle = c.CALLE,
                                               id_tipo_docente = c.ID_TIPO_DOCENTE,
                                               NombreTipoDocente = c.T_TIPOS_DOCENTE.N_TIPO_DOCENTE
                                           }).ToList().Cast<IDocentes>().ToList();


                return ListRetorno;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IDocentes> GetDocentesInGrupo(int id_grupo)
        {
            try
            {
                var ListRetorno = (from c in mDb.T_DOCENTES
                                   where
                                       c.ESTADO == "A" &&
                                       (from d in mDb.T_DOCENTES_GRUPO
                                        where d.ESTADO == "A" && d.ID_GRUPO == id_grupo
                                        select d.ID_DOCENTE).Contains(c.ID_DOCENTE)
                                   select
                                       new Docentes
                                           {
                                               Id_Cargo = c.ID_CARGO,
                                               N_Modalidad = c.N_MODALIDAD,
                                               Estado = c.ESTADO,
                                               FechaAlta = c.FEC_ALTA,
                                               FechaModificacion = c.FEC_MODIF,
                                               UsuarioAlta = c.USR_ALTA,
                                               UsuarioModificacion = c.USR_MODIF,
                                               Id_Docente = c.ID_DOCENTE,
                                               RazonSoial = c.RAZON_SOCIAL,
                                               Cuit_Cuil = c.CUIT_CUIL,
                                               Reproca = c.REPROCA,
                                               Nro_Resolucion = c.NRO_RESOLUCION,
                                               Provincia = c.PROVINCIA,
                                               Barrio = c.BARRIO,
                                               Localidad = c.LOCALIDAD,
                                               Nro = c.NRO ?? 0,
                                               Calle = c.CALLE,
                                               id_tipo_docente = c.ID_TIPO_DOCENTE,
                                               NombreTipoDocente = c.T_TIPOS_DOCENTE.N_TIPO_DOCENTE
                                           }).ToList().Cast<IDocentes>().ToList();


                return ListRetorno;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool AsignarDocentes(int id_docente, int id_grupo, int id_condicion_curso)
        {
            try
            {

                IComunDatos datos = new ComunDatos();

                base.AgregarDatosAlta(datos);


                T_DOCENTES_GRUPO t_docentes_grupo = new T_DOCENTES_GRUPO()
                                                        {
                                                            ID_DOCENTE = id_docente,
                                                            ID_GRUPO = id_grupo,
                                                            ID_CONDICION_CURSO = id_condicion_curso,
                                                            ESTADO = datos.Estado,
                                                            USR_ALTA = datos.UsuarioAlta,
                                                            USR_MODIF = datos.UsuarioModificacion,
                                                            FEC_ALTA = datos.FechaAlta,
                                                            FEC_MODIF = datos.FechaModificacion
                                                        };



                mDb.AddToT_DOCENTES_GRUPO(t_docentes_grupo);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DesasignarDocentes(int id_docente, int id_grupo, int id_condicion_curso)
        {
            try
            {
                IComunDatos datos = new ComunDatos();

                base.AgregarDatosEliminacion(datos);

                var doc = mDb.T_DOCENTES_GRUPO.FirstOrDefault(c => c.ID_DOCENTE == id_docente && c.ID_GRUPO == id_grupo && c.ID_CONDICION_CURSO == id_condicion_curso);
                doc.ESTADO = datos.Estado;
                doc.FEC_MODIF = datos.FechaModificacion;
                doc.USR_MODIF = datos.UsuarioModificacion;
                mDb.T_DOCENTES_GRUPO.DeleteObject(doc);
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<IDocentes> BuscarDocente(string razonsocial, string cuit_cuil)
        {
            try
            {

                razonsocial = razonsocial == "" ? null : razonsocial;
                cuit_cuil = cuit_cuil == "" ? null : cuit_cuil;

                IList<IDocentes> ListaReturn = null;

                if (!string.IsNullOrEmpty(razonsocial))
                {
                    ListaReturn = QDocentes().Where(
                        c =>
                        c.RazonSoial.ToLower().StartsWith(razonsocial)).
                        ToList();
                    if (!string.IsNullOrEmpty(cuit_cuil))
                    {
                        ListaReturn = ListaReturn.Where(c => c.Cuit_Cuil.ToLower().StartsWith(cuit_cuil.ToLower())).ToList();
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(cuit_cuil))
                    {
                        ListaReturn = QDocentes().Where(c => c.Cuit_Cuil.ToLower().StartsWith(cuit_cuil.ToLower())).ToList();
                    }
                    else
                    {
                        ListaReturn = QDocentes().ToList();
                    }
                }

                return ListaReturn;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
