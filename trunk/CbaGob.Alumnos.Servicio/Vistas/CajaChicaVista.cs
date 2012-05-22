using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class CajaChicaVista : ICajaChicaVista
    {
        public CajaChicaVista()
        {
            EstadoCaja = new ComboBox();
        }

        public int Id_Caja_Chica { get; set; }
        public int Id_Estado_Caja_Chica { get; set; }
        public int Id_Institucion { get; set; }
        [Required]
        [Range(1,9999)]
        [DisplayName("Monto ($1 - $9999):")]
        public decimal Monto { get; set; }
        public string NombreInstitucion { get; set; }
        public string NombreEstadoCaja { get; set; }
        public IComboBox EstadoCaja { get; set; }
        public IMovimientosVista Moviminetos { get; set; }
        public decimal SaldoCaja { get; set; }
    }
}
