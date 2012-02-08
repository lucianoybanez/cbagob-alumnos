using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IInstitucionVista
    {
        int INST_ID { get; set; }
        string INST_NOMBRE { get; set; }
        bool INS_PROPIA { get; set; }
        string ID_PROVINCIA { get; set; }
        int ID_LOCALIDAD { get; set; }
        int ID_CALLE { get; set; }
        int INST_NRO { get; set; }
        string INST_TELEFONO { get; set; }
        int ID_DEPARTAMENTO { get; set; }
        int ID_BARRIO { get; set; }
        IList<IInstitucion> ListaInstituciones { get; set; }
        IList<IProvincias> ListaProvincias { get; set; }
        IList<ILocalidades> ListaLocalidades { get; set; }
        IList<IDepartamentos> ListaDepartamento { get; set; }
        IList<IBarrios> ListaBarrios { get; set; }
        IList<ICalles> ListaCalles { get; set; }
    }
}
