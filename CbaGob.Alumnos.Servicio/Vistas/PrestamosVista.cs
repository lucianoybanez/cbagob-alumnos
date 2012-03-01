using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class PrestamosVista : IPrestamosVista
    {
        public IList<IPrestamo> ListaPrestamo { get; set; }
        public int id_prestamo { get; set; }
    }
}
