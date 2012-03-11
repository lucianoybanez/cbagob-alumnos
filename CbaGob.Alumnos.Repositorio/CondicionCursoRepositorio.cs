using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio.Models;

namespace CbaGob.Alumnos.Repositorio
{
    public class CondicionCursoRepositorio : BaseRepositorio, ICondicionCursoRepositorio
    {
        private CursosDB mDB;

        public CondicionCursoRepositorio()
        {
            mDB = new CursosDB();
            mDB.ContextOptions.LazyLoadingEnabled = false;
        }

        #region GET

        private IQueryable<ICondicionCurso> GetCondicion()
        {
            var a = (from p in mDB.T_CONDICIONES_CURSO
                     where p.ESTADO == "A"
                     select new CondicionCurso
                                {
                                    CantidadClases = p.CANTIDADCLASES,
                                    CantidadExamenes = p.CANTIDADEXAMENES,
                                    CargaHoraria = p.CARGAHORARIA,
                                    Cupo = p.CUPO,
                                    NombreEstadoCurso = p.T_ESTADOS_CURSO.N_ESTADO_CURSO,
                                    FechaAlta = p.FEC_ALTA,
                                    FechaModificacion = p.FEC_MODIF,
                                    IdCurso = p.ID_CURSO,
                                    IdModalidad = p.ID_MODALIDAD,
                                    IdNivel = p.ID_NIVEL,
                                    IdPrograma = p.ID_PROGRAMA,
                                    NombeInstitucion = p.T_INSTITUCIONES.N_INSTITUCION,
                                    NombreCurso = p.T_CURSOS.N_CURSO,
                                    NombreModalidad = p.T_MODALIDADES.N_MODALIDAD,
                                    NombreNivel = p.T_NIVELES.N_NIVEL,
                                    NombrePrograma = p.T_PROGRAMAS.N_PROGRAMA,
                                    Presentismo = p.PRESENTISMO,
                                    Presupuesto = p.PRESUPUESTO,
                                    PromedioRequerido = p.PROMEDIOREQUERIDO,
                                    UsuarioAlta = p.USR_ALTA,
                                    UsuarioModificacion = p.USR_MODIF,
                                    IdInstitucion = p.T_INSTITUCIONES.ID_INSTITUCION,
                                    IdCondicionCurso = p.ID_CONDICION_CURSO,
                                    IdEstadoCurso = p.T_ESTADOS_CURSO.ID_ESTADO_CURSO,
                                    Estado = p.ESTADO,
                                    Fecha_Fin = p.FEC_FIN ?? System.DateTime.Now,
                                    Fecha_Inicio = p.FEC_INICIO ?? System.DateTime.Now,
                                    Nro_Resolucion = p.NRO_RESOLUCION
                                    
                                });
            return a;
        }

        public ICondicionCurso GetCondicion(int IdCondicion)
        {
            var result = GetCondicion().Where(c => c.IdCondicionCurso == IdCondicion).FirstOrDefault();
            return result;
        }

        public IList<ICondicionCurso> GetCondicionesByInstitucion(int IdInstitucion)
        {
            var result = GetCondicion().Where(c => c.IdInstitucion == IdInstitucion).ToList();
            return result;
        }

        public IList<ICondicionCurso> GetCondicionCursoBy(int IdInstitucion, int IdCurso, int IdEstadoCurso, int IdNivel, int IdModalidad, int IdPrograma)
        {
            var result = GetCondicion().Where(c => (c.IdInstitucion == IdInstitucion || IdInstitucion == 0)
                                                    && (c.IdCurso == IdCurso || IdCurso == 0)
                                                    && (c.IdEstadoCurso == IdEstadoCurso || IdEstadoCurso == 0)
                                                    && (c.IdNivel == IdNivel || IdNivel == 0)
                                                    && (c.IdModalidad == IdModalidad || IdModalidad == 0)
                                                    && (c.IdPrograma == IdPrograma || IdPrograma == 0))
                                                    .ToList();
            return result;
        }

        public ICondicionCurso GetFirstCondicion()
        {
            return GetCondicion().FirstOrDefault();
        }

        #endregion

        #region CRUD

