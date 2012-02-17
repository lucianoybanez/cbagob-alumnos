using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IDocentes : IComunDatos, IPersonaJuridica
    {
        int Id_Docente { get; set; }
        int Id_PersonaJuridica { get; set; }
        int Id_Domicilio { get; set; }
        int Id_Cargo { get; set; }
        string N_Modalidad { get; set; }
        string Estado { get; set; }
    }
}
