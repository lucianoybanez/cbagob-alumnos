using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ICajaChicasVista
    {
        IList<ICajaChica> ListaCajaChica { get; set; }

    }
}
