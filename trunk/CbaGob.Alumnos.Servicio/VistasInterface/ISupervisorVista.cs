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
        int Id_PersonaJuridica { get; set; }
        int Id_Domicilio { get; set; }
        string DomicilioCompleto { get; set; }
        string DatosCompletoPersonajur { get; set; }
        string RazonSocial { get; set; }
        string Cuit { get; set; }
        IBuscador BuscadorDomicilio { get; set; }
        IBuscador BuscadorPersonaJur { get; set; }
    }
}
