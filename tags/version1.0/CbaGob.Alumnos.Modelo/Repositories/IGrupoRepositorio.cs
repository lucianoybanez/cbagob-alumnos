using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IGrupoRepositorio
    {
        IGrupo GetGrupo(int id_grupo);
        IList<IGrupo> GetAllGrupo();
        IList<IGrupo> GetAllGrupoByCurso(int id_condicioncurso);
        bool AgregarGrupo(IGrupo grupo);
        bool ModificarGrupo(IGrupo grupo);
        bool EliminarGrupo(int id_grupo, string nro_resolucion);
        int CountAlumnosGrupo(int id_grupo);
    }
}
