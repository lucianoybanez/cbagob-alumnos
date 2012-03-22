using System;
using System.Collections.Generic;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IUsuario : IComunDatos
    {
        int IdUsuario { get; set; }
        string NombreUsuario { get; set; }
        string Password { get; set; }
        string Rol { get; set; }
        int IdRol { get; set; }
        string UsuarioResponsable { get; set; }
    }
}
