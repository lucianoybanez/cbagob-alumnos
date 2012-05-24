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
    public class CargosServicio : BaseServicio, ICargosServicio
    {
        private ICargosRepositorio cargosrepositorio;

        private IAutenticacionServicio Aut;

        public CargosServicio(ICargosRepositorio pcargosrepositorio, IAutenticacionServicio aut)
        {
            cargosrepositorio = pcargosrepositorio;
            Aut = aut;
        }

        public ICargosVista GetTodosCargos()
        {
            try
            {
                ICargosVista vista = new CargosVista();
                var pager = new Pager(cargosrepositorio.GetCargosCount(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexCargos", Aut.GetUrl("IndexPager", "Cargos"));

                vista.Pager = pager;

                vista.ListaCargo = cargosrepositorio.GetTodosCargos(pager.Skip, pager.PageSize);

                return vista;
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;
            }

        }

        public ICargosVista GetTodosCargos(IPager pager)
        {
            try
            {
                ICargosVista vista = new CargosVista();

                vista.Pager = pager;

                vista.ListaCargo = cargosrepositorio.GetTodosCargos(pager.Skip, pager.PageSize);

                return vista;
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;
            }
        }

        public ICargoVista GetCargo(int idcargo)
        {
            try
            {
                ICargoVista vista = new CargoVista();

                ICargos cargo = cargosrepositorio.GetCargo(idcargo);

                vista.Id_Cargo = cargo.Id_Cargo;
                vista.N_Cargo = cargo.N_Cargo;
                vista.Nro_Resolucion = cargo.Nro_Resolucion;

                return vista;

            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;
            }
        }





        public bool AgregarCargo(ICargoVista cargo)
        {
            try
            {
                ICargos addcargo = new Cargos();

                addcargo.N_Cargo = cargo.N_Cargo;
                addcargo.Nro_Resolucion = cargo.Nro_Resolucion;

                return cargosrepositorio.AgregarCargo(addcargo);

            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return false;
            }
        }

        public bool ModificarCargo(ICargoVista cargo)
        {
            try
            {
                ICargos addcargo = new Cargos();

                addcargo.N_Cargo = cargo.N_Cargo;
                addcargo.Nro_Resolucion = cargo.Nro_Resolucion;
                addcargo.Id_Cargo = cargo.Id_Cargo;

                return cargosrepositorio.ModificarCargo(addcargo);

            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return false;
            }
        }

        public bool EliminarCargo(int id_cargo, string nro_resolucion)
        {
            try
            {

                return cargosrepositorio.EliminarCargo(id_cargo, nro_resolucion);

            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return false;
            }
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}
