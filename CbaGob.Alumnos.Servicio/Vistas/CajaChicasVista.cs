using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class CajaChicasVista : ICajaChicasVista
    {
        public IList<ICajaChica> ListaCajaChica { get; set; }
        
    }
}
