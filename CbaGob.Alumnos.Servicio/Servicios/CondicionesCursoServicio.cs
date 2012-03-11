using System;
using System.Collections.Generic;
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
    public class CondicionesCursoServicio : BaseServicio, ICondicionesCursoServicio
    {
        private ICondicionCursoRepositorio CondicionCursoRepositorio;

        private ICursosRepositorio CursosRepositorio;

        private IModalidadRepositorio ModalidadRepositorio;

        private INivelRepositorio NivelRepositorio;

        private IProgramaRepositorio ProgramaRepositorio;

        private IInstitucionRepositorio InstitucionRepositorio;

        private IEstadoCursoRepositorio EstadoCursoRepositorio;


        public CondicionesCursoServicio(ICondicionCursoRepositorio condicionCursoRepositorio, ICursosRepositorio cursosRepositorio, IModalidadRepositorio modalidadRepositorio, INivelRepositorio nivelRepositorio, IProgramaRepositorio programaRepositorio, IInstitucionRepositorio institucionRepositorio, IEstadoCursoRepositorio estadoCursoRepositorio)
        {
            CondicionCursoRepositorio = condicionCursoRepositorio;
            CursosRepositorio = cursosRepositorio;
            ModalidadRepositorio = modalidadRepositorio;
            NivelRepositorio = nivelRepositorio;
            ProgramaRepositorio = programaRepositorio;
            InstitucionRepositorio = institucionRepositorio;
            EstadoCursoRepositorio = estadoCursoRepositorio;
        }

        public ICondicionesCursoVista GetByInstitucionId(int IdInstitucion)
        {
            ICondicionesCursoVista vista = new CondicionesCursoVista();
            var result = CondicionCursoRepositorio.GetCondicionesByInstitucion(IdInstitucion);
            vista.CondicionesCursos = result;
            vista.IdInstitucion = IdInstitucion;
            return vista;
        }

        public ICondicionCursoVista GetForModificacion(int IdCondicionCurso)
        {
            var result = CondicionCursoRepositorio.GetCondicion(IdCondicionCurso);
            var niveles = NivelRepositorio.GetNiveles();
            var modalidades = ModalidadRepositorio.GetModalidades();
            var programas = ProgramaRepositorio.GetProgramas();
            var cursos = CursosRepositorio.GetTodos();
            var estadoCurso = EstadoCursoRepositorio.GetEstadosCursos();

            ICondicionCursoVista vista = new CondicionCursoVista();
            vista.IdInstitucion = result.IdInstitucion;
            vista.CantidadClases = result.CantidadClases;
            vista.CantidadExamenes = result.CantidadExamenes;
            vista.CargaHoraria = result.CargaHoraria;
            vista.Cupo = result.Cupo;
            vista.NombeInstitucion = result.NombeInstitucion;
            vista.Presentismo = result.Presentismo;
            vista.Presupuesto = result.Presupuesto;
            vista.PromedioRequerido = result.PromedioRequerido;
            ConvertEstadoCurso(vista, estadoCurso);
            vista.EstadoCurso.Selected = result.IdEstadoCurso.ToString();
            ConvertModalidades(vista, modalidades);
            vista.Modalidad.Selected = result.IdModalidad.ToString();
            ConvertNiveles(vista, niveles);
            vista.Nivel.Selected = result.IdNivel.ToString();
            ConvertProgramas(vista, programas);
            vista.Programa.Selected = result.IdPrograma.ToString();
            ConvertCursos(vista, cursos);
            vista.Curso.Selected = result.IdCurso.ToString();
            vista.Fecha_Fin = result.Fecha_Fin;
            vista.Fecha_Inicio = result.Fecha_Inicio;

            vista.NombreCurso = result.NombreCurso;
            vista.NombreModalidad = result.NombreModalidad;
            vista.NombreNivel = result.NombreNivel;
            vista.NombrePrograma = result.NombrePrograma;
            vista.Nro_Resolucion = result.Nro_Resolucion;

            vista.Accion = "Modificacion";
            return vista;
        }

        private static void ConvertEstadoCurso(ICondicionCursoVista vista, IList<IEstadoCurso> estadoCurso)
        {
            foreach (var est in estadoCurso)
            {
                vista.EstadoCurso.Combo.Add(new ComboItem()
                                                {
                                                    id = est.IdEstadoCurso,
                                                    description = est.NombreEstadoCurso
                                                });
            }
        }

        private static void ConvertCursos(ICondicionCursoVista vista, IList<ICursos> cursos)
        {
            foreach (var cur in cursos)
            {
                vista.Curso.Combo.Add(new ComboItem()
                                          {
                                              id = cur.ID_CURSO,
                                              description = cur.N_CURSO
                                          });
            }
        }

        private static void ConvertProgramas(ICondicionCursoVista vista, IList<IPrograma> programas)
        {
            foreach (var prog in programas)
            {
                vista.Programa.Combo.Add(new ComboItem()
                                             {
                                                 id = prog.IdPrograma,
                                                 description = prog.NombrePrograma
                                             });
            }
        }

        private static void ConvertNiveles(ICondicionCursoVista vista, IList<INivel> niveles)
        {
            foreach (var niv in niveles)
            {
                vista.Nivel.Combo.Add(new ComboItem()
                                          {
                                              id = niv.IdNivel,
                                              description = niv.NombreNivel
                                          });
            }
        }

        private static void ConvertModalidades(ICondicionCursoVista vista, IList<IModalidad> modalidades)
        {
            foreach (var mod in modalidades)
            {
                vista.Modalidad.Combo.Add(new ComboItem()
                                              {
                                                  id = mod.IdModalidad,
                                                  description = mod.NombreModalidad
                                              });
            }
        }

        public  ICondicionCursoVista GetForAlta(int IdInstitucion)
        {
            var result = InstitucionRepositorio.GetInstitucion(IdInstitucion);
            var niveles = NivelRepositorio.GetNiveles();
            var modalidades = ModalidadRepositorio.GetModalidades();
            var programas = ProgramaRepositorio.GetProgramas();
            var cursos = CursosRepositorio.GetTodos();
            var estadoCurso = EstadoCursoRepositorio.GetEstadosCursos();

            ICondicionCursoVista vista = new CondicionCursoVista();
            vista.NombeInstitucion = result.Nombre_Institucion;
            ConvertModalidades(vista, modalidades);
            ConvertNiveles(vista, niveles);
            ConvertProgramas(vista, programas);
            ConvertCursos(vista, cursos);
            ConvertEstadoCurso(vista,estadoCurso);

            vista.Accion = "Alta";

            return vista;
        }

        public bool GuardarCondicionCurso(ICondicionCursoVista condicion)
        {
            bool ret = false;
            ICondicionCurso condicionCurso = new CondicionCurso()
                                                 {
                                                     CantidadClases = condicion.CantidadClases,
                                                     CantidadExamenes = condicion.CantidadExamenes,
                                                     CargaHoraria = condicion.CargaHoraria,
                                                     Cupo = condicion.Cupo,
                                                     IdCondicionCurso = condicion.IdCondicionCurso,
                                                     IdCurso = Convert.ToInt32(condicion.Curso.Selected),
                                                     IdInstitucion = condicion.IdInstitucion,
                                                     IdModalidad = int.Parse(condicion.Modalidad.Selected),
                                                     IdNivel = 1,
                                                     IdPrograma = int.Parse(condicion.Programa.Selected),
                                                     Presentismo = condicion.Presentismo,
                                                     Presupuesto = condicion.Presupuesto,
                                                     PromedioRequerido = condicion.PromedioRequerido,
                                                     IdEstadoCurso = int.Parse(condicion.EstadoCurso.Selected),
                                                     Fecha_Inicio = condicion.Fecha_Inicio,
                                                     Fecha_Fin = condicion.Fecha_Fin,
                                                     Nro_Resolucion = condicion.Nro_Resolucion
                                                 };

            if(condicion.Accion=="Alta")
            {
                ret =  CondicionCursoRepositorio.AgregarCondicion(condicionCurso);
            }
            else if(condicion.Accion=="Modificacion")
            {
                ret =  CondicionCursoRepositorio.ModificarCondicion(condicionCurso);
            }
            if (!ret)
            {
                AddError("Ocurrio un error al Guardar la asignacion de un curso a una institucion.");
            }
            return ret;
        }

        public bool EliminarCondicionCurso(int IdCondicionCurso, string nroresolucion)
        {
            if (CondicionCursoRepositorio.EliminarCondicion(IdCondicionCurso, nroresolucion))
            {
                return true;
            }
            AddError("Ocurrio un error al eliminar la asignacion de un curso a una institucion.");
            return false;
        }

        public bool CambiarEstadoCurso(int IdCondicion, int NuevoEstado)
        {
            return CondicionCursoRepositorio.CambiarEstadoCurso(IdCondicion, NuevoEstado);
        }

        public ICondicionesCursoVista BuscarCondiciones(string institucion, string nivel, string curso,string programa, string año)
        {
            var vista = new CondicionesCursoVista();
            int añoValor = 0;
            try
            {
                añoValor = int.Parse(año);
                if (añoValor<1900||añoValor>3000)
                {
                    throw new Exception();
                }
            }
            catch 
            {
            }
            vista.CondicionesCursos = CondicionCursoRepositorio.BuscarCondiciones(institucion, nivel, curso,añoValor,programa);
           
            return vista;
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}