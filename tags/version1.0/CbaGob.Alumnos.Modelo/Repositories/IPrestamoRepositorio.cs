using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IPrestamoRepositorio
    {
        IList<IPrestamo> GetPrestamos();
        IList<IPrestamo> GetPrestamos(int skip, int take);
        int GetCountPrestamos();
        IList<IPrestamo> GetPrestamosByInstitucion(int id_institucion);
        IPrestamo GetPrestamo(int id_prestamo);
        bool AgregarPresatmo(IPrestamo prestamo);
        bool ModificarPresatmo(IPrestamo prestamo);
        bool EliminarPresatmo(int id_presatmo);
    }
}