        public bool AgregarCondicion(ICondicionCurso condicion)
        {
            base.AgregarDatosAlta(condicion);
            try
            {
                T_CONDICIONES_CURSO condicionesCurso = new T_CONDICIONES_CURSO()
                {
                    CANTIDADCLASES = condicion.CantidadClases,
                    CANTIDADEXAMENES = condicion.CantidadExamenes,
                    CARGAHORARIA = condicion.CargaHoraria,
                    CUPO = condicion.Cupo,
                    ESTADO = condicion.Estado,
                    FEC_ALTA = condicion.FechaAlta,
                    ID_CURSO = condicion.IdCurso,
                    ID_ESTADO_CURSO = condicion.IdEstadoCurso,
                    ID_INSTITUCION = condicion.IdInstitucion,
                    ID_MODALIDAD = condicion.IdModalidad,
                    ID_NIVEL = condicion.IdNivel,
                    ID_PROGRAMA = condicion.IdPrograma,
                    PRESENTISMO = condicion.Presentismo,
                    PRESUPUESTO = condicion.Presupuesto,
                    PROMEDIOREQUERIDO = condicion.PromedioRequerido,
                    USR_ALTA = condicion.UsuarioAlta,
                    FEC_MODIF = condicion.FechaModificacion,
                    USR_MODIF = condicion.UsuarioModificacion,
                    FEC_FIN = condicion.Fecha_Fin,
                    FEC_INICIO = condicion.Fecha_Inicio,
                    NRO_RESOLUCION = condicion.Nro_Resolucion
                    
                };
                mDB.AddToT_CONDICIONES_CURSO(condicionesCurso);
                mDB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ModificarCondicion(ICondicionCurso condicion)
        {
            base.AgregarDatosModificacion(condicion);
            try
            {
                var a = mDB.T_CONDICIONES_CURSO.Where(c => c.ID_CONDICION_CURSO == condicion.IdCondicionCurso).FirstOrDefault();
                a.CANTIDADCLASES = condicion.CantidadClases;
                a.CANTIDADEXAMENES = condicion.CantidadExamenes;
                a.CARGAHORARIA = condicion.CargaHoraria;
                a.CUPO = condicion.Cupo;
                a.ID_CURSO = condicion.IdCurso;
                a.ID_ESTADO_CURSO = condicion.IdEstadoCurso;
                a.ID_INSTITUCION = condicion.IdInstitucion;
                a.ID_MODALIDAD = condicion.IdModalidad;
                a.ID_NIVEL = condicion.IdNivel;
                a.ID_PROGRAMA = condicion.IdPrograma;
                a.PRESENTISMO = condicion.Presentismo;
                a.PRESUPUESTO = condicion.Presupuesto;
                a.PROMEDIOREQUERIDO = condicion.PromedioRequerido;
                a.FEC_MODIF = condicion.FechaModificacion;
                a.USR_MODIF = condicion.UsuarioModificacion;
                a.FEC_FIN = condicion.Fecha_Fin;
                a.FEC_INICIO = condicion.Fecha_Inicio;
                a.NRO_RESOLUCION = condicion.Nro_Resolucion;
                mDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarCondicion(int IdCondicion, string nroresolucion)
        {
            IComunDatos datos = new ComunDatos();
            base.AgregarDatosEliminacion(datos);
            try
            {
                var a = mDB.T_CONDICIONES_CURSO.Where(c => c.ID_CONDICION_CURSO == IdCondicion).FirstOrDefault();
                a.NRO_RESOLUCION = nroresolucion;
                a.ESTADO = datos.Estado;
                a.FEC_MODIF = datos.FechaModificacion;
                a.USR_MODIF = datos.UsuarioModificacion;
                mDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        public bool CambiarEstadoCurso(int IdCondicion, int NuevoEstado)
        {
            IComunDatos datos = new ComunDatos();
            base.AgregarDatosEliminacion(datos);
            try
            {
                var a = mDB.T_CONDICIONES_CURSO.Where(c => c.ID_CONDICION_CURSO == IdCondicion).FirstOrDefault();
                a.ID_ESTADO_CURSO = NuevoEstado;
                a.FEC_MODIF = datos.FechaModificacion;
                a.USR_MODIF = datos.UsuarioModificacion;
                mDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<ICondicionCurso> BuscarCondiciones(string institucion, string nivel, string curso, int año,string programa)
        {
            if (!string.IsNullOrEmpty(institucion))
            {
                return GetCondicion().Where(c => (c.NombeInstitucion.ToLower().StartsWith(institucion.ToLower())) && (c.Fecha_Inicio.Year == año || año == 0)).ToList();
            }
            if (!string.IsNullOrEmpty(curso))
            {
                return GetCondicion().Where(c => (c.NombreCurso.ToLower().StartsWith(curso.ToLower()) && (c.Fecha_Inicio.Year == año || año == 0))).ToList();
            }
            if (!string.IsNullOrEmpty(programa))
            {
                return GetCondicion().Where(c => (c.NombrePrograma.ToLower().StartsWith(programa.ToLower()) && (c.Fecha_Inicio.Year == año || año == 0))).ToList();
            }
            if (año!=0)
            {
                return GetCondicion().Where(c => (c.Fecha_Inicio.Year == año)).ToList();
            }
            //return GetCondicion().Where(c => (c.NombreNivel.ToLower().Contains(nivel.ToLower()))).ToList();
            return null;
        }

      
    }
}
