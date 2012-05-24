using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Repositorio
{
    public class BaseRepositorio : IBaseRepositorio
    {
        public ILoggedUserHelper LoggedUserHelper;

        public BaseRepositorio(ILoggedUserHelper LoggedUserHelper)
        {
            this.LoggedUserHelper = LoggedUserHelper;
        }


        public void AgregarDatosAlta(IComunDatos dato)
        {
            dato.FechaAlta = System.DateTime.Now;
            dato.UsuarioAlta = LoggedUserHelper.GetLoggedUsuario();
            AgregarDatosModificacion(dato);
        }

        
        public void AgregarDatosModificacion(IComunDatos dato)
        {
            dato.Estado = "A";
            dato.FechaModificacion = System.DateTime.Now;
            dato.UsuarioModificacion = LoggedUserHelper.GetLoggedUsuario();
        }

        public void AgregarDatosEliminacion(IComunDatos dato)
        {
            dato.FechaModificacion = System.DateTime.Now;
            dato.UsuarioModificacion = LoggedUserHelper.GetLoggedUsuario();
            dato.Estado = "I";
        }

    }

    public interface IBaseRepositorio
    {
        void AgregarDatosAlta(IComunDatos dato);
        void AgregarDatosModificacion(IComunDatos dato);
        void AgregarDatosEliminacion(IComunDatos dato);
    }
}
