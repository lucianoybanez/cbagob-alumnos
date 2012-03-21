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
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class EquipoServicio : BaseServicio, IEquipoServicio
    {
        private IEquipoRepositorio equiporepositorio;
        private IEstado_EquipoRepositorio estado_equiporepositorio;
        private IAutenticacionServicio Aut;
        private IUsuarioServicio usuarioservice;
        private string rol;
        private string nombreusuario;


        public EquipoServicio(IEquipoRepositorio equiporepositorio, IEstado_EquipoRepositorio estadoEquiporepositorio, IAutenticacionServicio aut, IUsuarioServicio usuarioservice)
        {
            this.equiporepositorio = equiporepositorio;
            estado_equiporepositorio = estadoEquiporepositorio;
            Aut = aut;
            this.usuarioservice = usuarioservice;
            Aut = aut;
            var usuario = usuarioservice.GetCookieData();
            rol = usuario.Rol;
            nombreusuario = usuario.Usuario;
        }

        public IEquiposVista GetEquipos()
        {
            try
            {
                IEquiposVista equipovista = new EquiposVista();

                int cantidadpaginas = 0;

                if (rol == "Supervisor")
                {
                    cantidadpaginas = equiporepositorio.GetEquipos().Count();
                }
                else
                {
                    cantidadpaginas =
                        equiporepositorio.GetEquipos().Where(c => c.UsuarioAlta == nombreusuario).Count();
                }

                var pager = new Pager(cantidadpaginas, Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexEquipos", Aut.GetUrl("IndexPager", "Equipamientos"));

                if (rol == "Supervisor")
                {
                    equipovista.ListaEquipos = equiporepositorio.GetEquipos(pager.Skip, pager.PageSize);
                }
                else
                {
                    equipovista.ListaEquipos =
                        equiporepositorio.GetEquipos().Where(c => c.UsuarioAlta == nombreusuario).OrderBy(
                            c => c.N_Equipos).Skip(pager.Skip).Take(pager.PageSize).ToList();
                }


                equipovista.Pager = pager;

                return equipovista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEquiposVista GetEquipos(IPager Pager)
        {
            try
            {
                IEquiposVista equipovista = new EquiposVista();

                if (rol == "Supervisor")
                {
                    equipovista.ListaEquipos = equiporepositorio.GetEquipos(Pager.Skip, Pager.PageSize);
                }
                else
                {
                    equipovista.ListaEquipos =
                        equiporepositorio.GetEquipos().Where(c => c.UsuarioAlta == nombreusuario).OrderBy(
                            c => c.N_Equipos).Skip(Pager.Skip).Take(Pager.PageSize).ToList();
                }

                equipovista.Pager = Pager;

                return equipovista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEquiposVista GetEquiposByEstado(int id_estado_equipo)
        {
            try
            {
                IEquiposVista equipovista = new EquiposVista();
                equipovista.ListaEquipos = equiporepositorio.GetEquiposByEstado(id_estado_equipo);

                return equipovista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEquipoVista GetEquipo(int id_equipo)
        {
            try
            {
                IEquipoVista equipovista = new EquipoVista();
                IEquipo equipo = equiporepositorio.GetEquipo(id_equipo);


                equipovista.Id_Equipo = equipo.Id_Equipo;
                equipovista.Id_Estado_Equipo = equipo.Id_Estado_Equipo;
                equipovista.N_Equipos = equipo.N_Equipos;
                equipovista.NombreEstadoEquipo = equipo.NombreEstadoEquipo;

                ConvertEstadoEquipo(equipovista, estado_equiporepositorio.GetEstadosEquipo());

                equipovista.EstadoEquipo.Selected = equipo.Id_Estado_Equipo.ToString();

                return equipovista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEquipoVista GetForAlta()
        {
            try
            {
                IEquipoVista equipovista = new EquipoVista();

                ConvertEstadoEquipo(equipovista, estado_equiporepositorio.GetEstadosEquipo());

                return equipovista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarEquipo(IEquipoVista equipo)
        {
            try
            {
                IEquipo addequipo = new Equipo();

                addequipo.Id_Estado_Equipo = equipo.Id_Estado_Equipo;
                addequipo.N_Equipos = equipo.N_Equipos;

                return equiporepositorio.AgregarEquipo(addequipo);

            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool ModificarEquipo(IEquipoVista equipo)
        {
            try
            {
                IEquipo addequipo = new Equipo();

                addequipo.Id_Equipo = equipo.Id_Equipo;
                addequipo.Id_Estado_Equipo = equipo.Id_Estado_Equipo;
                addequipo.N_Equipos = equipo.N_Equipos;

                return equiporepositorio.ModificarEquipo(addequipo);

            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool EliminarEquipo(int id_equipo)
        {
            try
            {
                return equiporepositorio.EliminarEquipo(id_equipo);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public IEquiposVista BusquedaEquipo(string nombreequipo)
        {
            try
            {
                IEquiposVista equipovista = new EquiposVista();

                int cantidadpaginas = 0;

                if (rol == "Supervisor")
                {
                    cantidadpaginas = equiporepositorio.BusquedaEquipo(nombreequipo).Count();
                }
                else
                {
                    cantidadpaginas =
                        equiporepositorio.BusquedaEquipo(nombreequipo).Where(c => c.UsuarioAlta == nombreusuario).Count();
                }

                var pager = new Pager(cantidadpaginas, Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexEquipos", Aut.GetUrl("IndexPager", "Equipamientos"));

                if (rol == "Supervisor")
                {
                    equipovista.ListaEquipos = equiporepositorio.BusquedaEquipo(nombreequipo, pager.Skip, pager.PageSize);
                }
                else
                {
                    equipovista.ListaEquipos =
                        equiporepositorio.BusquedaEquipo(nombreequipo).Where(c => c.UsuarioAlta == nombreusuario).
                            OrderBy(c => c.N_Equipos).Skip(pager.Skip).Take(pager.PageSize).ToList();
                }

                equipovista.Pager = pager;

                return equipovista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEquiposVista BusquedaEquipo(string nombreequipo, IPager Pager)
        {
            try
            {
                IEquiposVista equipovista = new EquiposVista();

                if (rol == "Supervisor")
                {
                    equipovista.ListaEquipos = equiporepositorio.BusquedaEquipo(nombreequipo, Pager.Skip, Pager.PageSize);
                }
                else
                {
                    equipovista.ListaEquipos =
                        equiporepositorio.BusquedaEquipo(nombreequipo).Where(c => c.UsuarioAlta == nombreusuario).
                            OrderBy(c => c.N_Equipos).Skip(Pager.Skip).Take(Pager.PageSize).ToList();
                }

                equipovista.Pager = Pager;

                return equipovista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void ConvertEstadoEquipo(IEquipoVista vista, IList<IEstado_Equipo> estadoequipo)
        {
            foreach (var est in estadoequipo)
            {
                vista.EstadoEquipo.Combo.Add(new ComboItem()
                {
                    id = est.Id_Estado_Equipo,
                    description = est.Nombre_Estado_Equipo
                });
            }
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}
