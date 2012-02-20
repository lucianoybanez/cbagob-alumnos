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
        bool AgregarCondicion(ICondicionCurso condicion);
        bool ModificarCondicion(ICondicionCurso condicion);
        bool EliminarCondicion(int IdCondicion);
    }
}
