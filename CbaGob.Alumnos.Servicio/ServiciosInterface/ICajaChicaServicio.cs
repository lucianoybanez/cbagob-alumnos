using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface ICajaChicaServicio : IBaseServicio
    {
        ICajaChicasVista GetCajaChicas();
        ICajaChicasVista GetCajaChicasByInstitucion(int id_institucion);
        ICajaChicaVista GetCajaChica(int idcajachica);
        ICajaChicaVista GetIndex(int id_institucion);
        bool AgregarCajaChica(ICajaChicaVista cajachica);
        bool ModificaCajaChica(ICajaChicaVista cajachica);
        bool EliminarCajaChica(int idcajachica);
    }
}
