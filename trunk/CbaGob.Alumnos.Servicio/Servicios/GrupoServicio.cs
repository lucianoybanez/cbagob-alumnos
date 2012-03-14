using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class GrupoServicio : BaseServicio, IGrupoServicio
    {
        private IGrupoRepositorio gruporepositorio;
  
        private IHorarioRepositorio horariorepositorio;

        public GrupoServicio(IGrupoRepositorio gruporepositorio, IHorarioRepositorio horariorepositorio)
        {
            this.gruporepositorio = gruporepositorio;
            this.horariorepositorio = horariorepositorio;
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }

        public IGrupoVista GetGrupo(int id_grupo)
        {
            try
            {
                IGrupoVista grupovista = new GrupoVista();

                IGrupo grupo = new Grupo();

                grupo = gruporepositorio.GetGrupo(id_grupo);

                grupovista.Id_Domicilio = grupo.Id_Domicilio;
                grupovista.Provincia = grupo.Provincia;
                grupovista.Localidad = grupo.Localidad;
                grupovista.Barrio = grupo.Barrio;
                grupovista.Calle = grupo.Calle;
                grupovista.Nro = grupo.Nro;
                grupovista.Id_Condicion_Curso = grupo.Id_Condicion_Curso;
                grupovista.Id_Docente = grupo.Id_Docente;
                grupovista.Id_Establecimiento = grupo.Id_Establecimiento;
                grupovista.Id_Grupo = grupo.Id_Grupo;
                grupovista.Capacidad = grupo.Capacidad;
                grupovista.NombreEstablecimiento = grupo.NombreEstablecimiento;
                grupovista.Hr_Inicio = grupo.Hr_Inicio;
                grupovista.Hr_Año = grupo.Hr_Año;
                grupovista.Hr_DiaSemana = grupo.Hr_DiaSemana;
                grupovista.Hr_Fin = grupo.Hr_Fin;
                grupovista.Hr_Mes = grupo.Hr_Mes;
                grupovista.Id_Domicilio = grupo.Id_Domicilio;
                grupovista.Id_PersonaJuridica = grupo.Id_PersonaJuridica;
                grupovista.NombreGrupo = grupo.NombreGrupo;
                grupovista.Nombre_Institucion = grupo.Nombre_Institucion;
                grupovista.Nombre_Curso = grupo.Nombre_Curso;
                grupovista.Id_Institucion = grupo.Id_Institucion;
                grupovista.Nro_Resolucion = grupo.Nro_Resolucion;

                grupovista.HorariosAsignadoGrupo.ListaHorario = horariorepositorio.GetHorariosByGrupo(grupo.Id_Grupo);
                grupovista.HorariosParaGrupo.ListaHorario = horariorepositorio.GetHorariosForGrupo(grupo.Id_Grupo);

                return grupovista;

            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return null;
            }
        }

        public IGruposVista GetAllGrupo()
        {
            IGruposVista gruposvista = new GruposVista();

            gruposvista.ListaGrupos = gruporepositorio.GetAllGrupo();

            return gruposvista;

        }

        public IGruposVista GetAllGrupoByCurso(int id_condicioncurso)
        {
            try
            {
                IGruposVista gruposvista = new GruposVista();

                gruposvista.ListaGrupos = gruporepositorio.GetAllGrupoByCurso(id_condicioncurso);

                return gruposvista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarGrupo(IGrupoVista grupo)
        {

            try
            {
                IGrupo grupoadd = new Grupo();

                grupoadd.Id_Condicion_Curso = grupo.Id_Condicion_Curso;
                grupoadd.Id_Docente = grupo.Id_Docente;
                grupoadd.Id_Establecimiento = grupo.Id_Establecimiento;
                grupoadd.NombreGrupo = grupo.NombreGrupo;
                grupoadd.Capacidad = grupo.Capacidad;
                grupoadd.Nro_Resolucion = grupo.Nro_Resolucion;

                return gruporepositorio.AgregarGrupo(grupoadd);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }


        }

        public bool ModificarGrupo(IGrupoVista grupo)
        {
            try
            {
                IGrupo grupoadd = new Grupo();

                grupoadd.Id_Condicion_Curso = grupo.Id_Condicion_Curso;
                grupoadd.Id_Docente = grupo.Id_Docente;
                grupoadd.Id_Establecimiento = grupo.Id_Establecimiento;
                grupoadd.NombreGrupo = grupo.NombreGrupo;
                grupoadd.Capacidad = grupo.Capacidad;
                grupoadd.Id_Grupo = grupo.Id_Grupo;
                grupoadd.Nro_Resolucion = grupo.Nro_Resolucion;

                return gruporepositorio.ModificarGrupo(grupoadd);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }



        }

        public bool EliminarGrupo(int id_grupo, string nro_resolucion)
        {
            try
            {
                return gruporepositorio.EliminarGrupo(id_grupo, nro_resolucion);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }
    }
}
