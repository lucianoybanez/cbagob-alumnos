using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IGrupoServicio : IBaseServicio
    {
        IGrupoVista GetGrupo(int id_grupo);
        IGruposVista GetAllGrupo();
        IGruposVista GetAllGrupoByCurso(int id_condicioncurso);
        bool AgregarGrupo(IGrupoVista grupo);
        bool ModificarGrupo(IGrupoVista grupo);
        bool EliminarGrupo(int id_grupo);
    }
}
