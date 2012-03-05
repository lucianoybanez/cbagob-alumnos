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
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class PrestamoServicio :BaseServicio, IPrestamoServicio
    {
        private IPrestamoRepositorio prestamorepositorio;
        private IEquipoRepositorio equiporepositorio;

        public PrestamoServicio()
        {
            prestamorepositorio = new PrestamoRepositorio();
            equiporepositorio = new EquipoRepositorio();
        }

        public IPrestamosVista GetPrestamos()
        {
            try
            {
                IPrestamosVista prestamosvista = new PrestamosVista();

                prestamosvista.ListaPrestamo = prestamorepositorio.GetPrestamos();

                return prestamosvista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IPrestamosVista GetPrestamosByInstitucion(int id_institucion)
        {
            try
            {
                IPrestamosVista prestamosvista = new PrestamosVista();

                prestamosvista.ListaPrestamo = prestamorepositorio.GetPrestamosByInstitucion(id_institucion);

                return prestamosvista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IPrestamoVista GetPrestamo(int id_prestamo)
        {
            try
            {
                IPrestamoVista prestamovista = new PrestamoVista();

                IPrestamo prestamo = prestamorepositorio.GetPrestamo(id_prestamo);

                prestamovista.Fec_Fin = prestamo.Fec_Fin;
                prestamovista.Fec_Inicio = prestamo.Fec_Inicio;
                prestamovista.Id_Equipo = prestamo.Id_Equipo;
                prestamovista.Id_Institucion = prestamo.Id_Institucion;
                prestamovista.Id_Prestamo = prestamo.Id_Prestamo;
                prestamovista.Observaciones = prestamo.Observaciones;
                prestamovista.NombreEquipo = prestamo.NombreEquipo;
                prestamovista.NombreInstitucion = prestamo.NombreInstitucion;


                return prestamovista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AgregarPresatmo(IPrestamoVista prestamo)
        {
            try
            {
                IPrestamo addprestamo = new Prestamo();

                addprestamo.Fec_Fin = prestamo.Fec_Fin;
                addprestamo.Fec_Inicio = prestamo.Fec_Inicio;
                addprestamo.Id_Equipo = prestamo.Id_Equipo;
                addprestamo.Id_Institucion = prestamo.Id_Institucion;
                addprestamo.Observaciones = prestamo.Observaciones;
                addprestamo.NombreEquipo = prestamo.NombreEquipo;
                addprestamo.NombreInstitucion = prestamo.NombreInstitucion;

                equiporepositorio.CambiarEstadoEquipo(prestamo.Id_Equipo, 2);

                return prestamorepositorio.AgregarPresatmo(addprestamo);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool ModificarPresatmo(IPrestamoVista prestamo)
        {
            try
            {
                IPrestamo addprestamo = new Prestamo();

                addprestamo.Fec_Fin = prestamo.Fec_Fin;
                addprestamo.Fec_Inicio = prestamo.Fec_Inicio;
                addprestamo.Id_Equipo = prestamo.Id_Equipo;
                addprestamo.Id_Institucion = prestamo.Id_Institucion;
                addprestamo.Id_Prestamo = prestamo.Id_Prestamo;
                addprestamo.Observaciones = prestamo.Observaciones;
                addprestamo.NombreEquipo = prestamo.NombreEquipo;
                addprestamo.NombreInstitucion = prestamo.NombreInstitucion;

                IPrestamo oldprestamo = prestamorepositorio.GetPrestamo(prestamo.Id_Prestamo);

                if (oldprestamo.Id_Equipo != prestamo.Id_Prestamo)
                {
                    equiporepositorio.CambiarEstadoEquipo(oldprestamo.Id_Equipo, 1);
                }

                equiporepositorio.CambiarEstadoEquipo(prestamo.Id_Equipo, 2);

                return prestamorepositorio.ModificarPresatmo(addprestamo);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool EliminarPresatmo(int id_presatmo)
        {
            try
            {
                IPrestamo oldprestamo = prestamorepositorio.GetPrestamo(id_presatmo);

                equiporepositorio.CambiarEstadoEquipo(oldprestamo.Id_Equipo, 1);

                return prestamorepositorio.EliminarPresatmo(id_presatmo);
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
