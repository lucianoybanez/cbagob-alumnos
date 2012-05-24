using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ISupervicionesVista
    {
        IList<ISuperviciones> ListaSuperviciones { get; set; }
        int id_supervicion { get; set; }
        IPager Pager { get; set; }
    }
}
