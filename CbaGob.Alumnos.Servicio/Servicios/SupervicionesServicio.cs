﻿using System;
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
    public class SupervicionesServicio : BaseServicio, ISupervicionesServicio
    {
        private ISupervicionesRepositorio supervicionesrepositorio;


        public SupervicionesServicio()
        {
            supervicionesrepositorio = new SupervicionesRepositorio();
        }

        public ISupervicionesVista GetSuperviciones()
        {
            try
            {
                ISupervicionesVista supervicionesvista = new SupervicionesVista();
                supervicionesvista.ListaSuperviciones = supervicionesrepositorio.GetSuperviciones();

                return supervicionesvista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ISupervicionVista GetSupervicion(int idsupervision)
        {
            try
            {
                ISupervicionVista supervicionvista = new SupervicionVista();
                IInstitucionServicio institucionservicio = new InstitucionServicio();

                ISuperviciones superviciones = supervicionesrepositorio.GetSupervicion(idsupervision);

                supervicionvista.Fec_Supervision = superviciones.Fec_Supervision;
                supervicionvista.Hs_Supervision = superviciones.Hs_Supervision;
                supervicionvista.Id_Grupo = superviciones.Id_Grupo;
                supervicionvista.Id_Supervision = superviciones.Id_Supervision;
                supervicionvista.NombreCurso = superviciones.NombreCurso;
                supervicionvista.NombreGrupo = superviciones.NombreGrupo;
                supervicionvista.NombreInstitucion = superviciones.NombreInstitucion;
                supervicionvista.NombrePersonaJuridica = superviciones.NombrePersonaJuridica;
                supervicionvista.Id_Supervisor = superviciones.Id_Supervisor;
                supervicionvista.Observaciones = superviciones.Observaciones;
                //supervicionvista.Institucions.ListaInstituciones = institucionservicio.GetTodas();


                return supervicionvista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool AgregarSuperviciones(ISupervicionVista supervicionvista)
        {
            try
            {
                ISuperviciones superviciones = new Superviciones();
                superviciones.Fec_Supervision = supervicionvista.Fec_Supervision;
                superviciones.Hs_Supervision = supervicionvista.Hs_Supervision;
                superviciones.Observaciones = supervicionvista.Observaciones;
                superviciones.Id_Grupo = supervicionvista.Id_Grupo;
                superviciones.Id_Supervisor = supervicionvista.Id_Supervisor;

                return supervicionesrepositorio.AgregarSuperviciones(superviciones);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool ModificarSuperviciones(ISupervicionVista supervicionvista)
        {
            try
            {
                ISuperviciones superviciones = new Superviciones();
                superviciones.Fec_Supervision = supervicionvista.Fec_Supervision;
                superviciones.Hs_Supervision = supervicionvista.Hs_Supervision;
                superviciones.Observaciones = supervicionvista.Observaciones;
                superviciones.Id_Grupo = supervicionvista.Id_Grupo;
                superviciones.Id_Supervisor = supervicionvista.Id_Supervisor;
                superviciones.Id_Supervision = supervicionvista.Id_Supervision;

                return supervicionesrepositorio.ModificarSuperviciones(superviciones);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool EliminarSuperviciones(int idsupervicion, string nro_resolucion)
        {
            try
            {

                return supervicionesrepositorio.EliminarSuperviciones(idsupervicion, nro_resolucion);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}
