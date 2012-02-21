using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IEstablecimientoServicio
    {
        IEstablecimientosVista GetTodos();
        IEstablecimientosVista GetEstableciminetoByInstitucion(int id_institucion);
        IEstablecimientoVista GetUno(int id_establecimiento);
        bool Agregar(IEstablecimientoVista establecimiento);
        bool Modificar(IEstablecimientoVista establecimiento);
        bool Eliminar(int id_establecimiento);
    }
}
