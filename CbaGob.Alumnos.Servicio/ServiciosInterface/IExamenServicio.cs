using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IExamenServicio : IBaseServicio
    {
        IExamenVista GetExamenVista();
        IExamenVista GetExamenVista(int IdExamen);
        IExamenVista GetExamenVistaCambioComboGrupo(IExamenVista vista);
        IExamenesVista GetExamanes();
        bool GuardarExamen(IExamenVista vista);
        bool EliminarExamen(int IdExamen);
    }
}
