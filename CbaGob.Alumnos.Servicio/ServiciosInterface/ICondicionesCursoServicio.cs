using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface ICondicionesCursoServicio : IBaseServicio
    {
        ICondicionesCursoVista GetByInstitucionId(int IdInstitucion);
        ICondicionCursoVista GetForModificacion(int IdCondicionCurso);
        ICondicionCursoVista GetForAlta(int IdInstitucion);
    }
}
