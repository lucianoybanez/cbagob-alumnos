using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IAreasTipoCursoServicio : IBaseServicio
    {
        IAreasTipoCursoVista GetAreasTipoCurso();
        IAreasTipoCursoVista GetAreasTipoCurso(IPager pager);
        IAreaTipoCursoVista GetAreaTipoCurso(int id_area_tipo_curso);
        bool AgregarAreaTipoCargo(IAreaTipoCursoVista areatipocargo);
        bool ModificarAreaTipoCargo(IAreaTipoCursoVista areatipocargo);
        bool EliminarAreaTipoCargo(int id_areatipocargo, string nro_resolucion);

      


    }
}
