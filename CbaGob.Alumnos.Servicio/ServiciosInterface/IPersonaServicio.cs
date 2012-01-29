using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IPersonaServicio
    {
        UsuarioVista BuscarUsuario(UsuarioVista vista);
        UsuarioVista GetIndex();
    }
}
