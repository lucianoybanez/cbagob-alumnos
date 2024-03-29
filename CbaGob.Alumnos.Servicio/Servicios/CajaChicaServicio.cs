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
    public class CajaChicaServicio : BaseServicio, ICajaChicaServicio
    {
        private ICajaChicaRepositorio cajachicarepositorio;
        private IInstitucionRepositorio institucionrepositorio;
        private IMovimientoRepositorio movimientorepositorio;

        public CajaChicaServicio(ICajaChicaRepositorio cajachicarepositorio, IInstitucionRepositorio institucionrepositorio, IMovimientoRepositorio movimientorepositorio)
        {
            this.cajachicarepositorio = cajachicarepositorio;
            this.institucionrepositorio = institucionrepositorio;
            this.movimientorepositorio = movimientorepositorio;
        }

        public ICajaChicasVista GetCajaChicas()
        {
            try
            {
                ICajaChicasVista model = new CajaChicasVista();

                model.ListaCajaChica = cajachicarepositorio.GetCajaChicas();

                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ICajaChicasVista GetCajaChicasByInstitucion(int id_institucion)
        {
            try
            {
                ICajaChicasVista model = new CajaChicasVista();

                model.ListaCajaChica = cajachicarepositorio.GetCajaChicasByInstitucion(id_institucion);

                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ICajaChicaVista GetCajaChica(int idcajachica)
        {
            try
            {
                ICajaChicaVista model = new CajaChicaVista();

                ICajaChica cajachica = cajachicarepositorio.GetCajaChica(idcajachica);

                model.Id_Caja_Chica = cajachica.Id_Caja_Chica;
                model.Id_Estado_Caja_Chica = cajachica.Id_Estado_Caja_Chica;
                model.Id_Institucion = cajachica.Id_Institucion;
                model.Monto = cajachica.Monto;
                model.NombreEstadoCaja = cajachica.NombreEstadoCaja;
                model.NombreInstitucion = cajachica.NombreInstitucion;
                ConvertEstadoCaja(model, cajachicarepositorio.GetEstadoCajaChicas());
                //model.EstadoCaja.Selected = cajachica.Id_Estado_Caja_Chica.ToString();


                return model;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICajaChicaVista GetIndex(int id_institucion)
        {
            try
            {
                ICajaChicaVista model = new CajaChicaVista();
                IInstitucion institucion = new Institucion();

                institucion = institucionrepositorio.GetInstitucion(id_institucion);

                model.Id_Institucion = id_institucion;
                model.NombreInstitucion = institucion.Nombre_Institucion;

                ConvertEstadoCaja(model, cajachicarepositorio.GetEstadoCajaChicas());

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void ConvertEstadoCaja(ICajaChicaVista vista, IList<IEstadoCajaChica> estadocaja)
        {
            foreach (var est in estadocaja)
            {
                vista.EstadoCaja.Combo.Add(new ComboItem()
                {
                    id = est.Id_Estado_Caja_Chica,
                    description = est.Nombre_estado
                });
            }
        }

        public bool AgregarCajaChica(ICajaChicaVista cajachica)
        {
            try
            {
                ICajaChica addcajachica = new CajaChica();

                addcajachica.Id_Estado_Caja_Chica = Convert.ToInt32(cajachica.EstadoCaja.Selected);
                addcajachica.Id_Institucion = cajachica.Id_Institucion;
                addcajachica.Monto = cajachica.Monto;

                return cajachicarepositorio.AgregarCajaChica(addcajachica);

            }
            catch (Exception ex)
            {
                AddError("Ocurrio un error Por Favor Intentelo de Nuevo");
                return false;
            }
        }

        public bool ModificaCajaChica(ICajaChicaVista cajachica)
        {
            try
            {
                ICajaChica addcajachica = new CajaChica();
                bool mreturn;

                addcajachica.Id_Estado_Caja_Chica = Convert.ToInt32(cajachica.EstadoCaja.Selected);
                addcajachica.Id_Institucion = cajachica.Id_Institucion;
                addcajachica.Monto = cajachica.Monto;
                addcajachica.Id_Caja_Chica = cajachica.Id_Caja_Chica;

                mreturn = cajachicarepositorio.ModificaCajaChica(addcajachica);

                if (mreturn == true)
                {
                    foreach (var caja in movimientorepositorio.GetMovimientosByCajaChica(cajachica.Id_Caja_Chica))
                    {
                        movimientorepositorio.EliminarMovimiento(caja.Id_Movimiento);
                    }
                }

                return mreturn;

            }
            catch (Exception ex)
            {
                AddError("Ocurrio un error Por Favor Intentelo de Nuevo");
                return false;
            }
        }

        public bool EliminarCajaChica(int idcajachica)
        {
            try
            {
                return cajachicarepositorio.EliminarCajaChica(idcajachica);
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
