using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Servicio.Comun
{
    public interface ICookieData
    {
        string Usuario { get; set; }
        string Rol { get; set; }
    }
}
