using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IInscripcionVista
    {
        int Id_Inscipcion { get; set; }
        int Id_Alumno { get; set; }
        int Id_Grupo { get; set; }
        System.DateTime Fecha { get; set; }
        string Nov_Apellido { get; set; }
        string Nov_Nombre { get; set; }
        string Cuil { get; set; }
        DateTime Fecha_Nacimiento { get; set; }
        string Nro_Documento { get; set; }
        string Nombre_Curso { get; set; }
        string Nombre_Grupo { get; set; }
        string Descripcion { get; set; }
        IList<ICondicionCurso> ListaCondicionCurso { get; set; }
        IList<IAlumnos> ListaAlumnos { get; set; }
        IList<IGrupo> ListaGrupo { get; set; }
        IList<IInstitucion> ListaInstitucion { get; set; }
    }
}
