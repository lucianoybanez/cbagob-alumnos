using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IProgramaServicio:IBaseServicio
    {
        IProgramasVista GetProgramas();
        IProgramaVista GetPrograma(int idprograma);
        IProgramasVista GetProgramas(IPager pager);
        bool AgregarPrograma(IProgramaVista programa);
        bool ModificarPrograma(IProgramaVista programa);
        bool EliminarPrograma(int idPrograma, string nro_resolucion);
    }
}
