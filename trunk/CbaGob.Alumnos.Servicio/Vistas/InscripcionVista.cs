using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class InscripcionVista : IInscripcionVista
    {
        public int Id_Inscipcion { get; set; }
        public int Id_Alumno { get; set; }
        public int Id_Grupo { get; set; }
        public DateTime Fecha { get; set; }
        public string Nov_Apellido { get; set; }
        public string Nov_Nombre { get; set; }
        public string Cuil { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Nro_Documento { get; set; }
        public string Nombre_Curso { get; set; }
        public string Nombre_Grupo { get; set; }
        public string Descripcion { get; set; }
        public IList<ICondicionCurso> ListaCondicionCurso { get; set; }
        public IList<IAlumnos> ListaAlumnos { get; set; }
        public IList<IGrupo> ListaGrupo { get; set; }
        public IList<IInstitucion> ListaInstitucion { get; set; }
    }
}
