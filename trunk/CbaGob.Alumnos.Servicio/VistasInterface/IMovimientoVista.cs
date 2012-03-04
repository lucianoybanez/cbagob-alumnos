using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IMovimientoVista
    {
        int Id_Movimiento { get; set; }
        int Id_Caja_Chica { get; set; }
        int Id_Tipo_Movimiento { get; set; }
        int Id_Institucion { get; set; }
        string Nombre_Movimiento { get; set; }
        System.DateTime Fecha { get; set; }
        decimal Monto { get; set; }
        string Descripcion { get; set; }
        string NombreTipoMovimiento { get; set; }
        decimal MontoCaja { get; set; }
        string NombreInstitucion { get; set; }
        IComboBox TipoMovimiento { get; set; }

    }
}
