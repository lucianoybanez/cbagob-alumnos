using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Comun
{
    public static class ComboHelper
    {

        public static List<IComboItem> GetComboParaInstituciones(IInstitucionRepositorio repositorio)
        {
            List<IComboItem> a = new List<IComboItem>();
            var restult = repositorio.GetInstituciones();
            foreach (var curso in restult)
            {
                a.Add(new ComboItem()
                {
                    id = curso.Id_Institucion,
                    description = curso.Nombre_Institucion
                });
            }
            return a;
        }

        public static List<IComboItem> GetComboParaProgramas(IProgramaRepositorio repositorio)
        {
            List<IComboItem> a = new List<IComboItem>();
            var restult = repositorio.GetProgramas();
            foreach (var curso in restult)
            {
                a.Add(new ComboItem()
                {
                    id = curso.IdPrograma,
                    description = curso.NombrePrograma
                });
            }
            return a;
        }

        public static List<IComboItem> GetComboParaCursos(ICursosRepositorio repositorio)
        {
            List<IComboItem> a = new List<IComboItem>();
            var restult = repositorio.GetTodos();
            foreach (var curso in restult)
            {
                a.Add(new ComboItem()
                          {
                              id = curso.ID_CURSO,
                              description = curso.N_CURSO
                          });
            }
            return a;
        }

        public static List<IComboItem> GetComboParaEstadoCurso(IEstadoCursoRepositorio repositorio)
        {
            List<IComboItem> a = new List<IComboItem>();
            var restult = repositorio.GetEstadosCursos();
            foreach (var curso in restult)
            {
                a.Add(new ComboItem()
                {
                    id = curso.IdEstadoCurso,
                    description = curso.NombreEstadoCurso
                });
            }
            return a;
        }

        public static List<IComboItem> GetComboParaNiveles(INivelRepositorio repositorio)
        {
            List<IComboItem> a = new List<IComboItem>();
            var restult = repositorio.GetNiveles();
            foreach (var curso in restult)
            {
                a.Add(new ComboItem()
                {
                    id = curso.IdNivel,
                    description = curso.NombreNivel
                });
            }
            return a;
        }

        public static List<IComboItem> GetComboParaModalidades(IModalidadRepositorio repositorio)
        {
            List<IComboItem> a = new List<IComboItem>();
            var restult = repositorio.GetModalidades();
            foreach (var curso in restult)
            {
                a.Add(new ComboItem()
                {
                    id = curso.IdModalidad,
                    description = curso.NombreModalidad
                });
            }
            return a;
        }

        public static List<IComboItem> GetComboParaGrupos(IGrupoRepositorio repositorio)
        {
            List<IComboItem> a = new List<IComboItem>();
            var restult = repositorio.GetAllGrupo();
            foreach (var curso in restult)
            {
                a.Add(new ComboItem()
                {
                    id = curso.Id_Grupo,
                    description = curso.NombreGrupo
                });
            }
            return a;
        }

        public static List<IComboItem> GetComboParaAlumnosInInscripcionesByIdGrupo(IInscripcionRepositorio repositorio, int idGrupo)
        {
            List<IComboItem> a = new List<IComboItem>();
            var restult = repositorio.GetAllInscripcionByGrupo(idGrupo);
            foreach (var curso in restult)
            {
                a.Add(new ComboItem()
                {
                    id = curso.Id_Alumno,
                    description = curso.ApellidoAlumno + ", " + curso.ApellidoAlumno
                });
            }
            return a;
        }
    }
}
