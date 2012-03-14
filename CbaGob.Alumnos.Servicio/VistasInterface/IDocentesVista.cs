using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IDocentesVista
    {
        DateTime FechaAlta { get; set; }
        string UsuarioAlta { get; set; }
        DateTime FechaModificacion { get; set; }
        string UsuarioModificacion { get; set; }
        int Id_Docente { get; set; }
        int Id_Cargo { get; set; }
        IComboBox cargos { get; set; }
        string N_Modalidad { get; set; }
        string Razon_Social { get; set; }
        string Estado { get; set; }
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
        IList<IDocentes> ListaDocentes { get; set; }        
        string DatosCompletosDomicilio { get; set; }
        IComboBox TiposDocentes { get; set; }
        string Resolucion_Reproca { get; set; }
        string RazonSocialBusqueda { get; set; }
        string CuilCuitBusqueda { get; set; }
        IPager Pager { get; set; }
    }
}
