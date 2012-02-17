using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class AlumnosVista : IAlumnosVista
    {
        public AlumnosVista()
        {
            Sexo = new ComboBox();
            TipoDocumento = new ComboBox();
            EstadoCivil = new ComboBox();
            persona = new Persona();
        }

        public int Id_Alumno { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(1, 99999999999999999, ErrorMessage = "*")]
        public int Id_Persona { get; set; }
        public string Nov_Apellido { get; set; }
        public string Nov_Nombre { get; set; }
        public string Cuil { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public IComboBox Sexo { get; set; }
        public string Nro_Documento { get; set; }
        public IComboBox TipoDocumento { get; set; }
        public IComboBox EstadoCivil { get; set; }
        public string Estado { get; set; }
        public IList<IAlumnos> ListaAlumno { get; set; }
        public IList<IPersona> ListaPersona { get; set; }
        public IPersona persona { get; set; }
    }
}
