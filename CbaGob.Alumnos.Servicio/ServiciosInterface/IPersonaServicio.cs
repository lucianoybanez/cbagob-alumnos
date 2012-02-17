using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IPersonaServicio
    {
        UsuarioVista BuscarUsuario(UsuarioVista vista);
        UsuarioVista GetIndex();
        IList<IPersona> GetTodas();
        IList<IPersona> GetTodasByNombre(string nombre);
        IList<IPersona> GetPersonasDni(int dni);
    }
}
