using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IInventariosVista
    {
        IList<IInventarioVista> ListaInventario { get; set; }
    }
}
