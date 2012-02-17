using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class DocentesVista : IDocentesVista
    {
        public DocentesVista()
        {
            cargos = new ComboBox();
            domicilios = new Domicilios();
            personajuridica = new PersonaJuridica();
        }

        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int Id_Docente { get; set; }
        public int Id_PersonaJuridica { get; set; }
        public int Id_Domicilio { get; set; }
        public int Id_Cargo { get; set; }
        public IComboBox cargos { get; set; }
        public string N_Modalidad { get; set; }
        public int Id_PersonaJur { get; set; }
        public int Id_Sede { get; set; }
        public string Cuit { get; set; }
        public string Razon_Social { get; set; }
        public string Estado { get; set; }
        public IList<IDocentes> ListaDocentes { get; set; }
        public IList<IPersonaJuridica> ListaPersonaJuridica { get; set; }
        public IList<IDomicilios> ListaDomicilios { get; set; }
        public IDomicilios domicilios { get; set; }
        public IPersonaJuridica personajuridica { get; set; }
    }
}
