using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class SupervicionesVista : ISupervicionesVista
    {
        public IList<ISuperviciones> ListaSuperviciones { get; set; }
        public int id_supervicion { get; set; }
    }
}
