using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
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
        int Id_PersonaJuridica { get; set; }
        int Id_Domicilio { get; set; }
        int Id_Cargo { get; set; }
        IComboBox cargos { get; set; }
        string N_Modalidad { get; set; }
        int Id_PersonaJur { get; set; }
        int Id_Sede { get; set; }
        string Cuit { get; set; }
        string Razon_Social { get; set; }
        string Estado { get; set; }
        string Planta { get; set; }
        string Reproca { get; set; }
        IList<IDocentes> ListaDocentes { get; set; }
        IList<IPersonaJuridica> ListaPersonaJuridica { get; set; }
        IList<IDomicilios> ListaDomicilios { get; set; }
        IDomicilios domicilios { get; set; }
        IPersonaJuridica personajuridica { get; set; }
        IBuscador BuscadorDomicilio { get; set; }
        IBuscador BuscadorPersonaJur { get; set; }
        string DatosCompletosPerJur { get; set; }
        string DatosCompletosDomicilio { get; set; }
    }
}
