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
        bool GuardarCondicionCurso(ICondicionCursoVista condicion);
        bool EliminarCondicionCurso(int IdCondicionCurso);
        bool CambiarEstadoCurso(int IdCondicion, int NuevoEstado);
        ICondicionesCursoVista BuscarCondiciones(string institucion, string nivel, string curso);
    }
}
