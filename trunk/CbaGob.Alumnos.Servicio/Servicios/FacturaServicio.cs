using System;
using System.Collections.Generic;
using System.Linq;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
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

        public IFacturaVista GetFactura(int IdFactura)
        {
            throw new NotImplementedException();
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
                                                    description = inst.N_INSTITUCION,
                                                    id = inst.ID_INSTITUCION
                                                });
            }
        }

        public IFacturaVista GetIndex()
        {
            IFacturaVista vista = new FacturaVista();
            var instituciones = InstitucionRepositorio.GetInstituciones();
            IList<ICondicionCurso> condiciones = new List<ICondicionCurso>();
            if (instituciones!=null)
            {
                if (instituciones.Count>0)
                {
                    int idInstitucion = instituciones.First().ID_INSTITUCION;
                    condiciones = CondicionCursoRepositorio.GetCondicionesByInstitucion(idInstitucion);
                }
            }

            CargarComboInstituciones(vista, instituciones);
            CargarComboCondicionesCurso(vista, condiciones);

            return vista;
        }

        public bool AgregarFactura(IFacturaVista factura)
        {
            throw new NotImplementedException();
        }

        public bool EliminarFactura(int idFactura)
        {
            throw new NotImplementedException();
        }
    }
}