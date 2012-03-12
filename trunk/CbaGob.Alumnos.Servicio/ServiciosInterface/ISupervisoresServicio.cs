using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface ISupervisoresServicio:IBaseServicio
    {
        ISupervisoresVista GetSupervisores();
        ISupervisoresVista GetSupervisoresByRazonSocial(string razonsocial);
        ISupervisorVista GetSupervisor(int idsupervisor);
        bool AgregarSupervisor(ISupervisorVista supervisor);
        bool ModificarSupervisor(ISupervisorVista supervisor);
        bool EliminarSupervisor(int idsupervisor, string nro_resolucion);
    }
}
