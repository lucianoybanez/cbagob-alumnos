using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class ProgramaServicio : BaseServicio, IProgramaServicio
    {
        private IProgramaRepositorio programarepositorio;

        private IAutenticacionServicio Aut;

        public ProgramaServicio(IProgramaRepositorio programarepositorio, IAutenticacionServicio aut)
        {
            this.programarepositorio = programarepositorio;
            Aut = aut;
        }

        public IList<IErrores> GetErrors()
        {
            return Errors;
        }

        public IProgramasVista GetProgramas()
        {
            try
            {
                IProgramasVista vista = new ProgramasVista();

                var pager = new Pager(programarepositorio.GetCountPrograma(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexPrograma", Aut.GetUrl("IndexPager", "Programas"));

                vista.Pager = pager;

                vista.ListaPrograma = programarepositorio.GetProgramas(pager.Skip, pager.PageSize);

                return vista;
            }
            catch (Exception)
            {
                base.AddError("Sucedio un Error comprueb los datos");
                return null;
            }
        }

        public IProgramaVista GetPrograma(int idprograma)
        {
            try
            {
                IProgramaVista vista = new ProgramaVista();

                IPrograma mPrograma = programarepositorio.GetPrograma(idprograma);

                vista.NombrePrograma = mPrograma.NombrePrograma;
                vista.Nro_resolucion = mPrograma.Nro_resolucion;
                vista.IdPrograma = mPrograma.IdPrograma;

                return vista;
            }
            catch (Exception)
            {

                base.AddError("Sucedio un Error comprueb los datos");
                return null; ;
            }
        }

        public IProgramasVista GetProgramas(IPager pager)
        {
            try
            {
                IProgramasVista vista = new ProgramasVista();

                vista.Pager = pager;

                vista.ListaPrograma = programarepositorio.GetProgramas(pager.Skip, pager.PageSize);

                return vista;
            }
            catch (Exception)
            {

                base.AddError("Sucedio un Error comprueb los datos");
                return null; ;
            }
        }

        public bool AgregarPrograma(IProgramaVista programa)
        {
            try
            {
                IPrograma addprograma = new Programa();

                addprograma.NombrePrograma = programa.NombrePrograma;
                addprograma.Nro_resolucion = programa.Nro_resolucion;

                return programarepositorio.AgregarPrograma(addprograma);

            }
            catch (Exception)
            {

                base.AddError("Sucedio un Error comprueb los datos");
                return false; ;
            }
        }

        public bool ModificarPrograma(IProgramaVista programa)
        {
            try
            {
                IPrograma addprograma = new Programa();

                addprograma.NombrePrograma = programa.NombrePrograma;
                addprograma.Nro_resolucion = programa.Nro_resolucion;
                addprograma.IdPrograma = programa.IdPrograma;

                return programarepositorio.ModificarPrograma(addprograma);

            }
            catch (Exception)
            {

                base.AddError("Sucedio un Error comprueb los datos");
                return false; ;
            }
        }

        public bool EliminarPrograma(int idPrograma, string nro_resolucion)
        {
            try
            {
                return programarepositorio.EliminarPrograma(idPrograma, nro_resolucion);
            }
            catch (Exception)
            {

                base.AddError("Sucedio un Error comprueb los datos");
                return false; ;
            }
        }
    }
}
