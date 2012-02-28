using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IExamenVista
    {
        string Accion { get; set; }
        int IdExamen { get; set; }
        DateTime FechaExamen { get; set; }
        int NroExamen { get; set; }
        decimal Nota { get; set; }
        IComboBox Grupos { get; set; }
        IComboBox Alumnos { get; set; }
    }
}
