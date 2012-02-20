using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IEstadoCursoRepositorio
    {
        IList<IEstadoCurso> GetEstadosCursos();
        bool AgregarEstadoCurso(IEstadoCurso estadoCurso);
        bool ModificarEstadoCurso(IEstadoCurso estadoCurso);
        bool ElimiarEstadoCurso(int idEstadoCurso);
    }
}
