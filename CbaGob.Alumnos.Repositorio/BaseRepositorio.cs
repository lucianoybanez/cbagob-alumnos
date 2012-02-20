using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Repositorio
{
    public class BaseRepositorio
    {

        public void AgregarDatosAlta(IComunDatos dato)
        {
            dato.FechaAlta = System.DateTime.Now;
            dato.UsuarioAlta = "Usuario Alta";
            dato.Estado = "A";
            AgregarDatosModificacion(dato);
        }

        
        public void AgregarDatosModificacion(IComunDatos dato)
        {
            dato.FechaModificacion = System.DateTime.Now;
            dato.UsuarioModificacion = "Usuario Modificacion";
        }

        public void AgregarDatosEliminacion(IComunDatos dato)
        {
            dato.FechaModificacion = System.DateTime.Now;
            dato.UsuarioModificacion = "Usuario Eliminacion";
            dato.Estado = "I";
        }

    }
}
