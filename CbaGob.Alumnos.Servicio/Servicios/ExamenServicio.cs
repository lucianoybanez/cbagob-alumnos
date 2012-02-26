using System;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class ExamenServicio : IExamenServicio
    {
        private IExamenRepositorio ExamenRepositorio;

        private ICursosRepositorio CursosRepositorio;


        public ExamenServicio(IExamenRepositorio examenRepositorio, ICursosRepositorio cursosRepositorio)
        {
            ExamenRepositorio = examenRepositorio;
            CursosRepositorio = cursosRepositorio;
        }

        public IExamenVista GetExamenVista()
        {
            IExamenVista a = new ExamenVista()
                                 {
                                     Accion = "Alta"
                                 };

            a.Cursos.Combo = ComboHelper.GetComboParaCursos(CursosRepositorio);
            return a;
        }

        public IExamenVista GetExamenVista(int IdExamen)
        {
            throw new NotImplementedException();
        }

        public IExamenesVista GetExamanes()
        {
            throw new NotImplementedException();
        }
    }
}