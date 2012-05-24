using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ISupervisorVista
    {
        int Id_Supervisor { get; set; }
        string DomicilioCompleto { get; set; }
        string DatosCompletoPersonajur { get; set; }
        string Provincia { get; set; }
        string Localidad { get; set; }
        string Barrio { get; set; }
        string Calle { get; set; }
        int Nro { get; set; }
        string Cuil_Cuit { get; set; }
        string Razon_Social { get; set; }
        string Nro_Resolucion { get; set; }
    }
}
