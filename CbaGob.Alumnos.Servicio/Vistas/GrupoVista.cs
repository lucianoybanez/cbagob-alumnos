using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class GrupoVista : IGrupoVista
    {
        public GrupoVista()
        {
            BuscadorEstablecimientos = new Buscador();
        }

        public int Id_Grupo { get; set; }
        public int Id_Condicion_Curso { get; set; }
        [Range(1, 9999999999999999999)]
        public int Id_Establecimiento { get; set; }
        public int Id_Docente { get; set; }
        public int Id_Horario { get; set; }
        public int Id_Institucion { get; set; }

        [Required(ErrorMessage = "*")]
        public int Capacidad { get; set; }
        [Required(ErrorMessage = "*")]
        public string NombreGrupo { get; set; }
        public string NombreEstablecimiento { get; set; }
        public int Id_Domicilio { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Barrio { get; set; }
        public string Calle { get; set; }
        public string Nro { get; set; }
        public int Id_PersonaJuridica { get; set; }
        public string Cuit { get; set; }
        public string RazonSoial { get; set; }
        public DateTime Hr_Inicio { get; set; }
        public DateTime Hr_Fin { get; set; }
        public string Hr_DiaSemana { get; set; }
        public string Hr_Año { get; set; }
        public string Hr_Mes { get; set; }

        public IList<IDocentes> ListaDocentes { get; set; }
        public IList<IEstablecimiento> ListaEstableimiento { get; set; }
        public IList<IAlumnos> ListaAlumnos { get; set; }
        public IList<IAlumnos> ListaAlumnosInGrupo { get; set; }

        public string Nombre_Institucion { get; set; }
        public string Nombre_Curso { get; set; }
        public IBuscador BuscadorEstablecimientos { get; set; }

        public IList<IDocentes> ListaDocentesNoGrupo { get; set; }
        public IList<IDocentes> ListaDocentesInGrupo { get; set; }

    }
}
