using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface IAreaTipoCursoRepositorio
    {
        IList<IAreaTipoCurso> GetAreasTipoCurso();
        IAreaTipoCurso GetAreaTipoCargo(int id_area_tipo_curso);
        int GetCountAreasTipoCurso();
        IList<IAreaTipoCurso> GetAreasTipoCurso(int skip, int take);
        bool AgregarAreaTipoCargo(IAreaTipoCurso areatipocargo);
        bool ModificarAreaTipoCargo(IAreaTipoCurso areatipocargo);
        bool EliminarAreaTipoCargo(int id_areatipocargo, string nro_resolucion);

    }
}
