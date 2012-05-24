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
        IList<IHorario> GetHorarioByAlumno(int id_alumno, int id_cursos);
        IList<IHorario> GetHorarioByDocente(int id_docente, int id_cursos);
        bool AgregarHorarioAGrupo(int id_grupo, int id_horario);
        bool SacarHorarioAGrupo(int id_grupo, int id_horario);
        bool AgregarHorarioalAlumno(int id_alumno, int id_horario, int id_grupo);
        bool SacarHorarioalAlumno(int id_alumno, int id_horario, int id_grupo);
        bool AgregarHorarioalDocente(int id_docente, int id_horario, int id_grupo);
        bool SacarHorarioalDocente(int id_docente, int id_horario, int id_grupo);
    }
}
