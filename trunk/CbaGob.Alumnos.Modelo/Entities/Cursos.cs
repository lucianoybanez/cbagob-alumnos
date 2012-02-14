using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Cursos : ICursos
    {
        public int ID_CURSO { get; set; }
        public string N_CURSO { get; set; }
        public string ESTADO { get; set; }
        public int NRORESOLUCION { get; set; }
    }
}
