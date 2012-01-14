using System.Collections.Generic;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IUsuario
    {
        int Id { get; set; }
        string Nombre { get; set; }
        string Password { get; set; }
        IList<Rol> Roles { get; set; } 
    }
}
