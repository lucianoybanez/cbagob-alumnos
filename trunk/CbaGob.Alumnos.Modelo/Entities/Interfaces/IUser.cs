using System.Collections.Generic;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        IList<Rol> Rols { get; set; } 
    }
}
