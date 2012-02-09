using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ICursosVista
    {
        int ID_CURSO { get; set; }
        string N_CURSO { get; set; }
        string ESTADO { get; set; }
        IList<ICursos> ListaCursos { get; set; } 
    }
}
