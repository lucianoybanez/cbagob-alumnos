using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IGrupoVista
    {
        int Id_Grupo { get; set; }
        int Id_Condicion_Curso { get; set; }
        int Id_Establecimiento { get; set; }
        int Id_Docente { get; set; }
        int Id_Horario { get; set; }
        int Id_Institucion { get; set; }
        int Capacidad { get; set; }
        string NombreGrupo { get; set; }

        string NombreEstablecimiento { get; set; }
        int Id_Domicilio { get; set; }
        string Provincia { get; set; }
        string Localidad { get; set; }
        string Barrio { get; set; }
        string Calle { get; set; }
        string Nro { get; set; }

        int Id_PersonaJuridica { get; set; }
        string Cuit { get; set; }
        string RazonSoial { get; set; }

        System.DateTime Hr_Inicio { get; set; }
        System.DateTime Hr_Fin { get; set; }
        string Hr_DiaSemana { get; set; }
        string Hr_Año { get; set; }
        string Hr_Mes { get; set; }

        IList<IDocentes> ListaDocentes { get; set; }
        IList<IDocentes> ListaDocentesNoGrupo { get; set; }
        IList<IDocentes> ListaDocentesInGrupo { get; set; }
        IList<IEstablecimiento> ListaEstableimiento { get; set; }
        IList<IAlumnos> ListaAlumnos { get; set; }
        IList<IAlumnos> ListaAlumnosInGrupo { get; set; }

        string Nombre_Institucion { get; set; }
        string Nombre_Curso { get; set; }

        IBuscador BuscadorEstablecimientos { get; set; }

    }
}
