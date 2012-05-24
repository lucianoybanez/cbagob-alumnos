using System.Collections.Generic;
using CbaGob.Alumnos.Servicio.Comun;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IBaseServicio
    {
        IList<IErrores> GetErrors();
    }
}
