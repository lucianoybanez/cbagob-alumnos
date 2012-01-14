using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(20)] 
        public string Password { get; set; }
        public IList<Rol> Rols { get; set; }
    }
}