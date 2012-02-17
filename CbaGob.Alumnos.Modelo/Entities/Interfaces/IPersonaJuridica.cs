using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IPersonaJuridica : IComunDatos
    {
        int Id_PersonaJur { get; set; }
        int Id_Sede { get; set; }
        string Cuit { get; set; }
        string Razon_Social { get; set; }
        string Estado { get; set; }
    }
}
