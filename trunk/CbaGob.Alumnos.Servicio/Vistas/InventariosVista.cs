using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class InventariosVista : IInventariosVista
    {
        
        public InventariosVista()
        {
            ListaInventario = new List<IInventarioVista>();
        }
        
        public IList<IInventarioVista> ListaInventario { get; set; }
    }
}
