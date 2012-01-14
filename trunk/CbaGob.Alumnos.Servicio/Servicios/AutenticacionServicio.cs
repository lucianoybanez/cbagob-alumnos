using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class AutenticacionServicio :BaseService, IAutenticacionServicio
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public AutenticacionServicio(IUsuarioRepositorio _usuarioRepositorio)
        {
            this._usuarioRepositorio = _usuarioRepositorio;
        }

        public bool IsAccountValid(string username, string password)
        {
            bool ret = false;
            var user = _usuarioRepositorio.GetUserByNamePassword(username, password);
            if (user==null)
            {
                AddError(TypeError.NotExist,"The User don't exist.");
            }
            else
            {
                ret = true;
            }
            return ret;
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}