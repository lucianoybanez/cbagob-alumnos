using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IPrestamoServicio : IBaseServicio
    {
        IPrestamosVista GetPrestamos();
        IPrestamosVista GetPrestamos(IPager Pager);
        IPrestamosVista GetPrestamosByInstitucion(int id_institucion);
        IPrestamoVista GetPrestamo(int id_prestamo);
        bool AgregarPresatmo(IPrestamoVista prestamo);
        bool ModificarPresatmo(IPrestamoVista prestamo);
        bool EliminarPresatmo(int id_presatmo);
    }
}
