namespace CbaGob.Alumnos.Modelo.Entities.Interfaces
{
    public interface IGrupo : IComunDatos
    {
        int Id_Grupo { get; set; }
        int Id_Condicion_Curso { get; set; }
        int Id_Establecimiento { get; set; }
        int Id_Docente { get; set; }
        int Id_Horario { get; set; }
        int Id_Institucion { get; set; }

        int Capacidad { get; set; }
        string NombreGrupo { get; set; }

        string NombreEstablecimiento { get; set; }
        int Id_Domicilio { get; set; }
        string Provincia { get; set; }
        string Localidad { get; set; }
        string Barrio { get; set; }
        string Calle { get; set; }
        int Nro { get; set; }

        int Id_PersonaJuridica { get; set; }
        string Cuit { get; set; }
        string RazonSoial { get; set; }

        System.DateTime Hr_Inicio { get; set; }
        System.DateTime Hr_Fin { get; set; }
        string Hr_DiaSemana { get; set; }
        string Hr_Año { get; set; }
        string Hr_Mes { get; set; }

        string Nombre_Curso { get; set; }
        string Nombre_Institucion { get; set; }

        string Nro_Resolucion { get; set; }




    }
}