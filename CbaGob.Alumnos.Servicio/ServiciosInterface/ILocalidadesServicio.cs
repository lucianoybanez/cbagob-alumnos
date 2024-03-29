﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.ServiciosInterface
{
    public interface ILocalidadesServicio
    {
        IList<ILocalidades> getTodasByDepartamento(int IdDepartamento);
        ILocalidades GetUno(int IdLocalidad);
    }
}
