using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

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
        }

       
        public int Id_Supervision { get; set; }
        public int Id_Grupo { get; set; }
        public int Id_Supervisor { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fec_Supervision { get; set; }
        public DateTime Hs_Supervision { get; set; }
        public string NombreInstitucion { get; set; }
        public string NombreCurso { get; set; }
        public string NombreGrupo { get; set; }
        public string NombrePersonaJuridica { get; set; }
        public IInstitucionVista Institucions { get; set; }
        public ICondicionesCursoVista Cursos { get; set; }
        public IGruposVista Grupos { get; set; }
        public ISupervisoresVista Supervisores { get; set; }
        public IGrupoVista Grupo { get; set; }
    }
}
