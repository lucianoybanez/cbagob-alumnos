using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class SupervisoresVista : ISupervisoresVista
    {
        public IList<ISupervisores> ListaSupervisores { get; set; }
        public int id_supervisores { get; set; }
    }
}
