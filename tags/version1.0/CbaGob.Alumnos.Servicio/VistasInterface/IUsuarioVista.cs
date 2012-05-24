using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IUsuarioVista
    {
        int idUsuario { get; set; }
        string Accion { get; set; }
        int Dni { get; set; }
        string Nombre { get; set; }
        string password { get; set; }
        IComboBox Roles { get; set; }
        IList<IUsuario> Usuarios { get; set; }
        IPager pager { get; set; }
        string Representante { get; set; }
    }
}
