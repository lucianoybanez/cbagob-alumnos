using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class HomeServicio : BaseService, IHomeServicio
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public HomeServicio(IUsuarioRepositorio _usuarioRepositorio)
        {
            this._usuarioRepositorio = _usuarioRepositorio;
        }

        public IHomeVista GetDefault()
        {
            IHomeVista myVista = new HomeVista();
            myVista.FirstUser = _usuarioRepositorio.GetUserById(1).PersonaUsuario;
            return myVista;
        }
    }
}
