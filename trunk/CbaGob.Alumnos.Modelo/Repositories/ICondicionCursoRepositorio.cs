using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface ICondicionCursoRepositorio
    {
        ICondicionCurso GetCondicion(int IdCondicion);
        IList<ICondicionCurso> GetCondicionesByInstitucion(int IdInstitucion);
        IList<ICondicionCurso> GetCondicionCursoBy(int IdInstitucion, int IdCurso, int IdEstadoCurso, int IdNivel, int IdModalidad, int IdPrograma);
        ICondicionCurso GetFirstCondicion();
        bool AgregarCondicion(ICondicionCurso condicion);
        bool ModificarCondicion(ICondicionCurso condicion);
        bool EliminarCondicion(int IdCondicion, string nroresolucion);
        bool CambiarEstadoCurso(int IdCondicion, int NuevoEstado);
        IList<ICondicionCurso> BuscarCondiciones(string institucion, string nivel, string curso, int año,string programa);
    }
}
