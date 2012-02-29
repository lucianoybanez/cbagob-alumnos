using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface ISupervisores : IComunDatos
    {
        int Id_Supervisor { get; set; }
        int Id_PersonaJuridica { get; set; }
        int Id_Domicilio { get; set; }
        string DomicilioCompleto { get; set; }
        string DatosCompletoPersonajur { get; set; }
        string RazonSocial { get; set; }
        string Cuit { get; set; }
    }
}
