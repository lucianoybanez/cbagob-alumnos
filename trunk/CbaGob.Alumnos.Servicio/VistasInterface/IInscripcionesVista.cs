using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IInscripcionesVista
    {
        IList<IInscripcion> ListaInscripciones { get; set; }
        int id_inscripcion { get; set; }
        IPager pager { get; set; }
    }
}
