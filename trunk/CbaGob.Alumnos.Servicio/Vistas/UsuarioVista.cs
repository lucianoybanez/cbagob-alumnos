using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class UsuarioVista : IUsuarioVista
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public IList<IPersona> Usuarios { get; set; }
        public bool SearchByDni { get; set; }
    }
}