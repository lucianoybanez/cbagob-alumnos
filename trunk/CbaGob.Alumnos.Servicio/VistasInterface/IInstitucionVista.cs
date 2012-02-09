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
        int ID_INSTITUCION { get; set; }
        int ID_DOMICILIO { get; set; }
        string N_INSTITUCION { get; set; }
        bool INS_PROPIA { get; set; }
        IList<IInstitucion> ListaInstituciones { get; set; }
        string DOMICILIO { get; set; }
        DateTime FechaAlta { get; set; }
        string UsuarioAlta { get; set; }
        DateTime FechaModificacion { get; set; }
        string UsuarioModificacion { get; set; }
    }
}
