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
