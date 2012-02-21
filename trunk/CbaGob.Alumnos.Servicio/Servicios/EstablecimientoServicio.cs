using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Repositorio;
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


        public IEstablecimientosVista GetTodos()
        {
            try
            {
                IEstablecimientosVista establecimientosvista = new EstablecimientosVista();

                establecimientosvista.ListaEstablecimiento = establecimientorepositorio.GetTodos();

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

        public IEstablecimientosVista GetEstableciminetoByInstitucion(int id_institucion)
        {
            try
            {
                IEstablecimientosVista establecimientosvista = new EstablecimientosVista();

                establecimientosvista.ListaEstablecimiento = establecimientorepositorio.GetEstablecimientoByInstitucion(id_institucion);

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

        public IEstablecimientoVista GetUno(int id_establecimiento)
        {
            try
            {
                IEstablecimientoVista establecimientovista = new EstablecimientoVista();

                IEstablecimiento establecimiento = establecimientorepositorio.GetUno(id_establecimiento);

                return establecimientovista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Agregar(IEstablecimientoVista establecimiento)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(IEstablecimientoVista establecimiento)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id_establecimiento)
        {
            throw new NotImplementedException();
        }
    }
}
