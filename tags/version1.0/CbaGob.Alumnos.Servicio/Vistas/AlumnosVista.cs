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
        public string Nombre { get; set; }
        [Required(ErrorMessage = "*")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Documento { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        [Required(ErrorMessage = "*")]
        public string Cuil { get; set; }
        public int Id_Tipo_Dni { get; set; }
        public int Id_Tipo_Estado_Civil { get; set; }
        public int Id_Tipo_Sexo { get; set; }
        public string TipoSexo { get; set; }
        public string TipoEstadoCivil { get; set; }
        public string Tipo_Dni { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Resolucion { get; set; }
        public IComboBox Sexo { get; set; }
        public IComboBox TipoDocumento { get; set; }
        public IComboBox EstadoCivil { get; set; }
        public IList<IAlumnos> ListaAlumno { get; set; }
        public IList<IPersona> ListaPersona { get; set; }
        public IPersona persona { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Telefono { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Celular { get; set; }

        public string NombreBusqueda { get; set; }
        public string ApellidoBusqueda { get; set; }
        public string DniBusqueda { get; set; }
        public string CuilBusqueda { get; set; }
        public IPager Pager { get; set; }
        [Required(ErrorMessage = "*")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "*")]
        public string Localidad { get; set; }
        [Required(ErrorMessage = "*")]
        public string Barrio { get; set; }
        [Required(ErrorMessage = "*")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "*")]
        public int Nro { get; set; }
        [Required(ErrorMessage = "*")]
        public int Depto { get; set; }
    }
}
