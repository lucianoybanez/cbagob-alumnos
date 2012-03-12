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


        public HorarioServicio()
        {
            horariorepositorio = new HorarioRepositorio();
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
    }
}
