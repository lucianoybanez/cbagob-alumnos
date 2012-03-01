using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class SupervisoresServicio : ISupervisoresServicio
    {
        private ISupervisoresRepositorio supervisoresrepositorio;

        public SupervisoresServicio()
        {
            supervisoresrepositorio = new SupervisoresRepositorio();
        }

        public ISupervisoresVista GetSupervisores()
        {
            try
            {
                ISupervisoresVista supervisoresvista = new SupervisoresVista();
                supervisoresvista.ListaSupervisores = supervisoresrepositorio.GetSupervisores();

                return supervisoresvista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ISupervisoresVista GetSupervisoresByRazonSocial(string razonsocial)
        {
            try
            {
                ISupervisoresVista supervisoresvista = new SupervisoresVista();
                supervisoresvista.ListaSupervisores = supervisoresrepositorio.GetSupervisoresByRazonSocial(razonsocial);

                return supervisoresvista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ISupervisorVista GetSupervisor(int idsupervisor)
        {
            try
            {
                ISupervisorVista supervisorvista = new SupervisorVista();
                ISupervisores supervisores = supervisoresrepositorio.GetSupervisor(idsupervisor);

                supervisorvista.Id_Domicilio = supervisores.Id_Domicilio;
                supervisorvista.Id_PersonaJuridica = supervisores.Id_PersonaJuridica;
                supervisorvista.Id_Supervisor = supervisores.Id_Supervisor;
                supervisorvista.DatosCompletoPersonajur = supervisores.DatosCompletoPersonajur;
                supervisorvista.DomicilioCompleto = supervisores.DomicilioCompleto;

                return supervisorvista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarSupervisor(ISupervisorVista supervisor)
        {
            try
            {
                ISupervisores supervisores = new Supervisores();

                supervisores.Id_Domicilio = supervisor.Id_Domicilio;
                supervisores.Id_PersonaJuridica = supervisor.Id_PersonaJuridica;

                return supervisoresrepositorio.AgregarSupervisor(supervisores);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarSupervisor(ISupervisorVista supervisor)
        {
            try
            {
                ISupervisores supervisores = new Supervisores();

                supervisores.Id_Domicilio = supervisor.Id_Domicilio;
                supervisores.Id_PersonaJuridica = supervisor.Id_PersonaJuridica;
                supervisores.Id_Supervisor = supervisor.Id_Supervisor;


                return supervisoresrepositorio.ModificarSupervisor(supervisores);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarSupervisor(int idsupervisor)
        {
            try
            {
                return supervisoresrepositorio.EliminarSupervisor(idsupervisor);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
