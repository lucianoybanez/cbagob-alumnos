﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IInscripcionServicio : IBaseServicio
    {
        IInscripcionesVista GetAllInscripcion();
        IInscripcionesVista GetAllInscripcionByAlumno(int id_alumno);
        IInscripcionVista GetInscripcion(int id_inscripcion);
        bool AgregarInscripcion(IInscripcionVista inscripcion);
        bool ModificarInscripcion(IInscripcionVista inscripcion);
        bool EliminarInscripcion(int id_inscripcion);
    }
}