using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IUsuarioServicio : IBaseServicio
    {
        bool IsCuentaValida(string username, string password);
        void Login(string nombre);
        ICookieData GetCookieData();

        IUsuarioVista GetUsuario(int idusuario);
        IUsuarioVista GetAllUsuarios(IPager pager);
        bool GuardarUsuario(IUsuarioVista usuario);
        bool EliminarUsuario(int idusuario);
        IUsuarioVista GetUsuario(string nombre);
        IComboBox GetRoles();
    }
}
