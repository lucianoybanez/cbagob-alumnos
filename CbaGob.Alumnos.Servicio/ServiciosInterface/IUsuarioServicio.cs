using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.Vistas;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IUsuarioServicio : IBaseServicio
    {
        bool IsCuentaValida(string username, string password);
        UsuarioVista GetIndex();
        UsuarioVista BuscarUsuarioNombre(string nombre);
        UsuarioVista BuscarUsuarioDni(int dni);
        UsuarioVista BuscarUsuario(UsuarioVista vista);
        void Login(string nombre);
        ICookieData GetCookieData();
    }
}
