using System;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;

namespace CbaGob.Alumnos.Modelo.Entities
{
    public class Presentismo : IPresentismo
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public int IdPresentismo { get; set; }
        public int IdInscripcion { get; set; }
        public int ClasesAsistidas { get; set; }
        public decimal PorcentajePresentismo { get; set; }
    }
}