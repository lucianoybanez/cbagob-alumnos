using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class MovimientoVista : IMovimientoVista
    {
        public MovimientoVista()
        {
            TipoMovimiento = new ComboBox();
        }

        public int Id_Movimiento { get; set; }
        public int Id_Caja_Chica { get; set; }
        public int Id_Tipo_Movimiento { get; set; }
        public int Id_Institucion { get; set; }
        public string Nombre_Movimiento { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public string NombreTipoMovimiento { get; set; }
        public decimal MontoCaja { get; set; }
        public string NombreInstitucion { get; set; }
        public IComboBox TipoMovimiento { get; set; }
       
    }
}
