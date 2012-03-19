using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class HorarioServicio : IHorarioServicio
    {
        private IHorarioRepositorio horariorepositorio;


        public HorarioServicio(IHorarioRepositorio Horariorepositorio)
        {
            horariorepositorio = Horariorepositorio;
        }

        public IHorariosVista GetHorarios()
        {
            try
            {
                IHorariosVista vista = new HorariosVista();
                vista.ListaHorario = horariorepositorio.GetHorarios();

                return vista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IHorariosVista GetHorariosForGrupo(int id_grupo)
        {
            try
            {
                IHorariosVista vista = new HorariosVista();
                vista.ListaHorario = horariorepositorio.GetHorariosForGrupo(id_grupo);

                return vista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IHorariosVista GetHorariosByGrupo(int id_grupo)
        {
            try
            {
                IHorariosVista vista = new HorariosVista();
                vista.ListaHorario = horariorepositorio.GetHorariosByGrupo(id_grupo);

                return vista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IHorariosVista GetHorarioByAlumno(int id_alumno, int id_cursos)
        {
            try
            {
                IHorariosVista vista = new HorariosVista();
                vista.ListaHorario = horariorepositorio.GetHorarioByAlumno(id_alumno, id_cursos);

                return vista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IHorariosVista GetHorarioByDocente(int id_docente, int id_cursos)
        {
            try
            {
                IHorariosVista vista = new HorariosVista();
                vista.ListaHorario = horariorepositorio.GetHorarioByDocente(id_docente, id_cursos);

                return vista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarHorarioAGrupo(int id_grupo, int id_horario)
        {
            try
            {
                return horariorepositorio.AgregarHorarioAGrupo(id_grupo, id_horario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SacarHorarioAGrupo(int id_grupo, int id_horario)
        {
            try
            {
                return horariorepositorio.SacarHorarioAGrupo(id_grupo, id_horario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarHorarioalAlumno(int id_alumno, int id_horario, int id_grupo)
        {
            try
            {
                return horariorepositorio.AgregarHorarioalAlumno(id_alumno, id_horario, id_grupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SacarHorarioalAlumno(int id_alumno, int id_horario, int id_grupo)
        {
            try
            {
                return horariorepositorio.SacarHorarioalAlumno(id_alumno, id_horario, id_grupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarHorarioalDocente(int id_docente, int id_horario, int id_grupo)
        {
            try
            {
                return horariorepositorio.AgregarHorarioalDocente(id_docente, id_horario, id_grupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SacarHorarioalDocente(int id_docente, int id_horario, int id_grupo)
        {
            try
            {
                return horariorepositorio.SacarHorarioalDocente(id_docente, id_horario, id_grupo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
