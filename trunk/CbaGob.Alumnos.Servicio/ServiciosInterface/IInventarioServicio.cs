using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IInventarioServicio
    {
        IInventariosVista GetInventario();
        IInventarioVista GetInventario(int id_estado);
    }
}
