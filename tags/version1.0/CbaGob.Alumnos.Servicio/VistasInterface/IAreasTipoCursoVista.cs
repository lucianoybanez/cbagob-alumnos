using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IAreasTipoCursoVista
    {
        IList<IAreaTipoCurso> ListaAreaTipoCurso { get; set; }
        IPager Pager { get; set; }
    }
}
