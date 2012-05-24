using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IModalidadServicio : IBaseServicio
    {
        IModalidadesVista GetModalidades();
        IModalidadesVista GetModalidades(IPager pager);
        IModalidadVista GetModalidad(int id_modalidad);
        bool AgregarModalidad(IModalidadVista modalidad);
        bool ModificarModalidad(IModalidadVista modalidad);
        bool EliminarModalidad(int idModalidad, string nro_resolucion);
    }
}
