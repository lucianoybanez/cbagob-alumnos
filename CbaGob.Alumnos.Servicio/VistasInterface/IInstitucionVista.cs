using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IInstitucionVista
    {
        int Id_Institucion { get; set; }
        string Nombre_Institucion { get; set; }
        bool espropia { get; set; }
        string DireccionCompleta { get; set; }
        string Provincia { get; set; }
        string Localidad { get; set; }
        string Barrio { get; set; }
        string Calle { get; set; }
        int Nro { get; set; }
        int Depto { get; set; }
        string Nro_Resolucion { get; set; }
        string Nro_Expediente { get; set; }
        IList<IInstitucion> ListaInstituciones { get; set; }
        DateTime FechaAlta { get; set; }
        string UsuarioAlta { get; set; }
        DateTime FechaModificacion { get; set; }
        string UsuarioModificacion { get; set; }
        IList<IEstablecimiento> ListaEstablecimiento { get; set; }
        IList<ICondicionCurso> CondicionesCursos { get; set; }
        ICajaChicasVista CajaChica { get; set; }
        string Nombre_InstitucionBusqueda { get; set; }

        string cursobusqueda { get; set; }
        string añobuscqueda { get; set; }
        string NombreSede { get; set; }
        IPager pager { get; set; }
        string Telefono { get; set; }

    }
}
