using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Servicio.VistasInterface.Shared
{
    public interface IBuscador
    {
        string Name { get; set; }
        string Tipo { get; set; }
        string Valor { get; set; }
        string Relacionado { get; set; }
    }
}
