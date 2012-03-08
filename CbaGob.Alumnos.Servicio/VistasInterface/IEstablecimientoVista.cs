using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IEstablecimientoVista
    {
        int Id_Establecimiento { get; set; }
        int Id_Institucion { get; set; }
        string NombreEstablecimiento { get; set; }
        string Provincia { get; set; }
        string Localidad { get; set; }
        string Barrio { get; set; }
        string Calle { get; set; }
        int Nro { get; set; }
        int Depto { get; set; }
        string Emial { get; set; }
        string Telefono { get; set; }
        string Resposable { get; set; }
        string DomicilioCompleto { get; set; }
        string NombreInstitucion { get; set; }
        string Nro_Resolucion { get; set; }
    }
}
