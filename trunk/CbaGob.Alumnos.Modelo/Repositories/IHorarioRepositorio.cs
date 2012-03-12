using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IHorarioRepositorio
    {
        IList<IHorario> GetHorarios();
        IList<IHorario> GetHorariosForGrupo(int id_grupo);
        IList<IHorario> GetHorariosByGrupo(int id_grupo);
        bool AgregarHorarioAGrupo(int id_grupo, int id_horario);
        bool SacarHorarioAGrupo(int id_grupo, int id_horario);
    }
}
