﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface IDomiciliosServicios
    {
        IList<IDomicilios> GetTodosDomicilios();
        IDomicilios GetUno(int id_domicilio);
    }
}
