using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ICajaChicaVista
    {
        int Id_Caja_Chica { get; set; }
        int Id_Estado_Caja_Chica { get; set; }
        int Id_Institucion { get; set; }
        decimal Monto { get; set; }
        string NombreInstitucion { get; set; }
        string NombreEstadoCaja { get; set; }
        IComboBox EstadoCaja { get; set; }
        IMovimientosVista Moviminetos { get; set; }
        decimal SaldoCaja { get; set; }
    }
}
