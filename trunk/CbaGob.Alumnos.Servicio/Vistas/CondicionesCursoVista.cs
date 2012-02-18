using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class CondicionesCursoVista : ICondicionesCursoVista
    {
        public IList<ICondicionCurso> CondicionesCursos { get; set; }
    }
}