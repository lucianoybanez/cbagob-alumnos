using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;


namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class InstitucionVista : IInstitucionVista
    {
        public int INST_ID { get; set; }

        [Required(ErrorMessage = "*")]
        public string INST_NOMBRE { get; set; }

        public bool INS_PROPIA { get; set; }

        [Required(ErrorMessage = "*")]
        public string ID_PROVINCIA { get; set; }
        [Required(ErrorMessage = "*")]
        public int ID_LOCALIDAD { get; set; }
        [Required(ErrorMessage = "*")]
        public int ID_CALLE { get; set; }
        [Required(ErrorMessage = "*")]
        public int INST_NRO { get; set; }
        public string INST_TELEFONO { get; set; }
        [Required(ErrorMessage = "*")]
        public int ID_DEPARTAMENTO { get; set; }
        [Required(ErrorMessage = "*")]
        public int ID_BARRIO { get; set; }
        public IList<IInstitucion> ListaInstituciones { get; set; }
        public IList<IProvincias> ListaProvincias { get; set; }
        public IList<ILocalidades> ListaLocalidades { get; set; }
        public IList<IDepartamentos> ListaDepartamento { get; set; }
        public IList<IBarrios> ListaBarrios { get; set; }
        public IList<ICalles> ListaCalles { get; set; }
    }
}
