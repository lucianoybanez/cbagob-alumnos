﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IEquipoServicio : IBaseServicio
    {
        IEquiposVista GetEquipos();
        IEquiposVista GetEquipos(IPager Pager);
        IEquiposVista GetEquiposByEstado(int id_estado_equipo);
        IEquipoVista GetEquipo(int id_equipo);
        IEquipoVista GetForAlta();
        bool AgregarEquipo(IEquipoVista equipo);
        bool ModificarEquipo(IEquipoVista equipo);
        bool EliminarEquipo(int id_equipo);
        IEquiposVista BusquedaEquipo(string nombreequipo);
        IEquiposVista BusquedaEquipo(string nombreequipo, IPager Pager);
    }
}
