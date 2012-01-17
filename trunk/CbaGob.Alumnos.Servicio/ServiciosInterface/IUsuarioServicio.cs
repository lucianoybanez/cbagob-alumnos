using CbaGob.Alumnos.Servicio.Vistas;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IUsuarioServicio : IBaseServicio
    {
        UsuarioVista GetIndex();
        UsuarioVista BuscarUsuarioNombre(string nombre);
        UsuarioVista BuscarUsuarioDni(int dni);
        UsuarioVista BuscarUsuario(UsuarioVista vista);
    }
}
