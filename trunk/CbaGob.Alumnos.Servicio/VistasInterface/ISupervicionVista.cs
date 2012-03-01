using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ISupervicionVista
    {
        int Id_Supervision { get; set; }
        int Id_Grupo { get; set; }
        int Id_Supervisor { get; set; }
        String Observaciones { get; set; }
        System.DateTime Fec_Supervision { get; set; }
        System.DateTime Hs_Supervision { get; set; }
        string NombreInstitucion { get; set; }
        string NombreCurso { get; set; }
        string NombreGrupo { get; set; }
        string NombrePersonaJuridica { get; set; }
        IInstitucionVista Institucions { get; set; }
        ICondicionesCursoVista Cursos { get; set; }
        IGruposVista Grupos { get; set; }
        ISupervisoresVista Supervisores { get; set; }
        IGrupoVista Grupo { get; set; }
        IBuscador supervisor { get; set; }
        int hora { get; set; }
        int minuto { get; set; }
    }
}
