using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IMovimientoServicio
    {
        IMovimientosVista GetMovimientosByCajaChica(int id_caja_chica);
        IMovimientoVista GetMovimiento(int Id_Movimento);
        IMovimientoVista GetIndex();
        bool AgregarMovimiento(IMovimientoVista movimiento);
        bool ModificarMovimiento(IMovimientoVista movimiento);
        bool EliminarMovimiento(int id_movimiento);
    }
}
