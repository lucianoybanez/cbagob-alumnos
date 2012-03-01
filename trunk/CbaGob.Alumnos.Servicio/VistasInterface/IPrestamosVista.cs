using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IPrestamosVista
    {
        IList<IPrestamo> ListaPrestamo { get; set; }
        int id_prestamo { get; set; }
    }
}
