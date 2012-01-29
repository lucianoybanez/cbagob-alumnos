using System;
using System.Collections.Generic;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IUsuario : IComunDatos
    {
        int PersonaID { get; set; }
        string PersonaUsuario { get; set; }
        string PersonaPassword { get; set; }
        Rol Rol { get; set; } 
    }
}
