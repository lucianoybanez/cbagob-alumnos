using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class CursosVista : ICursosVista
    {
        public CursosVista()
        {
            AreasTipoCursos = new ComboBox();
        }

        public int ID_CURSO { get; set; }
        [Range(1, 9999999999999999999, ErrorMessage = "*")]
        public int Id_Area_Tipo_Curso { get; set; }
        [Required(ErrorMessage = "*")]
        public string N_CURSO { get; set; }
        public string ESTADO { get; set; }
        [Required(ErrorMessage = "*")]
        public string NRORESOLUCION { get; set; }
        public IList<ICursos> ListaCursos { get; set; }
        public IComboBox AreasTipoCursos { get; set; }
    }
}
