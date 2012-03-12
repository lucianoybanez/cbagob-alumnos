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
        bool AgregarHorarioAGrupo(int id_grupo, int id_horario);
        bool SacarHorarioAGrupo(int id_grupo, int id_horario);
    }
}
