using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class CursosVista : ICursosVista
    {
        public int ID_CURSO { get; set; }
        public string N_CURSO { get; set; }
        public string ESTADO { get; set; }
        public IList<ICursos> ListaCursos { get; set; }
    }
}
