using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class EstablecimientoServicio : BaseServicio, IEstablecimientoServicio
    {
        private EstablecimientoRepositorio establecimientorepositorio;

        private DomiciliosRepositorio domiciliosrepositorio;

        public EstablecimientoServicio()
        {
            establecimientorepositorio = new EstablecimientoRepositorio();
            domiciliosrepositorio = new DomiciliosRepositorio();
        }


        public IEstablecimientosVista GetAllEstablecimiento()
        {
            try
            {
                IEstablecimientosVista establecimientosvista = new EstablecimientosVista();

                establecimientosvista.ListaEstablecimiento = establecimientorepositorio.GetAllEstablecimiento();

                return establecimientosvista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEstablecimientosVista GetAllEstableciminetoByInstitucion(int id_institucion)
        {
            try
            {
                IEstablecimientosVista establecimientosvista = new EstablecimientosVista();

                establecimientosvista.ListaEstablecimiento = establecimientorepositorio.GetAllEstablecimientoByInstitucion(id_institucion);

                return establecimientosvista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEstablecimientoVista GetEstablecimiento(int id_establecimiento)
        {
            try
            {
                IEstablecimientoVista establecimientovista = new EstablecimientoVista();

                IEstablecimiento establecimiento = establecimientorepositorio.GetEstablecimiento(id_establecimiento);

                establecimientovista.Barrio = establecimiento.Barrio;
                establecimientovista.Calle = establecimiento.Calle;
                establecimientovista.Localidad = establecimiento.Localidad;
                establecimientovista.Provincia = establecimiento.Provincia;
                establecimientovista.Nro = establecimiento.Nro;
                establecimientovista.NombreInstitucion = establecimiento.NombreInstitucion;
                establecimientovista.DomicilioCompleto = establecimiento.DomicilioCompleto;
                establecimientovista.Id_Establecimiento = establecimiento.Id_Establecimiento;
                establecimientovista.NombreEstablecimiento = establecimiento.NombreEstablecimiento;
                establecimientovista.Id_Institucion = establecimiento.Id_Institucion;
                establecimientovista.Provincia = establecimiento.Provincia;
                establecimientovista.Localidad = establecimiento.Localidad;
                establecimientovista.Barrio = establecimiento.Barrio;
                establecimientovista.Calle = establecimiento.Calle;
                establecimientovista.Nro = establecimiento.Nro;
                establecimientovista.Depto = establecimiento.Depto;
                establecimientovista.Resposable = establecimiento.Resposable;
                establecimientovista.Telefono = establecimiento.Telefono;
                establecimientovista.Emial = establecimiento.Emial;

                return establecimientovista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarEstablecimiento(IEstablecimientoVista establecimiento)
        {
            try
            {
                IEstablecimiento addestablecimiento = new Establecimiento();
                addestablecimiento.Id_Institucion = establecimiento.Id_Institucion;
                addestablecimiento.NombreEstablecimiento = establecimiento.NombreEstablecimiento;
                addestablecimiento.Provincia = establecimiento.Provincia;
                addestablecimiento.Localidad = establecimiento.Localidad;
                addestablecimiento.Barrio = establecimiento.Barrio;
                addestablecimiento.Calle = establecimiento.Calle;
                addestablecimiento.Nro = establecimiento.Nro;
                addestablecimiento.Depto = establecimiento.Depto;
                addestablecimiento.Resposable = establecimiento.Resposable;
                addestablecimiento.Telefono = establecimiento.Telefono;
                addestablecimiento.Emial = establecimiento.Emial;

                return establecimientorepositorio.AgregarEstablecimiento(addestablecimiento);
            }
            catch (Exception ex)
            {
                AddError("Ocurrio un error Por Favor Intentelo de Nuevo");
                return false;
            }
        }

        public bool ModificarEstablecimiento(IEstablecimientoVista establecimiento)
        {
            try
            {
                IEstablecimiento addestablecimiento = new Establecimiento();
                addestablecimiento.Id_Institucion = establecimiento.Id_Institucion;
                addestablecimiento.Id_Establecimiento = establecimiento.Id_Establecimiento;
                addestablecimiento.NombreEstablecimiento = establecimiento.NombreEstablecimiento;
                addestablecimiento.Provincia = establecimiento.Provincia;
                addestablecimiento.Localidad = establecimiento.Localidad;
                addestablecimiento.Barrio = establecimiento.Barrio;
                addestablecimiento.Calle = establecimiento.Calle;
                addestablecimiento.Nro = establecimiento.Nro;
                addestablecimiento.Depto = establecimiento.Depto;
                addestablecimiento.Resposable = establecimiento.Resposable;
                addestablecimiento.Telefono = establecimiento.Telefono;
                addestablecimiento.Emial = establecimiento.Emial;

                return establecimientorepositorio.ModificarEstablecimiento(addestablecimiento);
            }
            catch (Exception ex)
            {
                AddError("Ocurrio un error Por Favor Intentelo de Nuevo");
                return false;
            }
        }

        public bool EliminarEstablecimiento(int id_establecimiento, string nroresolucion)
        {
            try
            {
                return establecimientorepositorio.EliminarEstablecimiento(id_establecimiento, nroresolucion);
            }
            catch (Exception ex)
            {
                AddError("Ocurrio un error Por Favor Intentelo de Nuevo");
                return false;
            }
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}
