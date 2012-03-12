using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class SupervicionVista : ISupervicionVista
    {

        public SupervicionVista()
        {
            Institucions = new InstitucionVista();
            Cursos = new CondicionesCursoVista();
            Grupos = new GruposVista();
            Grupo = new GrupoVista();
            supervisor = new Buscador();
        }

        public int Id_Supervision { get; set; }

        public int Id_Grupo { get; set; }
        [Range(1, 999999999999999999)]
        public int Id_Supervisor { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fec_Supervision { get; set; }
        public string Hs_Supervision { get; set; }
        public string NombreInstitucion { get; set; }
        public string NombreCurso { get; set; }
        public string NombreGrupo { get; set; }
        public string NombrePersonaJuridica { get; set; }
        public IInstitucionVista Institucions { get; set; }
        public ICondicionesCursoVista Cursos { get; set; }
        public IGruposVista Grupos { get; set; }
        public ISupervisoresVista Supervisores { get; set; }
        public IGrupoVista Grupo { get; set; }
        public IBuscador supervisor { get; set; }
        [Range(1, 999999999999999999)]
        public int hora { get; set; }
        [Range(1, 999999999999999999)]
        public int minuto { get; set; }

        public string Nro_resolucion { get; set; }
    }
}
