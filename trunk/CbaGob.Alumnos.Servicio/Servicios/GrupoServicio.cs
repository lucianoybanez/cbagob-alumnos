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
        private IDocentesRepositorio docentesrepositorio;
        private IDomiciliosRepositorio domiciliosrepositorio;

        public GrupoServicio()
        {
            gruporepositorio = new GrupoRepositorio();
            docentesrepositorio = new DocentesRepositorio();
            domiciliosrepositorio = new DomiciliosRepositorio();
        }

        public IList<IErrores> GetErrors()
        {
            throw new NotImplementedException();
        }

        public IGrupoVista GetGrupo(int id_grupo)
        {
            try
            {
                IGrupoVista grupovista = new GrupoVista();

                IGrupo grupo = new Grupo();

                grupo = gruporepositorio.GetGrupo(id_grupo);

                IDocentes docente = new Docentes();

                docente = docentesrepositorio.GetUno(grupo.Id_Docente);

                grupovista.Cuit = docente.Cuit;
                grupovista.RazonSoial = docente.Razon_Social;

                IDomicilios domicilio = new Domicilios();

                domicilio = domiciliosrepositorio.GetUno(grupo.Id_Domicilio);

                grupovista.Id_Domicilio = grupo.Id_Domicilio;
                grupovista.Provincia = domicilio.Provincia;
                grupovista.Localidad = domicilio.Localidad;
                grupovista.Barrio = domicilio.Barrio;
                grupovista.Calle = domicilio.Calle;
                grupovista.Nro = domicilio.Nro;

                grupovista.Id_Condicion_Curso = grupo.Id_Condicion_Curso;
                grupovista.Id_Docente = grupo.Id_Docente;
                grupovista.Id_Establecimiento = grupo.Id_Establecimiento;
                grupovista.Id_Grupo = grupo.Id_Grupo;
                grupovista.Id_Horario = grupo.Id_Horario;
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

                return grupovista;

            }
            catch (Exception)
            {
                
                throw;
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
            throw new NotImplementedException();
        }

        public bool AgregarGrupo(IGrupoVista grupo)
        {
            IGrupo grupoadd = new Grupo();

            grupoadd.Id_Condicion_Curso = grupo.Id_Condicion_Curso;
            grupoadd.Id_Docente = grupo.Id_Docente;
            grupoadd.Id_Establecimiento = grupo.Id_Establecimiento;
            grupoadd.Id_Horario = grupo.Id_Horario;
            grupoadd.NombreGrupo = grupo.NombreGrupo;

            return gruporepositorio.AgregarGrupo(grupoadd);

        }

        public bool ModificarGrupo(IGrupoVista grupo)
        {
            throw new NotImplementedException();
        }

        public bool EliminarGrupo(int id_grupo)
        {
            throw new NotImplementedException();
        }
    }
}
