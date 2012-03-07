using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IEstablecimientoServicio: IBaseServicio
    {
        IEstablecimientosVista GetAllEstablecimiento();
        IEstablecimientosVista GetAllEstableciminetoByInstitucion(int id_institucion);
        IEstablecimientoVista GetEstablecimiento(int id_establecimiento);
        bool AgregarEstablecimiento(IEstablecimientoVista establecimiento);
        bool ModificarEstablecimiento(IEstablecimientoVista establecimiento);
        bool EliminarEstablecimiento(int id_establecimiento, string nroresolucion);
    }
}
