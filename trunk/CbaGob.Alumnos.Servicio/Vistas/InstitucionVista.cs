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
    public class InstitucionVista : IInstitucionVista
    {
        public InstitucionVista()
        {
            domicilios = new Domicilios();
            DomicilioBusqueda = new Buscador();

        }
        public int Id_Institucion { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(1, 99999999999999999, ErrorMessage = "*")]
        public int Id_Domicilio { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nombre_Institucion { get; set; }
        public bool espropia { get; set; }
        public string DireccionCompleta { get; set; }
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
        [Required(ErrorMessage = "*")]
        public string Nro_Resolucion { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Expediente { get; set; }
        public IList<IInstitucion> ListaInstituciones { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public IDomicilios domicilios { get; set; }
        public IBuscador DomicilioBusqueda { get; set; }
        public IList<IEstablecimiento> ListaEstablecimiento { get; set; }
        public IList<ICondicionCurso> CondicionesCursos { get; set; }
        public ICajaChicasVista CajaChica { get; set; }
    }
}
