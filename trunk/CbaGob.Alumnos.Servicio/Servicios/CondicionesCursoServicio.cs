using System;
using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class CondicionesCursoServicio : BaseServicio, ICondicionesCursoServicio
    {
        private ICondicionCursoRepositorio CondicionCursoRepositorio;

        private ICursosRepositorio CursosRepositorio;

        private IModalidadRepositorio ModalidadRepositorio;

        private INivelRepositorio NivelRepositorio;

        private IProgramaRepositorio ProgramaRepositorio;


        public CondicionesCursoServicio(ICondicionCursoRepositorio condicionCursoRepositorio, ICursosRepositorio cursosRepositorio, IModalidadRepositorio modalidadRepositorio, INivelRepositorio nivelRepositorio, IProgramaRepositorio programaRepositorio)
        {
            CondicionCursoRepositorio = condicionCursoRepositorio;
            CursosRepositorio = cursosRepositorio;
            ModalidadRepositorio = modalidadRepositorio;
            NivelRepositorio = nivelRepositorio;
            ProgramaRepositorio = programaRepositorio;
        }

        public ICondicionesCursoVista GetByInstitucionId(int IdInstitucion)
        {
            ICondicionesCursoVista vista = new CondicionesCursoVista();
            var result = CondicionCursoRepositorio.GetCondicionesByInstitucion(IdInstitucion);
            vista.CondicionesCursos = result;
            return vista;
        }

        public ICondicionCursoVista GetById(int IdCondicionCurso)
        {
            var result = CondicionCursoRepositorio.GetCondicion(IdCondicionCurso);
            var niveles = NivelRepositorio.GetNiveles();
            var modalidades = ModalidadRepositorio.GetModalidades();
            var programas = ProgramaRepositorio.GetProgramas();
            var cursos = CursosRepositorio.GetTodos();

            ICondicionCursoVista vista = new CondicionCursoVista();
            vista.CantidadClases = result.CantidadClases;
            vista.CantidadExamenes = result.CantidadExamenes;
            vista.CargaHoraria = result.CargaHoraria;
            vista.Cupo = result.Cupo;
            vista.EstadoCurso = result.EstadoCurso;
            vista.NombeInstitucion = result.NombeInstitucion;
            vista.Presentismo = result.Presentismo;
            vista.Presupuesto = result.Presupuesto;
            vista.PromedioRequerido = result.PromedioRequerido;
            foreach(var mod in modalidades)
            {
                vista.Modalidad.Combo.Add(new ComboItem()
                                              {
                                                  id = mod.IdModalidad,
                                                  description = mod.NombreModalidad
                                              });
            }
            vista.Modalidad.Selected = result.IdModalidad.ToString();
            foreach (var niv in niveles)
            {
                vista.Nivel.Combo.Add(new ComboItem()
                {
                    id = niv.IdNivel,
                    description = niv.NombreNivel
                });
            }
            vista.Nivel.Selected = result.IdNivel.ToString();
            foreach (var prog in programas)
            {
                vista.Programa.Combo.Add(new ComboItem()
                {
                    id = prog.IdPrograma,
                    description = prog.NombrePrograma
                });
            }
            vista.Programa.Selected = result.IdPrograma.ToString();
            foreach (var cur in cursos)
            {
                vista.Curso.Combo.Add(new ComboItem()
                {
                    id = cur.ID_CURSO,
                    description = cur.N_CURSO
                });
            }
            vista.Curso.Selected = result.IdCurso.ToString();

           

            

            return vista;
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}