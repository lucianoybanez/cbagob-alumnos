using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IInscripcionRepositorio
    {
        IList<IInscripcion> GetAllInscripcion();
        IList<IInscripcion> GetAllInscripcionByAlumno(int id_alumno);
        IList<IInscripcion> GetAllInscripcionByGrupo(int idGrupo);
        int GetInscripcionIdByAlumnoGrupo(int idGrupo, int idAlumno);
        IInscripcion GetInscripcion(int id_inscripcion);
        bool AgregarInscripcion(IInscripcion inscripcion);
        bool ModificarInscripcion(IInscripcion inscripcion);
        bool EliminarInscripcion(int id_inscripcion);
    }
}
