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

        public DocentesRepositorio()
        {
            mDb = new CursosDB();
        }

        public IList<IDocentes> GetTodos()
        {
            try
            {

                var ListRetorno = (from e in mDb.T_DOCENTES
                                   join t in mDb.T_PERSONASJUR on e.ID_PERSONAJURIDICA equals t.ID_PERSONAJUR
                                   where e.ESTADO == "A"
                                   select
                                       new Docentes
                                           {
                                               Id_PersonaJuridica = e.ID_PERSONAJURIDICA,
                                               Id_Cargo = e.ID_CARGO,
                                               Id_Domicilio = e.ID_DOMICILIO,
                                               N_Modalidad = e.N_MODALIDAD,
                                               Estado = e.ESTADO,
                                               FechaAlta = e.FEC_ALTA,
                                               FechaModificacion = e.FEC_MODIF,
                                               UsuarioAlta = e.USR_ALTA,
                                               UsuarioModificacion = e.USR_MODIF,
                                               Id_Docente = e.ID_DOCENTE,
                                               Razon_Social = t.RAZON_SOCIAL,
                                               Cuit = t.CUIT,
                                               Planta = e.PLANTA ?? ".",
                                               Reproca = e.REPROCA ?? "."
                                           }).ToList().Cast<IDocentes>().ToList();


                return ListRetorno;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IList<IDocentes> GetTodosByRazonSocial(string razonsocial)
        {
            throw new NotImplementedException();
        }

        public IDocentes GetUno(int id_docente)
        {
            try
            {

                var Retorno = (from e in mDb.T_DOCENTES
                               join t in mDb.T_PERSONASJUR on e.ID_PERSONAJURIDICA equals t.ID_PERSONAJUR
                               where e.ESTADO == "A" && e.ID_DOCENTE == id_docente
                               select
                                   new Docentes
                                       {
                                           Id_PersonaJuridica = e.ID_PERSONAJURIDICA,
                                           Id_Cargo = e.ID_CARGO,
                                           Id_Domicilio = e.ID_DOMICILIO,
                                           N_Modalidad = e.N_MODALIDAD,
                                           Estado = e.ESTADO,
                                           FechaAlta = e.FEC_ALTA,
                                           FechaModificacion = e.FEC_MODIF,
                                           UsuarioAlta = e.USR_ALTA,
                                           UsuarioModificacion = e.USR_MODIF,
                                           Id_Docente = e.ID_DOCENTE,
                                           Razon_Social = t.RAZON_SOCIAL,
                                           Cuit = t.CUIT,
                                           Planta = e.PLANTA ?? ".",
                                           Reproca = e.REPROCA ?? "."
                                       }).SingleOrDefault();


                return Retorno;

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
                T_DOCENTES T_Docentes = new T_DOCENTES()
                                            {
                                                ESTADO = "A",
                                                FEC_ALTA = DateTime.Now,
                                                USR_ALTA = "Test",
                                                FEC_MODIF = DateTime.Now,
                                                USR_MODIF = "Test",
                                                ID_CARGO = docente.Id_Cargo,
                                                ID_DOMICILIO = docente.Id_Domicilio,
                                                ID_PERSONAJURIDICA = docente.Id_PersonaJuridica,
                                                N_MODALIDAD = docente.N_Modalidad,
                                                PLANTA = docente.Planta,
                                                REPROCA = docente.Reproca
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
            try
            {
                var doc = mDb.T_DOCENTES.FirstOrDefault(c => c.ID_DOCENTE == docente.Id_Docente);
                doc.ID_CARGO = docente.Id_Cargo;
                doc.ID_DOMICILIO = docente.Id_Domicilio;
                doc.N_MODALIDAD = docente.N_Modalidad;
                doc.ID_PERSONAJURIDICA = docente.Id_PersonaJuridica;
                doc.FEC_MODIF = System.DateTime.Now;
                doc.USR_MODIF = "Test";
                doc.REPROCA = docente.Reproca;
                doc.PLANTA = docente.Planta;
                mDb.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(int id_docente)
        {
            try
            {
                var doc = mDb.T_DOCENTES.FirstOrDefault(c => c.ID_DOCENTE == id_docente);
                doc.ESTADO = "I";
                doc.FEC_MODIF = System.DateTime.Now;
                doc.USR_MODIF = "Test";
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
                var ListRetorno = (from e in mDb.T_DOCENTES
                                   join t in mDb.T_PERSONASJUR on e.ID_PERSONAJURIDICA equals t.ID_PERSONAJUR
                                   where
                                       e.ESTADO == "A" &&
                                       !(from d in mDb.T_DOCENTES_GRUPO
                                         where d.ESTADO == "A" && d.ID_GRUPO == id_grupo
                                         select d.ID_DOCENTE).Contains(e.ID_DOCENTE)
                                   select
                                       new Docentes
                                           {
                                               Id_PersonaJuridica = e.ID_PERSONAJURIDICA,
                                               Id_Cargo = e.ID_CARGO,
                                               Id_Domicilio = e.ID_DOMICILIO,
                                               N_Modalidad = e.N_MODALIDAD,
                                               Estado = e.ESTADO,
                                               FechaAlta = e.FEC_ALTA,
                                               FechaModificacion = e.FEC_MODIF,
                                               UsuarioAlta = e.USR_ALTA,
                                               UsuarioModificacion = e.USR_MODIF,
                                               Id_Docente = e.ID_DOCENTE,
                                               Razon_Social = t.RAZON_SOCIAL,
                                               Planta = e.PLANTA ?? ".",
                                               Reproca = e.REPROCA ?? ".",
                                               Cuit = t.CUIT
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
                var ListRetorno = (from e in mDb.T_DOCENTES
                                   join t in mDb.T_PERSONASJUR on e.ID_PERSONAJURIDICA equals t.ID_PERSONAJUR
                                   where
                                       e.ESTADO == "A" &&
                                       (from d in mDb.T_DOCENTES_GRUPO
                                        where d.ESTADO == "A" && d.ID_GRUPO == id_grupo
                                        select d.ID_DOCENTE).Contains(e.ID_DOCENTE)
                                   select
                                       new Docentes
                                       {
                                           Id_PersonaJuridica = e.ID_PERSONAJURIDICA,
                                           Id_Cargo = e.ID_CARGO,
                                           Id_Domicilio = e.ID_DOMICILIO,
                                           N_Modalidad = e.N_MODALIDAD,
                                           Estado = e.ESTADO,
                                           FechaAlta = e.FEC_ALTA,
                                           FechaModificacion = e.FEC_MODIF,
                                           UsuarioAlta = e.USR_ALTA,
                                           UsuarioModificacion = e.USR_MODIF,
                                           Id_Docente = e.ID_DOCENTE,
                                           Razon_Social = t.RAZON_SOCIAL,
                                           Planta = e.PLANTA ?? ".",
                                           Reproca = e.REPROCA ?? ".",
                                           Cuit = t.CUIT
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
    }
}
