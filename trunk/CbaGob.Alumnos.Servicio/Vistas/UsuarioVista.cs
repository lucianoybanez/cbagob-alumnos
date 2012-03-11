using System.Collections.Generic;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.Vistas
{
    public class UsuarioVista : IUsuarioVista
    {
        public int idUsuario { get; set; }
        public string Accion { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string password { get; set; }
        public IComboBox Roles { get; set; }
        public IList<IUsuario> Usuarios { get; set; }
        public IPager pager { get; set; }
    }
}