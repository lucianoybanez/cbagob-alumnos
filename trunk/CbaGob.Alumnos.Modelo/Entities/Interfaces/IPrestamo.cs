using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IPrestamo : IComunDatos
    {
        int Id_Prestamo { get; set; }
        int Id_Institucion { get; set; }
        int Id_Equipo { get; set; }
        System.DateTime Fec_Inicio { get; set; }
        System.DateTime Fec_Fin { get; set; }
        string Observaciones { get; set; }
        string NombreEquipo { get; set; }
        string NombreInstitucion { get; set; }
    }
}
