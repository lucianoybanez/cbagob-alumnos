using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas.Shared
{
    public class Buscador : IBuscador
    {
        public string Name { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public string Relacionado { get; set; }
    }
}
