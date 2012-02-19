using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ICondicionesCursoVista
    {
        IList<ICondicionCurso> CondicionesCursos { get; set; }
        int IdInstitucion { get; set; }
    }
}
