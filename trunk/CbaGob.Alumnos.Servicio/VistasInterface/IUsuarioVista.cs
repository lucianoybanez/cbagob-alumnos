using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Comun;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IUsuarioVista
    {
        int Dni { get; set; }
        string Nombre { get; set; }
        IList<IPersona> Usuarios { get; set; }
        bool SearchByDni { get; set; }
    }
}
