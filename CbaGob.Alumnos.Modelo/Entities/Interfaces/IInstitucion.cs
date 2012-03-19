using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IInstitucion : IComunDatos
    {
        int Id_Institucion { get; set; }
        string Nombre_Institucion { get; set; }
        string espropia { get; set; }
        string Provincia { get; set; }
        string Localidad { get; set; }
        string Barrio { get; set; }
        string Calle { get; set; }
        int Nro { get; set; }
        int Depto { get; set; }
        string Nro_Resolucion { get; set; }
        string Nro_Expediente { get; set; }
        string Telefono { get; set; }
    }
}
