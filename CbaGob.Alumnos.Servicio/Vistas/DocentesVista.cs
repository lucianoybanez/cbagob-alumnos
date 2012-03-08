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
    public class DocentesVista : IDocentesVista
    {
        public DocentesVista()
        {
            cargos = new ComboBox();
            TiposDocentes = new ComboBox();
        }

        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int Id_Docente { get; set; }

        [Range(1, 9999999999999999999, ErrorMessage = "*")]
        public int Id_Cargo { get; set; }
        public IComboBox cargos { get; set; }
        [Required(ErrorMessage = "*")]
        public string N_Modalidad { get; set; }
        [Required(ErrorMessage = "*")]
        public string Razon_Social { get; set; }
        public string Estado { get; set; }
        public string Planta { get; set; }
        [Required(ErrorMessage = "*")]
        public string Reproca { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Barrio { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        [Required(ErrorMessage = "*")]
        public string Cuit_Cuil { get; set; }
        [Required(ErrorMessage = "*")]
        public string RazonSoial { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Resolucion { get; set; }
        [Required(ErrorMessage = "*")]
        public string Dni { get; set; }
        [Range(1, 9999999999999999999, ErrorMessage = "*")]
        public int id_tipo_docente { get; set; }
        public string NombreTipoDocente { get; set; }
        public IList<IDocentes> ListaDocentes { get; set; }
        public string DatosCompletosDomicilio { get; set; }
        public IComboBox TiposDocentes { get; set; }
        [Required(ErrorMessage = "*")]
        public string Resolucion_Reproca { get; set; }
    }
}
