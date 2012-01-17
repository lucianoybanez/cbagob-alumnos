using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IUsuarioVista
    {
        int Dni { get; set; }
        string Nombre { get; set; }
        IList<IUsuario> Usuarios { get; set; }
        bool SearchByDni { get; set; }
    }
}
