using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface ICargosServicio : IBaseServicio
    {
        ICargosVista GetTodosCargos();
        ICargosVista GetTodosCargos(IPager pager);
        ICargoVista GetCargo(int idcargo);
        bool AgregarCargo(ICargoVista cargo);
        bool ModificarCargo(ICargoVista cargo);
        bool EliminarCargo(int id_cargo, string nro_resolucion);
    }
}
