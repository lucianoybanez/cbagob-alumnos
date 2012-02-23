using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IInscripcionesVista
    {
        IList<IInscripcion> ListaInscripcions { get; set; }
        int id_inscripcion { get; set; }
    }
}
