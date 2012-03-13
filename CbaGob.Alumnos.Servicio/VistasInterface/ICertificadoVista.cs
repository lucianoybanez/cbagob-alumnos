using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ICertificadoVista
    {
        string NombreAlumno { get; set; }
        string Texto { get; set; }
        DateTime Fecha { get; set; }
        string ImagenSistemaPath { get; set; }
        string ImagenEscudoPath { get; set; }
    }
}
