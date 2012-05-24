using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IDocentes : IComunDatos
    {
        int Id_Docente { get; set; }
        int Id_Cargo { get; set; }
        string N_Modalidad { get; set; }
        string Planta { get; set; }
        string Reproca { get; set; }
        string Provincia { get; set; }
        string Localidad { get; set; }
        string Barrio { get; set; }
        string Calle { get; set; }
        int Nro { get; set; }
        string Cuit_Cuil { get; set; }
        string RazonSoial { get; set; }
        string Nro_Resolucion { get; set; }
        string Dni { get; set; }
        int id_tipo_docente { get; set; }
        string NombreTipoDocente { get; set; }
        string Resolucion_Reproca { get; set; }
        string NombreCargo { get; set; }
        string Telefono { get; set; }
        System.DateTime FechaNacimiento { get; set; }

    }
}
