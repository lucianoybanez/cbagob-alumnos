using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class FacturaServicio : BaseServicio, IFacturaServicio
    {
        private IFacturaRepositorio FacturaRepositorio;

        private ICondicionCursoRepositorio CondicionCursoRepositorio;

        private IInstitucionRepositorio InstitucionRepositorio;

        public FacturaServicio(IFacturaRepositorio facturaRepositorio, ICondicionCursoRepositorio condicionCursoRepositorio, IInstitucionRepositorio institucionRepositorio)
        {
            FacturaRepositorio = facturaRepositorio;
            CondicionCursoRepositorio = condicionCursoRepositorio;
            InstitucionRepositorio = institucionRepositorio;
        }

        public IFacturasVista GetFacturas()
        {
            IFacturasVista vista = new FacturasVista();
            vista.Facturas = FacturaRepositorio.GetFacturas();
            return vista;
        }

        public IFacturasVista GetFacturasbyLiquidacion()
        {
            IFacturasVista vista = new FacturasVista();
            vista.Facturas = FacturaRepositorio.GetFacturasbyLiquidacion();
            return vista;
        }

        public IFacturaVista GetFactura(int IdFactura)
        {
            var result = FacturaRepositorio.GetFacturabyId(IdFactura);
            IFacturaVista vista = new FacturaVista()
                                      {
                                          Accion = "Modificacion",
                                          Concepto = result.Concepto,
                                          Descripcion = result.DetalleFactura.Descripcion,
                                          IdFactura = result.IdFactura,
                                          NroFactura = result.NroFactura,
                                          Monto = result.MontoTotal,
                                          Item = result.DetalleFactura.Item,
                                          NombreCurso = result.NombreCurso,
                                          NombreInstitucion = result.NombreInstitucion
                                      };
            var condiciones = CondicionCursoRepositorio.GetCondicionesByInstitucion(result.IdInstitucion);
            var instituciones = InstitucionRepositorio.GetInstituciones();
            CargarComboInstituciones(vista, instituciones);
            CargarComboCondicionesCurso(vista, condiciones);
            vista.CondicionCurso.Selected = result.IdCondicionCurso.ToString();
            vista.Institucion.Selected = result.IdInstitucion.ToString();
            return vista;
        }

        public IFacturaVista CambiarCondicion(IFacturaVista vista)
        {

            var condiciones = CondicionCursoRepositorio.GetCondicionesByInstitucion(int.Parse(vista.Institucion.Selected));
            var instituciones = InstitucionRepositorio.GetInstituciones();

            CargarComboInstituciones(vista, instituciones);
            CargarComboCondicionesCurso(vista, condiciones);
            return vista;
        }

        private void CargarComboCondicionesCurso(IFacturaVista vista, IList<ICondicionCurso> condiciones)
        {
            foreach (var cond in condiciones)
            {
                vista.CondicionCurso.Combo.Add(new ComboItem()
                                                   {
                                                       id = cond.IdCondicionCurso,
                                                       description =
                                                           cond.NombreCurso + " - " + cond.NombreNivel + " - " +
                                                           cond.NombreModalidad
                                                   });
            }
        }

        private void CargarComboInstituciones(IFacturaVista vista, IList<IInstitucion> instituciones)
        {
            foreach (var inst in instituciones)
            {
                vista.Institucion.Combo.Add(new ComboItem()
                                                {
                                                    description = inst.Nombre_Institucion,
                                                    id = inst.Id_Institucion
                                                });
            }
        }

        public IFacturaVista GetIndex()
        {
            IFacturaVista vista = new FacturaVista();
            vista.Accion = "Alta";
            vista.NroFactura = new Random().Next(99, 9999999).ToString();
            var instituciones = InstitucionRepositorio.GetInstituciones();
            IList<ICondicionCurso> condiciones = new List<ICondicionCurso>();
            if (instituciones != null)
            {
                if (instituciones.Count > 0)
                {
                    int idInstitucion = instituciones.First().Id_Institucion;
                    condiciones = CondicionCursoRepositorio.GetCondicionesByInstitucion(idInstitucion);
                }
            }

            CargarComboInstituciones(vista, instituciones);
            CargarComboCondicionesCurso(vista, condiciones);

            return vista;
        }

        public bool AgregarFactura(IFacturaVista factura)
        {
            if (!string.IsNullOrEmpty(factura.CondicionCurso.Selected))
            {
                if (factura.CondicionCurso.Selected != "0")
                {
                    IFactura modelFactura = new Factura()
                                                {
                                                    Concepto = factura.Concepto,
                                                    IdCondicionCurso = int.Parse(factura.CondicionCurso.Selected),
                                                    MontoTotal = factura.Monto,
                                                    NroFactura = factura.NroFactura

                                                };


                    IDetalleFactura obj = new DetalleFactura() { Descripcion = factura.Descripcion, Item = factura.Item, Monto = factura.Monto };

                    modelFactura.DetalleFactura = obj;

                    int idFactura = FacturaRepositorio.AgregarFactura(modelFactura);
                    modelFactura.DetalleFactura.IdFactura = idFactura;
                    if (idFactura != 0)
                    {
                        return true;
                    }
                    base.AddError("Ocurrio un error al agregar la Factura");
                    return false;
                }
            }
            base.AddError("Debe seleccionar una condicion de Curso");
            return false;
        }

        public bool EliminarFactura(int idFactura)
        {
            try
            {
                return FacturaRepositorio.EliminarFactura(idFactura);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }


        }

        public bool LiquidarFactura(int idFactura)
        {
            try
            {
                return FacturaRepositorio.LiquidarFactura(idFactura);
            }
            catch (Exception)
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