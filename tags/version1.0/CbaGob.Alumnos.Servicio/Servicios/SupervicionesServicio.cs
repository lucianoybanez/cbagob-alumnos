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
    public class SupervicionesServicio : BaseServicio, ISupervicionesServicio
    {
        private ISupervicionesRepositorio supervicionesrepositorio;
        private IAutenticacionServicio Aut;
        private IUsuarioServicio usuarioservice;
        private string rol;
        private string nombreusuario;


        public SupervicionesServicio(ISupervicionesRepositorio supervicionesrepositorio, IAutenticacionServicio aut, IUsuarioServicio usuarioservice)
        {
            this.supervicionesrepositorio = supervicionesrepositorio;
            Aut = aut;
            this.usuarioservice = usuarioservice;
            var usuario = usuarioservice.GetCookieData();
            rol = usuario.Rol;
            nombreusuario = usuario.Usuario;
        }

        public ISupervicionesVista GetSuperviciones()
        {
            try
            {
                ISupervicionesVista supervicionesvista = new SupervicionesVista();

                int cantidadpaginas = 0;
                if (rol == "Supervisor")
                {
                    cantidadpaginas = supervicionesrepositorio.GetCountSuperviciones();
                }
                else
                {
                    cantidadpaginas =
                        supervicionesrepositorio.GetSuperviciones().Where(c => c.UsuarioAlta == nombreusuario).Count();
                }

                var pager = new Pager(cantidadpaginas, Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexSuperviciones", Aut.GetUrl("IndexPager", "Superviciones"));

                supervicionesvista.Pager = pager;

                if (rol == "Supervisor")
                {
                    supervicionesvista.ListaSuperviciones = supervicionesrepositorio.GetSuperviciones(pager.Skip,
                                                                                                 pager.PageSize);
                }
                else
                {
                    supervicionesvista.ListaSuperviciones =
                        supervicionesrepositorio.GetSuperviciones().Where(c => c.UsuarioAlta == nombreusuario).OrderBy(
                            c => c.Fec_Supervision).Skip(pager.Skip).Take(pager.PageSize).ToList();

                }


                return supervicionesvista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ISupervicionesVista GetSuperviciones(IPager Pager)
        {
            try
            {
                ISupervicionesVista supervicionesvista = new SupervicionesVista();

                supervicionesvista.Pager = Pager;
                if (rol == "Supervisor")
                {
                    supervicionesvista.ListaSuperviciones = supervicionesrepositorio.GetSuperviciones(Pager.Skip,
                                                                                                 Pager.PageSize);
                }
                else
                {
                    supervicionesvista.ListaSuperviciones =
                        supervicionesrepositorio.GetSuperviciones().Where(c => c.UsuarioAlta == nombreusuario).OrderBy(
                            c => c.Fec_Supervision).Skip(Pager.Skip).Take(Pager.PageSize).ToList();

                }

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
                supervicionvista.Nro_resolucion = superviciones.Nroresolucion;
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
                superviciones.Nroresolucion = supervicionvista.Nro_resolucion;

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
                superviciones.Nroresolucion = supervicionvista.Nro_resolucion;

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
