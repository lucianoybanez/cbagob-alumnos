using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class AreasTipoCursoVista : IAreasTipoCursoVista
    {
        public IList<IAreaTipoCurso> ListaAreaTipoCurso { get; set; }
        public IPager Pager { get; set; }
    }
}
