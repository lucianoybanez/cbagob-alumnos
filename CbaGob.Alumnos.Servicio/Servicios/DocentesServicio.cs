using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class DocentesServicio : IDocentesServicio
    {
        private IDocentesRepositorio docentesrepositorio;


        public DocentesServicio()
        {
            docentesrepositorio = new DocentesRepositorio();
        }

        public IList<IDocentes> GetTodos()
        {
            try
            {
                return docentesrepositorio.GetTodos();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public IList<IDocentes> GetTodosByRazonSocial(string razonsocial)
        {
            try
            {
                return docentesrepositorio.GetTodosByRazonSocial(razonsocial);
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
                return docentesrepositorio.GetUno(id_docente);
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
                return docentesrepositorio.Agregar(docente);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Modificar(IDocentes docente)
        {
            try
            {
                return docentesrepositorio.Modificar(docente);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Eliminar(int id_docente)
        {
            try
            {
                return docentesrepositorio.Eliminar(id_docente);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public IList<IDocentes> GetDocentesNotInGrupo(int id_grupo)
        {
            try
            {
                return docentesrepositorio.GetDocentesNotInGrupo(id_grupo);
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
                return docentesrepositorio.GetDocentesInGrupo(id_grupo);
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
                return docentesrepositorio.AsignarDocentes(id_docente, id_grupo, id_condicion_curso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DesasignarDocentes(int id_docente, int id_grupo, int id_condicion_curso)
        {
            try
            {
                return docentesrepositorio.DesasignarDocentes(id_docente, id_grupo, id_condicion_curso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
