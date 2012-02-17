using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IAlumnosVista
    {
        int Id_Alumno { get; set; }

        int Id_Persona { get; set; }
        string Nov_Apellido { get; set; }
        string Nov_Nombre { get; set; }
        string Cuil { get; set; }
        DateTime Fecha_Nacimiento { get; set; }
        IComboBox Sexo { get; set; }
        string Nro_Documento { get; set; }
        IComboBox TipoDocumento { get; set; }
        IComboBox EstadoCivil { get; set; }
        string Estado { get; set; }
        IList<IAlumnos> ListaAlumno { get; set; }
        IList<IPersona> ListaPersona { get; set; }
        IPersona persona { get; set; } 
    }
}
