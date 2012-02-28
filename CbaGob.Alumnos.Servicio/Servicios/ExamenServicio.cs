using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class ExamenServicio :BaseServicio, IExamenServicio
    {
        private IExamenRepositorio ExamenRepositorio;

        private ICursosRepositorio CursosRepositorio;

        private IGrupoRepositorio GrupoRepositorio;

        private IInscripcionRepositorio InscripcionRepositorio;


        public ExamenServicio(IExamenRepositorio examenRepositorio, ICursosRepositorio cursosRepositorio, IGrupoRepositorio grupoRepositorio, IInscripcionRepositorio inscripcionRepositorio)
        {
            ExamenRepositorio = examenRepositorio;
            CursosRepositorio = cursosRepositorio;
            GrupoRepositorio = grupoRepositorio;
            InscripcionRepositorio = inscripcionRepositorio;
        }

        public IExamenVista GetExamenVista()
        {
            IExamenVista vista = new ExamenVista();
            vista.Accion = "Alta";
            vista.Grupos.Combo = ComboHelper.GetComboParaGrupos(GrupoRepositorio);

            var primerGrupo = vista.Grupos.Combo.FirstOrDefault();
            if (primerGrupo != null)
            {
                vista.Grupos.Selected = primerGrupo.id.ToString();
                vista.Alumnos.Combo = ComboHelper.GetComboParaAlumnosInInscripcionesByIdGrupo(InscripcionRepositorio, int.Parse(vista.Grupos.Selected));
            }

            return vista;
        }

        public IExamenVista GetExamenVista(int IdExamen)
        {
            IExamenVista vista = new ExamenVista();
            vista.Accion = "Modificacion";

            var examen = ExamenRepositorio.GetExamen(IdExamen);
            vista.FechaExamen = examen.FechaExamen;
            vista.IdExamen = examen.IdExamen;
            vista.Nota = examen.Nota;
            vista.NroExamen = examen.NroExamen;
            vista.Grupos.Combo = ComboHelper.GetComboParaGrupos(GrupoRepositorio);
            vista.Grupos.Selected = examen.IdGrupo.ToString();
            vista.Alumnos.Combo = ComboHelper.GetComboParaAlumnosInInscripcionesByIdGrupo(InscripcionRepositorio, examen.IdGrupo);
            return vista;
        }

        public IExamenVista GetExamenVistaCambioComboGrupo(IExamenVista vista)
        {
            vista.Grupos.Combo = ComboHelper.GetComboParaGrupos(GrupoRepositorio);
            vista.Alumnos.Combo = ComboHelper.GetComboParaAlumnosInInscripcionesByIdGrupo(InscripcionRepositorio, int.Parse(vista.Grupos.Selected));
            return vista;
        }

        public IExamenesVista GetExamanes()
        {
            IExamenesVista vista = new ExamenesVista();
            vista.Examens = ExamenRepositorio.GetExamenes();
            return vista;
        }

        public bool GuardarExamen(IExamenVista vista)
        {

            if (!string.IsNullOrEmpty(vista.Grupos.Selected))
            {
                if (!string.IsNullOrEmpty(vista.Alumnos.Selected))
                {
                    var IdInscripcion = InscripcionRepositorio.GetInscripcionIdByAlumnoGrupo(int.Parse(vista.Grupos.Selected), int.Parse(vista.Alumnos.Selected));
                    IExamen examen = new Examen()
                    {
                        IdInscripcion = IdInscripcion,
                        NroExamen = vista.NroExamen,
                        Nota = vista.Nota,
                        FechaExamen = vista.FechaExamen,
                        IdExamen = vista.IdExamen
                    };
                    bool result = false;
                    if (vista.Accion == "Alta")
                    {
                        result =  ExamenRepositorio.AgregarExamen(examen);
                    }
                    if (vista.Accion == "Modificacion")
                    {
                        result = ExamenRepositorio.ModificarExamen(examen);
                    }
                    if (!result)
                    {
                        base.AddError("Se produjo un error al guardar el examen");
                    }
                    return result;
                }
                base.AddError("Debe Seleccionar un Alumno");
                return false;
            }
            base.AddError("Debe Seleccionar un Grupo");
            return false;
        }

        public bool EliminarExamen(int IdExamen)
        {
            if (!ExamenRepositorio.EliminarExamen(IdExamen))
            {
                base.AddError("Ocurrio un error no se pudo eliminar el examen.");
                return false;
            }
            return true;
        }

        public IList<IErrores> GetErrors()
        {
           return base.Errors;
        }
    }
}