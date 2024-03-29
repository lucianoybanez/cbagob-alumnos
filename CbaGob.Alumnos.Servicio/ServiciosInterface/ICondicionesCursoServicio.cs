﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface ICondicionesCursoServicio : IBaseServicio
    {
        ICondicionesCursoVista GetByInstitucionId(int IdInstitucion);
        ICondicionCursoVista GetForModificacion(int IdCondicionCurso);
        ICondicionCursoVista GetForAlta(int IdInstitucion);
        bool GuardarCondicionCurso(ICondicionCursoVista condicion);
        bool EliminarCondicionCurso(int IdCondicionCurso, string nroresolucion);
        bool CambiarEstadoCurso(int IdCondicion, int NuevoEstado);
        ICondicionesCursoVista BuscarCondiciones(string institucion, string nivel, string curso, string programa, string año);
        ICondicionesCursoVista BuscarCondiciones(int idInstitucion, string curso, string año, string programa);
    }
}
