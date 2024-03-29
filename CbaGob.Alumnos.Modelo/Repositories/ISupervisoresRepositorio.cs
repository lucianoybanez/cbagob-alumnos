﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Repositories
{
    public interface ISupervisoresRepositorio
    {
        IList<ISupervisores> GetSupervisores();
        IList<ISupervisores> GetSupervisores(int skip, int take);
        int GetCountSupervisor();
        IList<ISupervisores> GetSupervisoresByRazonSocial(string razonsocial);
        ISupervisores GetSupervisor(int idsupervisor);
        bool AgregarSupervisor(ISupervisores supervisor);
        bool ModificarSupervisor(ISupervisores supervisor);
        bool EliminarSupervisor(int idsupervisor, string nro_resolucion);

    }
}
