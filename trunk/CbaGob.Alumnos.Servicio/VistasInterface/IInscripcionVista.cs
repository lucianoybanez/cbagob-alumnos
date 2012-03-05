﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IInscripcionVista
    {
        string Accion { get; set; }
        int IdCondicionCurso { get; set; }
        int IdInscripcion { get; set; }
        string Descripcion { get; set; }
        DateTime Fecha { get; set; }

        string NombreInstitucion { get; set; }
        string NombreEstadoCurso { get; set; }

        string  NombreCurso { get; set; }

        string NombreNivel { get; set; }

        string NombreModalidad { get; set; }

        string NombrePrograma { get; set; }

        int IdAlumno { get; set; }
        string NombreAlumno { get; set; }

        IList<IExamen> examens { get; set; }  
    }
}