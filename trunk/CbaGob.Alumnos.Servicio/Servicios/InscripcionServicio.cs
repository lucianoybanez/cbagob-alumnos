using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Modelo.Repositories;
using CbaGob.Alumnos.Repositorio;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Servicio.Servicios
{
    public class InscripcionServicio : BaseServicio, IInscripcionServicio
    {
        private IInscripcionRepositorio Inscripcionrepositorio;

        private ICondicionCursoRepositorio CondicionCursoRepositorio;

        private IAutenticacionServicio Aut;

        private IExamenServicio ExamenServicio;

        private IAlumnosRepositorio AlumnosRepositorio;

        private IInstitucionRepositorio InstitucionRepositorio;

        public InscripcionServicio(IInscripcionRepositorio inscripcionrepositorio, IAutenticacionServicio aut, ICondicionCursoRepositorio condicionCurso, IExamenServicio examenServicio, IAlumnosRepositorio alumnosRepositorio, IInstitucionRepositorio institucionRepositorio)
        {
            Inscripcionrepositorio = inscripcionrepositorio;
            Aut = aut;
            CondicionCursoRepositorio = condicionCurso;
            ExamenServicio = examenServicio;
            AlumnosRepositorio = alumnosRepositorio;
            InstitucionRepositorio = institucionRepositorio;
        }

        public IInscripcionesVista GetAllInscripcion()
        {
            IInscripcionesVista inscripcionesvista = new InscripcionesVista();
            var pager = new Pager(Inscripcionrepositorio.GetAllInscripcion(), 3, "FormIndexInscripciones", Aut.GetUrl("IndexPager", "Inscripciones"));
            inscripcionesvista.pager = pager;
            inscripcionesvista.ListaInscripciones = Inscripcionrepositorio.GetAllInscripcion(pager.Skip, pager.PageSize);
            return inscripcionesvista;
        }

        public IInscripcionesVista GetAllInscripcion(IPager pager)
        {
            IInscripcionesVista inscripcionesvista = new InscripcionesVista();
            inscripcionesvista.pager = pager;
            inscripcionesvista.ListaInscripciones = Inscripcionrepositorio.GetAllInscripcion(pager.Skip, pager.PageSize);
            return inscripcionesvista;
        }

        public IInscripcionesVista GetAllInscripcionByAlumno(int id_alumno)
        {
            try
            {
                IInscripcionesVista inscripcionesvista = new InscripcionesVista();

                IList<IInscripcion> ListaInscripcion = Inscripcionrepositorio.GetAllInscripcionByAlumno(id_alumno);

                inscripcionesvista.ListaInscripciones = ListaInscripcion;

                return inscripcionesvista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IInscripcionVista GetInscripcion(int id_inscripcion)
        {
            IInscripcionVista vista = new InscripcionVista();

            if (id_inscripcion != 0)
            {
                var inscripcion = Inscripcionrepositorio.GetInscripcion(id_inscripcion);
                if (inscripcion != null)
                {
                    var condicion = CondicionCursoRepositorio.GetCondicion(inscripcion.Id_Condicion_Curso);
                    vista = new InscripcionVista()
                    {
                        Descripcion = inscripcion.Descripcion,
                        Fecha = inscripcion.Fecha,
                        IdAlumno = inscripcion.Id_Alumno,
                        IdCondicionCurso = inscripcion.Id_Condicion_Curso,
                        IdInscripcion = inscripcion.IdInscripcion,
                        NombreAlumno = inscripcion.ApellidoAlumno + ", " + inscripcion.NombreAlumno,
                        NombreCurso = inscripcion.NombreCurso,
                        NombreEstadoCurso = inscripcion.NombreEstadoCurso,
                        NombreInstitucion = inscripcion.NombreInstitucion,
                        NombreModalidad = inscripcion.NombreModalidad,
                        NombreNivel = inscripcion.NombreNivel,
                        NombrePrograma = inscripcion.NombrePrograma,
                        FechaFin = inscripcion.FechaFin,
                        FechaInicio = inscripcion.FechaIncio,
                        NumeroResolucion = inscripcion.NroResolucion,
                        Presentismo = GetPresentismo(id_inscripcion, condicion),
                        examens = GetExamenes(id_inscripcion, condicion)
                    };
                }
            }
            return vista;
        }

        public bool AgregarInscripcion(IInscripcionVista vista)
        {
            if (vista.IdCondicionCurso != 0)
            {
                if (vista.IdAlumno != 0)
                {
                    IInscripcion inscripcion = new Inscripcion();
                    inscripcion.Id_Condicion_Curso = vista.IdCondicionCurso;
                    inscripcion.Id_Alumno = vista.IdAlumno;
                    inscripcion.Fecha = vista.Fecha;
                    inscripcion.Descripcion = vista.Descripcion;

                    bool result = false;
                    var inscripcionModelo = Inscripcionrepositorio.GetInscripcion(inscripcion.Id_Condicion_Curso, inscripcion.Id_Alumno);
                    if (inscripcionModelo != null)
                    {
                        inscripcion.IdInscripcion = inscripcionModelo.IdInscripcion;
                        result = Inscripcionrepositorio.ModificarInscripcion(inscripcion);
                    }
                    else
                    {
                        result = Inscripcionrepositorio.AgregarInscripcion(inscripcion);
                    }
                    if (!result)
                    {
                        base.AddError("Ocurrio un Error al agregar la Inscripcion. Verifique q no fue Inscripto anteriormente.");
                    }
                    return result;
                }
                else
                {
                    base.AddError("Debe Seleccionar un Alumno");
                }
            }
            else
            {
                base.AddError("Debe Seleccionar un Curso asginado a una Institucion");
            }
            return false;


        }

        public bool ModificarInscripcion(IInscripcionVista inscripcion)
        {

            //return Inscripcionrepositorio.ModificarInscripcion(inscripcion);
            return true;
        }

        public bool EliminarInscripcion(int id_inscripcion)
        {
            bool result = Inscripcionrepositorio.EliminarInscripcion(id_inscripcion);

            if (!result)
            {
                base.AddError("Ocurrio un error al Eliminar la Inscripcion");
            }

            return result;

        }

        public bool GuardarPresentismo(InscripcionPresentismoVista vista)
        {
            var inscripcion = Inscripcionrepositorio.GetInscripcion(vista.IdInscripcion);
            var condicion = CondicionCursoRepositorio.GetCondicion(inscripcion.Id_Condicion_Curso);
            int maxClases = condicion.CantidadClases;

            if (vista.ClasesAsistidas <= maxClases)
            {
                IPresentismo presentismo = new Presentismo()
                                          {
                                              ClasesAsistidas = vista.ClasesAsistidas,
                                              IdInscripcion = vista.IdInscripcion,
                                          };
                bool result = false;

                var dataPresentismo = Inscripcionrepositorio.GetPresentismo(vista.IdInscripcion);
                if (dataPresentismo != null)
                {
                    presentismo.IdPresentismo = dataPresentismo.IdPresentismo;
                    result = Inscripcionrepositorio.ModificarPresentismo(presentismo);
                }
                else
                {
                    result = Inscripcionrepositorio.GuardarPresentismo(presentismo);
                }
                if (!result)
                {
                    base.AddError("Ocurrio un Error al guardar el Presentismo.");
                }
                return result;
            }
            else
            {
                base.AddError("La Cantidad de clases asistidas tiene q estar entre 0 y " + maxClases + ".");
                return false;
            }


        }

        public IInscripcionPresentismoVista GetPresentismo(int idInscripcion)
        {
            var presentismo = Inscripcionrepositorio.GetPresentismo(idInscripcion);
            var inscripcion = Inscripcionrepositorio.GetInscripcion(idInscripcion);
            var condicion = CondicionCursoRepositorio.GetCondicion(inscripcion.Id_Condicion_Curso);
            int maxClases = condicion.CantidadClases;

            IInscripcionPresentismoVista vista = new InscripcionPresentismoVista();
            vista.CumplioPresentismo = "Debe cargar la cantidad de clases q asistio.";
            if (presentismo != null)
            {
                vista.ClasesAsistidas = presentismo.ClasesAsistidas;
                vista.IdPresentismo = presentismo.IdPresentismo;
                vista.IdInscripcion = presentismo.IdInscripcion;
                vista.TotalClasesCurso = maxClases;
                vista.PresentismoNecesario = condicion.Presentismo;
                if (vista.PorcentajePresentismo >= vista.PresentismoNecesario)
                {
                    vista.CumplioPresentismo = "Si Cumplio.";
                }
                else
                {
                    vista.CumplioPresentismo = "No Cumplio.";
                }
            }

            return vista;
        }

        private IInscripcionPresentismoVista GetPresentismo(int idInscripcion, ICondicionCurso condicion)
        {
            var presentismo = Inscripcionrepositorio.GetPresentismo(idInscripcion);
            int maxClases = condicion.CantidadClases;
            IInscripcionPresentismoVista vista = new InscripcionPresentismoVista();
            vista.TotalClasesCurso = maxClases;
            vista.PresentismoNecesario = condicion.Presentismo;
            vista.CumplioPresentismo = "Debe cargar la cantidad de clases q asistio.";
            if (presentismo != null)
            {
                vista.ClasesAsistidas = presentismo.ClasesAsistidas;
                vista.IdPresentismo = presentismo.IdPresentismo;
                vista.IdInscripcion = presentismo.IdInscripcion;
                if (vista.PorcentajePresentismo >= vista.PresentismoNecesario)
                {
                    vista.CumplioPresentismo = "Si Cumplio.";
                }
                else
                {
                    vista.CumplioPresentismo = "No Cumplio.";
                }
            }

            return vista;
        }

        public IInscripcionesVista GetAllInscripcionBy(string nombre, string apellido, string dni, string institucion)
        {
            IInscripcionesVista vista = new InscripcionesVista();
            vista.ListaInscripciones = Inscripcionrepositorio.GetAllInscripcionBy(nombre, apellido, dni, institucion);

            return vista;
        }

        public IInscripcionExamenVista GetExamenes(int idInscripcion)
        {
            return null;
        }

        public ICertificadoVista GetCertificado(int idInscripcion)
        {
            var inscripcion = Inscripcionrepositorio.GetInscripcion(idInscripcion);
            var condicion = CondicionCursoRepositorio.GetCondicion(inscripcion.Id_Condicion_Curso);
            var alumno = AlumnosRepositorio.GetUno(inscripcion.Id_Alumno);
            ICertificadoVista vista = new CertificadoVista();
            StringBuilder texto = new StringBuilder();
            texto.Append("Por cuanto: '" + inscripcion.ApellidoAlumno + ", " + inscripcion.NombreAlumno + "' documento Nº " + alumno.Nro_Documento);
            texto.Append(", ha aprobado el curso de capacitación en la especialidad de '" + inscripcion.NombreCurso + "'");
            texto.Append(", dictado en la institucion: '" + inscripcion.NombreInstitucion + "'");
            texto.Append(", perteneciente a la Agencia de Promocion y Formación de empleo");
            texto.Append(", con la duracion de " + condicion.CargaHoraria + " horas reloj");
            texto.Append(", aprobado por la resolucion Nº " + condicion.Nro_Resolucion + ".");
            vista.Texto = texto.ToString();
            vista.Fecha = DateTime.Today;
            return vista;
        }

        public IReporteVista GetReporteEgresados(int idCondicionCurso)
        {
            IReporteVista vista = new ReporteVista();

            var Condicion = CondicionCursoRepositorio.GetCondicion(idCondicionCurso);
            if (Condicion != null)
            {
                var institucion = InstitucionRepositorio.GetInstitucion(Condicion.IdInstitucion);
                if (institucion!=null)
                {
                    var repoModel = Inscripcionrepositorio.GetAllInscripcionBy(idCondicionCurso);
                    int totalVarones = 0;
                    int totalMujeres = 0;
                    decimal asistencia = 0;
                    decimal notaFinal = 0;
                    bool aprobo = false;

                    vista.Expediente = institucion.Nro_Expediente;
                    vista.Fecha = DateTime.Today;
                    vista.NombreCurso = Condicion.NombreCurso;
                    vista.NombreInstitucion = Condicion.NombeInstitucion;
                    vista.Resolucion = Condicion.Nro_Resolucion;

                    foreach (var item in repoModel)
                    {

                        // Contador varones y mujeres
                        if (item.Sexo == 1)
                        {
                            totalVarones += 1;
                        }
                        else
                        {
                            totalMujeres += 1;
                        }

                        //Asistencia
                        try
                        {
                            decimal valor1 = decimal.Divide(item.ClasesAsistidas, Condicion.CantidadClases);
                            decimal valor = valor1 * 100;
                            asistencia = decimal.Round(valor);
                        }
                        catch (Exception)
                        {

                            asistencia = 0;
                        }

                        // Promedio Alumno
                        try
                        {
                            notaFinal = decimal.Divide(item.Notas, Condicion.CantidadExamenes);
                        }
                        catch
                        {
                            notaFinal = 0;
                        }

                        //Aprobo el alumno

                        if (asistencia >= Condicion.Presentismo && notaFinal >= Condicion.PromedioRequerido)
                        {
                            aprobo = true;
                        }



                        vista.Alumnos.Add(new ReporteAlumno()
                        {
                            Telefono = item.Telefono,
                            Baja = item.EstadoAsistencia,
                            Asistencia = asistencia,
                            Cuil = item.CUIL,
                            Nombre = item.NombreAlumno,
                            FechaNacimiento = item.FechaNacimiento,
                            NotaFinal = notaFinal,
                            Aprobo = aprobo,
                        });

                    }
                    vista.Varones = totalVarones;
                    vista.Mujeres = totalMujeres;
                    vista.TotalHyM = totalMujeres + totalVarones;
                    
                }
                else
                {
                    AddError("No se encuentra la Institucion, verifique que no fue eliminada.");
                }
               
            }
            else
            {
                AddError("El Curso asignado a la institucion no existe, verifique que no fe eliminado.");
            }
            return vista;
        }

        public IReporteVista GetReportePaticipantes(int idCondicionCurso)
        {
            throw new NotImplementedException();
        }

        public IReporteVista GetReporteAsistencia(int idCondicionCurso)
        {
            throw new NotImplementedException();
        }

        private IInscripcionExamenVista GetExamenes(int idInscripcion, ICondicionCurso condicion)
        {
            IInscripcionExamenVista vista = new InscripcionExamenVista();
            vista.Examenes = ExamenServicio.GetExamenes(idInscripcion);
            vista.PromedioRequerdio = condicion.PromedioRequerido;
            decimal total = 0;
            int totalExamnesRendidos = 0;
            int cantidadExamenesNecesarios = condicion.CantidadExamenes;
            vista.ExamenesRequeridos = condicion.CantidadExamenes;
            foreach (var exa in vista.Examenes)
            {
                totalExamnesRendidos += 1;
                total += exa.Nota;
            }
            try
            {
                vista.PromedioAlumno = decimal.Divide(total, totalExamnesRendidos);
            }
            catch
            {
                vista.PromedioAlumno = 0;
            }
            vista.Aprobo = "Debe cargar todos los examenes para verificar su nota final.";
            if (totalExamnesRendidos == cantidadExamenesNecesarios)
            {
                if (vista.PromedioAlumno >= condicion.PromedioRequerido)
                {
                    vista.Aprobo = "Si Aprobo.";
                }
                else
                {
                    vista.Aprobo = "No Aprobo.";
                }
            }
            return vista;
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }
    }
}
