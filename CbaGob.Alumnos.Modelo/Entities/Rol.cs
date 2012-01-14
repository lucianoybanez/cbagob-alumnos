using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Rol : IRol
    {
        public int Id { get; set; }
        public string Descrition { get; set; }
        public IList<User> Users { get; set; }
       
    }
}