using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IHorarioServicio
    {
        IHorariosVista GetHorarios();
        IHorariosVista GetHorariosForGrupo(int id_grupo);
        IHorariosVista GetHorariosByGrupo(int id_grupo);
        IHorariosVista GetHorarioByAlumno(int id_alumno, int id_cursos);
        IHorariosVista GetHorarioByDocente(int id_docente, int id_cursos);
        bool AgregarHorarioAGrupo(int id_grupo, int id_horario);
        bool SacarHorarioAGrupo(int id_grupo, int id_horario);
        bool AgregarHorarioalAlumno(int id_alumno, int id_horario, int id_grupo);
        bool SacarHorarioalAlumno(int id_alumno, int id_horario, int id_grupo);
        bool AgregarHorarioalDocente(int id_docente, int id_horario, int id_grupo);
        bool SacarHorarioalDocente(int id_docente, int id_horario, int id_grupo);
    }
}
