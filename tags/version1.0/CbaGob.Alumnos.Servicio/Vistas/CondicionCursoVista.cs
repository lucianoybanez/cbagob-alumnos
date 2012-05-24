using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class CondicionCursoVista : ICondicionCursoVista
    {
        public CondicionCursoVista()
        {
            Curso = new ComboBox();
            Nivel = new ComboBox();
            Modalidad = new ComboBox();
            Programa = new ComboBox();
            EstadoCurso = new ComboBox();
        }

        public int IdCondicionCurso { get; set; }
        public int IdInstitucion { get; set; }
        public string NombeInstitucion { get; set; }
        public IComboBox EstadoCurso { get; set; }
        public IComboBox Curso { get; set; }
        public IComboBox Nivel { get; set; }
        public IComboBox Modalidad { get; set; }
        public IComboBox Programa { get; set; }
        [DisplayName("Promedio Requerido (1 - 10):")]
        [Range(1, 10)]
        public decimal PromedioRequerido { get; set; }

        [DisplayName("Cantidad de Examenes (1 - 999):")]
        [Range(1, 999)]
        public int CantidadExamenes { get; set; }

        [DisplayName("Cantidad de Clases (1 - 999):")]
        [Range(1, 999)]
        public int CantidadClases { get; set; }

        [DisplayName("Presentismo (1% - 100%):")]
        [Range(1, 100)]
        public int Presentismo { get; set; }

        [DisplayName("Carga Horaria (1 - 9999hs.):")]
        [Range(1, 9999)]
        public int CargaHoraria { get; set; }

        [DisplayName("Cupo (1 - 9999):")]
        [Range(1, 9999)]
        public int Cupo { get; set; }

        [DisplayName("Presupuesto ($1 - $99999):")]
        [Range(1, 99999)]
        public decimal Presupuesto { get; set; }
        public string Accion { get; set; }
        public string NombrePrograma { get; set; }
        public string NombreEstadoCurso { get; set; }
        public string NombreCurso { get; set; }
        public string NombreNivel { get; set; }
        public string NombreModalidad { get; set; }
        public IList<IGrupo> ListaGrupos { get; set; }
        public IList<IAlumnos> ListaAlumno { get; set; }
        [Required]
        public DateTime Fecha_Inicio { get; set; }
        [Required]
        public DateTime Fecha_Fin { get; set; }
        [Required(ErrorMessage = "*")]
        public string Nro_Resolucion { get; set; }
    }
}