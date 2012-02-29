using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ISupervisoresVista
    {
        IList<ISupervisores> ListaSupervisores { get; set; }
        int id_supervisores { get; set; }
    }
}
