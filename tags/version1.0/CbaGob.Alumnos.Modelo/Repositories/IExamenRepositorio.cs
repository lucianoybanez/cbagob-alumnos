using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IExamenRepositorio
    {
        IList<IExamen> GetExamenes();
        IExamen GetExamen(int idExamen);
        bool AgregarExamen(IExamen examen);
        bool ModificarExamen(IExamen examen);
        bool EliminarExamen(int idExamen);
        IList<IExamen> GetExamenesByInscripcion(int idInscripcion);
        IExamen GetExamen(int idInscipcion, int NroExamen);
    }
}
