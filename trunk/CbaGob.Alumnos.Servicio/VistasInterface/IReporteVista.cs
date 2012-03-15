using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IReporteVista
    {
        string NombreInstitucion { get; set; }
        string NombreCurso { get; set; }
        string Expediente { get; set; }
        string Resolucion { get; set; }
        string Codigo { get; set; }
        int Varones { get; set; }
        int Mujeres { get; set; }
        int TotalHyM { get; set; }
        DateTime Fecha { get; set; }
        IList<IReporteAlumno> Alumnos { get; set; }
        

    }
}
