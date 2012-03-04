using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Movimiento:IMovimiento
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
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
    }
}
