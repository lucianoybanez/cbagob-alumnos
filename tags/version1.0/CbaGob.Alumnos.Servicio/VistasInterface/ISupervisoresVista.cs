using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ISupervisoresVista
    {
        IList<ISupervisores> ListaSupervisores { get; set; }
        int id_supervisores { get; set; }
        IPager Pager { get; set; }
    }
}
