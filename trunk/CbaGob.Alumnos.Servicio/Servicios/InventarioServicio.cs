using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class InventarioServicio : IInventarioServicio
    {
        private IEquipoRepositorio  equiporepositorio;
        private IEstado_EquipoRepositorio estado_equiporepositorio;
 
        public InventarioServicio()
        {
            equiporepositorio = new EquipoRepositorio();
            estado_equiporepositorio = new Estado_EquipoRepositorio();
        }


        public IInventariosVista GetInventario()
        {
            try
            {
                IInventariosVista vistaretorno = new InventariosVista();
                
                foreach (IEstado_Equipo estado in estado_equiporepositorio.GetEstadosEquipo())
                {
                    IInventarioVista items = new InventarioVista();

                    items.CantidadEquipos = equiporepositorio.GetEquiposByEstado(estado.Id_Estado_Equipo).Count();
                    items.NombreItem = estado.Nombre_Estado_Equipo;
                    items.ListaEquipo = equiporepositorio.GetEquiposByEstado(estado.Id_Estado_Equipo);
                    items.Id_EstadoEquipo = estado.Id_Estado_Equipo;

                    vistaretorno.ListaInventario.Add(items);

                    items = null;

                }

                IInventarioVista totalequipos = new InventarioVista();

                totalequipos.CantidadEquipos = equiporepositorio.GetEquipos().Count();
                totalequipos.NombreItem = "Total Equipos";
                totalequipos.ListaEquipo = equiporepositorio.GetEquipos();

                vistaretorno.ListaInventario.Add(totalequipos);

                return vistaretorno;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IInventarioVista GetInventario(int id_estado)
        {
            try
            {
                IInventarioVista vistaretorno = new InventarioVista();

                vistaretorno.ListaEquipo = equiporepositorio.GetEquiposByEstado(id_estado);

                return vistaretorno;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
