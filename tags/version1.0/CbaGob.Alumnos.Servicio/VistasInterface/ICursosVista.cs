using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface ICursosVista
    {
        int ID_CURSO { get; set; }
        int Id_Area_Tipo_Curso { get; set; }
        string N_CURSO { get; set; }
        string ESTADO { get; set; }
        string NRORESOLUCION { get; set; }
        IList<ICursos> ListaCursos { get; set; }
        IComboBox AreasTipoCursos { get; set; }
        IPager Pager { get; set; }
    }
}
