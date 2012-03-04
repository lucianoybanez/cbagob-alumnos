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
    public class MovimientoServicio :BaseServicio, IMovimientoServicio
    {
        private IMovimientoRepositorio movimientorepositorio;

        public MovimientoServicio()
        {
            movimientorepositorio = new MovimientoRepositorio();
        }

        public IMovimientosVista GetMovimientosByCajaChica(int id_caja_chica)
        {
            try
            {
                IMovimientosVista model = new MovimientosVista();

                model.ListaMoviento = movimientorepositorio.GetMovimientosByCajaChica(id_caja_chica);

                return model;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public IMovimientoVista GetMovimiento(int Id_Movimento)
        {
            try
            {
                IMovimientoVista model = new MovimientoVista();

                IMovimiento movimiento = movimientorepositorio.GetMovimiento(Id_Movimento);

                model.Id_Caja_Chica = movimiento.Id_Caja_Chica;
                model.Id_Movimiento = movimiento.Id_Movimiento;
                model.Id_Tipo_Movimiento = movimiento.Id_Tipo_Movimiento;
                model.Monto = movimiento.Monto;
                model.MontoCaja = movimiento.MontoCaja;
                model.Nombre_Movimiento = movimiento.Nombre_Movimiento;
                model.NombreInstitucion = movimiento.NombreInstitucion;
                model.NombreTipoMovimiento = movimiento.NombreTipoMovimiento;
                model.Descripcion = movimiento.Descripcion;
                model.Id_Institucion = movimiento.Id_Institucion;
                ConvertTipoMovimiento(model, movimientorepositorio.GetTiposMovimiento());


                return model;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IMovimientoVista GetIndex()
        {
            try
            {
                IMovimientoVista model = new MovimientoVista();
                ConvertTipoMovimiento(model, movimientorepositorio.GetTiposMovimiento());

                return model;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static void ConvertTipoMovimiento(IMovimientoVista vista, IList<ITipo_Movimiento> tipomovimiento)
        {
            foreach (var est in tipomovimiento)
            {
                vista.TipoMovimiento.Combo.Add(new ComboItem()
                {
                    id = est.Id_Tipo_Movimiento,
                    description = est.Nombre_Tipo_Movimiento
                });
            }
        }

        public bool AgregarMovimiento(IMovimientoVista movimiento)
        {
            try
            {

                IMovimiento addmovimiento = new Movimiento();

                addmovimiento.Id_Caja_Chica = movimiento.Id_Caja_Chica;
                addmovimiento.Id_Tipo_Movimiento = Convert.ToInt32(movimiento.TipoMovimiento.Selected);
                addmovimiento.Monto = movimiento.Monto;
                addmovimiento.Nombre_Movimiento = movimiento.Nombre_Movimiento;
                addmovimiento.Descripcion = movimiento.Descripcion;
                addmovimiento.Fecha = movimiento.Fecha;

                return movimientorepositorio.AgregarMovimiento(addmovimiento);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool ModificarMovimiento(IMovimientoVista movimiento)
        {
            try
            {

                IMovimiento addmovimiento = new Movimiento();

                addmovimiento.Id_Caja_Chica = movimiento.Id_Caja_Chica;
                addmovimiento.Id_Movimiento = movimiento.Id_Movimiento;
                addmovimiento.Id_Tipo_Movimiento = Convert.ToInt32(movimiento.TipoMovimiento.Selected);
                addmovimiento.Monto = movimiento.Monto;
                addmovimiento.Nombre_Movimiento = movimiento.Nombre_Movimiento;
                addmovimiento.Descripcion = movimiento.Descripcion;
                addmovimiento.Fecha = movimiento.Fecha;

                return movimientorepositorio.ModificarMovimiento(addmovimiento);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool EliminarMovimiento(int id_movimiento)
        {
            try
            {
                return movimientorepositorio.EliminarMovimiento(id_movimiento);
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
