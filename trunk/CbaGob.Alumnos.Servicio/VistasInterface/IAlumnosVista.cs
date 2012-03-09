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
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Nro_Documento { get; set; }
        System.DateTime Fecha_Nacimiento { get; set; }
        string Cuil { get; set; }
        int Id_Tipo_Dni { get; set; }
        int Id_Tipo_Estado_Civil { get; set; }
        int Id_Tipo_Sexo { get; set; }
        string TipoSexo { get; set; }
        string TipoEstadoCivil { get; set; }
        string Tipo_Dni { get; set; }
        string Nro_Resolucion { get; set; }

        IComboBox Sexo { get; set; }
        IComboBox TipoDocumento { get; set; }
        IComboBox EstadoCivil { get; set; }
        IList<IAlumnos> ListaAlumno { get; set; }
        IList<IPersona> ListaPersona { get; set; }
        IPersona persona { get; set; }
        string Nro_Telefono { get; set; }
        string Nro_Celular { get; set; }
    }
}
