using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IMovimientoRepositorio
    {
        IList<IMovimiento> GetMovimientosByCajaChica(int id_caja_chica);
        IList<ITipo_Movimiento> GetTiposMovimiento();
        IMovimiento GetMovimiento(int Id_Movimento);
        bool AgregarMovimiento(IMovimiento movimiento);
        bool ModificarMovimiento(IMovimiento movimiento);
        bool EliminarMovimiento(int id_movimiento);
    }
}
