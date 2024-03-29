﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IEquiposVista
    {
        IList<IEquipo> ListaEquipos { get; set; }
        int Id_Equipo { get; set; }
        string NombreEquipoBusqueda { get; set; }
        IPager Pager { get; set; }
    }
}
