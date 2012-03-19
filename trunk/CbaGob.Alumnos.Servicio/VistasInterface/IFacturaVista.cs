using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Servicio.VistasInterface
{
    public interface IFacturaVista 
    {
        int IdFactura { get; set; }
        string NroFactura { get; set; }
        string Concepto { get; set; }
        string Accion { get; set; }
        IComboBox CondicionCurso { get; set; }
        IComboBox Institucion { get; set; }
        string Item { get; set; }
        decimal Monto { get; set; }
        string Descripcion { get; set; }
        IInstitucionVista Instituciones { get; set; }
        ICondicionesCursoVista Cursos { get; set; }
        ICondicionCursoVista Curso { get; set; }
        int Id_Condicion_Curso { get; set; }
        string NombreCurso { get; set; }
        string NombreInstitucion { get; set; }
        IPager Pager { get; set; }
    }
}
