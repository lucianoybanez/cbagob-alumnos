using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface ISuperviciones : IComunDatos
    {
        int Id_Supervision { get; set; }
        int Id_Grupo { get; set; }
        int Id_Supervisor { get; set; }
        String Observaciones { get; set; }
        System.DateTime Fec_Supervision { get; set; }
        string Hs_Supervision { get; set; }
        string NombreInstitucion { get; set; }
        string NombreCurso { get; set; }
        string NombreGrupo { get; set; }
        string NombrePersonaJuridica { get; set; }
    }
}
