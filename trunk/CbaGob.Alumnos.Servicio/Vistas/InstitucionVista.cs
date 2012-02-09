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

        
        public string INST_NOMBRE { get; set; }
        public bool INS_PROPIA { get; set; }
        public string ID_PROVINCIA { get; set; }
        public int ID_LOCALIDAD { get; set; }
        public int ID_CALLE { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "*")]
        public int INST_NRO { get; set; }

        public string INST_TELEFONO { get; set; }

        
        public int ID_DEPARTAMENTO { get; set; }

        public int ID_BARRIO { get; set; }
        public IList<IInstitucion> ListaInstituciones { get; set; }
        public IList<IProvincias> ListaProvincias { get; set; }
        public IList<ILocalidades> ListaLocalidades { get; set; }
        public IList<IDepartamentos> ListaDepartamento { get; set; }
        public IList<IBarrios> ListaBarrios { get; set; }
        public IList<ICalles> ListaCalles { get; set; }
        public string PROVINCIA { get; set; }
        public string BARRIO { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string LOCALIDAD { get; set; }
        public string CALLE { get; set; }
    }
}
