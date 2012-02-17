using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.VistasInterface;


namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class InstitucionVista : IInstitucionVista
    {
        public InstitucionVista()
        {
            domicilios = new Domicilios();
        }

        public int ID_INSTITUCION { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(1, 99999999999999999, ErrorMessage = "*")]
        public int ID_DOMICILIO { get; set; }

        [Required(ErrorMessage = "*")]
        public string N_INSTITUCION { get; set; }

        public bool INS_PROPIA { get; set; }
        public IList<IInstitucion> ListaInstituciones { get; set; }
        public string DOMICILIO { get; set; }
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public IList<IDomicilios> ListaDomicilios { get; set; }
        public IDomicilios domicilios { get; set; }
    }
}
