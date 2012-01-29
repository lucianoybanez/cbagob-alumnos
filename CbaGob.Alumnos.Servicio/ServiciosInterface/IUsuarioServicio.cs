using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.Vistas;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IUsuarioServicio : IBaseServicio
    {
        bool IsCuentaValida(string username, string password);
        void Login(string nombre);
        ICookieData GetCookieData();
    }
}
