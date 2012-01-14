using System.Collections.Generic;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IRol
    {
        int Id { get; set; }
        string Descrition { get; set; }
        IList<User> Users { get; set; }
    }
}
