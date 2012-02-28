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

         public static List<IComboItem> GetComboParaAlumnosInInscripcionesByIdGrupo(IInscripcionRepositorio repositorio ,int idGrupo)
        {
            List<IComboItem> a = new List<IComboItem>();
             var restult = repositorio.GetAllInscripcionByGrupo(idGrupo);
            foreach (var curso in restult)
            {
                a.Add(new ComboItem()
                {
                    id = curso.Id_Alumno,
                    description = curso.Nov_Apellido + ", " +curso.Nov_Nombre
                });
            }
            return a;
        }
    }
}
