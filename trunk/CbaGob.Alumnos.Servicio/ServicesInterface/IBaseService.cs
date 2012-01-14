using System.Collections.Generic;
using CbaGob.Alumnos.Servicio.Common;

namespace CbaGob.Alumnos.Servicio.ServicesInterface
{
    public interface IBaseService
    {
        IList<IErrors> GetErrors();
    }
}
