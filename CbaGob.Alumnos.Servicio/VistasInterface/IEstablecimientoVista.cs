﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IEstablecimientoVista
    {
        int Id_Establecimiento { get; set; }
        int Id_Institucion { get; set; }
        int Id_Domicilio { get; set; }
        string N_Establecimiento { get; set; }

        string Provincia { get; set; }
        string Localidad { get; set; }
        string Barrio { get; set; }
        string Calle { get; set; }
        string Nro { get; set; }

        IList<IDomicilios> ListaDomicilio { get; set; }
    }
}
