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
    public class EstablecimientoServicio : IEstablecimientoServicio
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

                foreach (var establecimiento in establecimientosvista.ListaEstablecimiento)
                {
                    IDomicilios domicilio = new Domicilios();

                    domicilio = domiciliosrepositorio.GetUno(establecimiento.Id_Domicilio);

                    establecimiento.Barrio = domicilio.Barrio;
                    establecimiento.Calle = domicilio.Calle;
                    establecimiento.Localidad = domicilio.Localidad;
                    establecimiento.Provincia = domicilio.Provincia;
                    establecimiento.Nro = domicilio.Nro;

                }


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

                foreach (var establecimiento in establecimientosvista.ListaEstablecimiento)
                {
                    IDomicilios domicilio = new Domicilios();

                    domicilio = domiciliosrepositorio.GetUno(establecimiento.Id_Domicilio);

                    establecimiento.Barrio = domicilio.Barrio;
                    establecimiento.Calle = domicilio.Calle;
                    establecimiento.Localidad = domicilio.Localidad;
                    establecimiento.Provincia = domicilio.Provincia;
                    establecimiento.Nro = domicilio.Nro;

                }

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

                IDomicilios domicilio = new Domicilios();

                domicilio = domiciliosrepositorio.GetUno(establecimiento.Id_Domicilio);

                establecimientovista.Barrio = domicilio.Barrio;
                establecimientovista.Calle = domicilio.Calle;
                establecimientovista.Localidad = domicilio.Localidad;
                establecimientovista.Provincia = domicilio.Provincia;
                establecimientovista.Nro = domicilio.Nro;

                establecimientovista.Id_Domicilio = establecimiento.Id_Domicilio;
                establecimientovista.Id_Establecimiento = establecimiento.Id_Establecimiento;
                establecimientovista.N_Establecimiento = establecimiento.N_Establecimiento;
                establecimientovista.Id_Institucion = establecimiento.Id_Institucion;

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
                addestablecimiento.Id_Domicilio = establecimiento.Id_Domicilio;
                addestablecimiento.N_Establecimiento = establecimiento.N_Establecimiento;

                return establecimientorepositorio.AgregarEstablecimiento(addestablecimiento);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool ModificarEstablecimiento(IEstablecimientoVista establecimiento)
        {
            try
            {
                IEstablecimiento addestablecimiento = new Establecimiento();
                addestablecimiento.Id_Institucion = establecimiento.Id_Institucion;
                addestablecimiento.Id_Domicilio = establecimiento.Id_Domicilio;
                addestablecimiento.N_Establecimiento = establecimiento.N_Establecimiento;
                addestablecimiento.Id_Establecimiento = establecimiento.Id_Establecimiento;

                return establecimientorepositorio.ModificarEstablecimiento(addestablecimiento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarEstablecimiento(int id_establecimiento)
        {
            try
            {
                return establecimientorepositorio.EliminarEstablecimiento(id_establecimiento);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IList<IErrores> GetErrors()
        {
            throw new NotImplementedException();
        }
    }
}
