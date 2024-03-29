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
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class SupervisoresServicio : BaseServicio, ISupervisoresServicio
    {
        private ISupervisoresRepositorio supervisoresrepositorio;
        private IAutenticacionServicio Aut;
        private IUsuarioServicio usuarioservice;
        private string rol;
        private string nombreusuario;

        public SupervisoresServicio(ISupervisoresRepositorio Supervisoresrepositorio, IAutenticacionServicio aut, IUsuarioServicio usuarioservice)
        {
            supervisoresrepositorio = Supervisoresrepositorio;
            Aut = aut;
            this.usuarioservice = usuarioservice;
            var usuario = usuarioservice.GetCookieData();
            rol = usuario.Rol;
            nombreusuario = usuario.Usuario;
        }

        public ISupervisoresVista GetSupervisores()
        {
            try
            {
                ISupervisoresVista supervisoresvista = new SupervisoresVista();

                int cantidadpaginas = 0;
                if (rol == "Supervisor")
                {
                    cantidadpaginas = supervisoresrepositorio.GetCountSupervisor();
                }
                else
                {
                    cantidadpaginas =
                        supervisoresrepositorio.GetSupervisores().Where(c => c.UsuarioAlta == nombreusuario).Count();
                }

                var pager = new Pager(cantidadpaginas, Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexSupervisores", Aut.GetUrl("IndexPager", "Supervisores"));

                supervisoresvista.Pager = pager;

                if (rol == "Supervisor")
                {
                    supervisoresvista.ListaSupervisores = supervisoresrepositorio.GetSupervisores(pager.Skip, pager.PageSize);
                }
                else
                {
                    supervisoresvista.ListaSupervisores =
                        supervisoresrepositorio.GetSupervisores().Where(c => c.UsuarioAlta == nombreusuario).OrderBy(
                            c => c.Razon_Social).Skip(pager.Skip).Take(pager.PageSize).ToList();
                }



                return supervisoresvista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ISupervisoresVista GetSupervisores(IPager Pager)
        {
            try
            {
                ISupervisoresVista supervisoresvista = new SupervisoresVista();

                supervisoresvista.Pager = Pager;

                if (rol == "Supervisor")
                {
                    supervisoresvista.ListaSupervisores = supervisoresrepositorio.GetSupervisores(Pager.Skip, Pager.PageSize);
                }
                else
                {
                    supervisoresvista.ListaSupervisores =
                        supervisoresrepositorio.GetSupervisores().Where(c => c.UsuarioAlta == nombreusuario).OrderBy(
                            c => c.Razon_Social).Skip(Pager.Skip).Take(Pager.PageSize).ToList();
                }


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

                supervisorvista.Id_Supervisor = supervisores.Id_Supervisor;
                supervisorvista.DatosCompletoPersonajur = supervisores.DatosCompletoPersonajur;
                supervisorvista.DomicilioCompleto = supervisores.DomicilioCompleto;
                supervisorvista.Provincia = supervisores.Provincia;
                supervisorvista.Localidad = supervisores.Localidad;
                supervisorvista.Calle = supervisores.Calle;
                supervisorvista.Nro = supervisores.Nro;
                supervisorvista.Nro_Resolucion = supervisores.Nro_Resolucion;
                supervisorvista.Razon_Social = supervisores.Razon_Social;
                supervisorvista.Barrio = supervisores.Barrio;
                supervisorvista.Cuil_Cuit = supervisores.Cuil_Cuit;

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

                supervisores.Provincia = supervisor.Provincia;
                supervisores.Localidad = supervisor.Localidad;
                supervisores.Barrio = supervisor.Barrio;
                supervisores.Calle = supervisor.Calle;
                supervisores.Nro = supervisor.Nro;
                supervisores.Nro_Resolucion = supervisor.Nro_Resolucion;
                supervisores.Razon_Social = supervisor.Razon_Social;
                supervisores.Cuil_Cuit = supervisor.Cuil_Cuit;


                return supervisoresrepositorio.AgregarSupervisor(supervisores);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool ModificarSupervisor(ISupervisorVista supervisor)
        {
            try
            {
                ISupervisores supervisores = new Supervisores();

                supervisores.Provincia = supervisor.Provincia;
                supervisores.Localidad = supervisor.Localidad;
                supervisores.Barrio = supervisor.Barrio;
                supervisores.Calle = supervisor.Calle;
                supervisores.Nro = supervisor.Nro;
                supervisores.Nro_Resolucion = supervisor.Nro_Resolucion;
                supervisores.Razon_Social = supervisor.Razon_Social;
                supervisores.Cuil_Cuit = supervisor.Cuil_Cuit;
                supervisores.Id_Supervisor = supervisor.Id_Supervisor;


                return supervisoresrepositorio.ModificarSupervisor(supervisores);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool EliminarSupervisor(int idsupervisor, string nro_resolucion)
        {
            try
            {
                return supervisoresrepositorio.EliminarSupervisor(idsupervisor, nro_resolucion);
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
