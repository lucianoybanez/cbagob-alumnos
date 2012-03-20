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
    public class AlumnosServicios : BaseServicio, IAlumnosServicios
    {
        private IAlumnosRepositorio alumnosrepositorio;
        private ITipo_DniRepositorio tipo_dnirepositorio;
        private ITipo_EstadoCivilRepositorio tipo_estadocivilrepositorio;
        private ITipo_SexoRepositorio tipo_sexorepositorio;
        private IHorarioServicio horarioServicio;
        private IGrupoServicio grupoServicio;
        private IAutenticacionServicio Aut;



        public AlumnosServicios(IAlumnosRepositorio alumnosrepositorio, ITipo_DniRepositorio tipoDnirepositorio, ITipo_EstadoCivilRepositorio tipoEstadocivilrepositorio, ITipo_SexoRepositorio tipoSexorepositorio, IHorarioServicio phorarioServicio, IGrupoServicio pgrupoServicio, IAutenticacionServicio aut)
        {
            this.alumnosrepositorio = alumnosrepositorio;
            tipo_dnirepositorio = tipoDnirepositorio;
            tipo_estadocivilrepositorio = tipoEstadocivilrepositorio;
            tipo_sexorepositorio = tipoSexorepositorio;
            horarioServicio = phorarioServicio;
            grupoServicio = pgrupoServicio;
            Aut = aut;
        }

        public IAlumnosVista GetTodos()
        {
            try
            {
                IAlumnosVista vista = new AlumnosVista();

                var pager = new Pager(alumnosrepositorio.GetCountAlumnos(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexAlumnos", Aut.GetUrl("IndexPager", "Alumnos"));

                vista.ListaAlumno = alumnosrepositorio.GetTodos(pager.Skip, pager.PageSize);

                vista.Pager = pager;

                return vista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IAlumnosVista GetTodosByNombreApellido(string nombre, string apellido)
        {
            IAlumnosVista vista = new AlumnosVista();

            vista.ListaAlumno = alumnosrepositorio.GetTodosByNombreApellido(nombre, apellido);

            return vista;

        }

        public IAlumnosVista GetTodosByDni(string dni)
        {
            IAlumnosVista vista = new AlumnosVista();

            vista.ListaAlumno = alumnosrepositorio.GetTodosByDni(dni);

            return vista;
        }

        public IAlumnosVista GetIndex(IPager page)
        {
            try
            {
                IAlumnosVista vista = new AlumnosVista();

                vista.ListaAlumno = alumnosrepositorio.GetTodos(page.Skip, page.PageSize);

                vista.Pager = page;

                return vista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IAlumnosVista GetTodosByCondicionCurso(int id_condicion_curso)
        {
            try
            {
                IAlumnosVista vista = new AlumnosVista();

                vista.ListaAlumno = alumnosrepositorio.GetTodosByCondicionCurso(id_condicion_curso);

                return vista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IAlumnosVista GetTodosAlumnosSinGrupo(int id_condicion_curso)
        {
            try
            {
                IAlumnosVista vista = new AlumnosVista();

                vista.ListaAlumno = alumnosrepositorio.GetTodosAlumnosSinGrupo(id_condicion_curso);

                return vista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IAlumnosVista GetTodosSinGrupo(int id_condicion_curso)
        {
            try
            {
                IAlumnosVista vista = new AlumnosVista();

                vista.ListaAlumno = alumnosrepositorio.GetTodosByCondicionCurso(id_condicion_curso);

                return vista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IAlumnosVista GetTodosAlumnosEnGrupo(int id_grupo, int id_condicion_curso)
        {
            try
            {

                IAlumnosVista vista = new AlumnosVista();

                vista.ListaAlumno = alumnosrepositorio.GetTodosAlumnosEnGrupo(id_grupo, id_condicion_curso);

                return vista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IAlumnosVista GetUno(int id_alumno)
        {
            try
            {
                IAlumnosVista vista = new AlumnosVista();

                IAlumnos alumno = alumnosrepositorio.GetUno(id_alumno);

                vista.Nombre = alumno.Nombre;
                vista.Apellido = alumno.Apellido;
                vista.Cuil = alumno.Cuil;
                vista.Fecha_Nacimiento = alumno.Fecha_Nacimiento;
                vista.Id_Tipo_Dni = alumno.Id_Tipo_Dni;
                vista.Id_Alumno = alumno.Id_Alumno;
                vista.Id_Tipo_Estado_Civil = alumno.Id_Tipo_Estado_Civil;
                vista.Id_Tipo_Sexo = alumno.Id_Tipo_Sexo;
                vista.Nro_Resolucion = alumno.Nro_Resolucion;
                vista.Nro_Documento = alumno.Nro_Documento;
                vista.Provincia = alumno.Provincia;
                vista.Localidad = alumno.Localidad;
                vista.Barrio = alumno.Barrio;
                vista.Calle = alumno.Calle;
                vista.Nro = alumno.Nro;
                vista.Depto = alumno.Depto;

                CargarTipoDni(vista, tipo_dnirepositorio.GetTiposDni());

                CargarTipoEstadoCivil(vista, tipo_estadocivilrepositorio.GetEstadosCivil());

                CargarTipoSexo(vista, tipo_sexorepositorio.GetTiposSexo());

                vista.Sexo.Selected = alumno.Id_Tipo_Sexo.ToString();

                vista.TipoDocumento.Selected = alumno.Id_Tipo_Dni.ToString();

                vista.EstadoCivil.Selected = alumno.Id_Tipo_Estado_Civil.ToString();

                vista.Nro_Telefono = alumno.Nro_Telefono;

                vista.Nro_Celular = alumno.Nro_Celular;

                return vista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IAlumnosVista GetIndex()
        {
            try
            {
                IAlumnosVista vista = new AlumnosVista();

                CargarTipoDni(vista, tipo_dnirepositorio.GetTiposDni());

                CargarTipoEstadoCivil(vista, tipo_estadocivilrepositorio.GetEstadosCivil());

                CargarTipoSexo(vista, tipo_sexorepositorio.GetTiposSexo());

                return vista;
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return null;
            }
        }

        public bool Agregar(IAlumnosVista alumno)
        {
            try
            {
                IAlumnos addalumno = new Alumno();

                addalumno.Apellido = alumno.Apellido;
                addalumno.Nombre = alumno.Nombre;
                addalumno.Cuil = alumno.Cuil;
                addalumno.Fecha_Nacimiento = alumno.Fecha_Nacimiento;
                addalumno.Nro_Documento = alumno.Nro_Documento;
                addalumno.Nro_Resolucion = alumno.Nro_Resolucion;
                addalumno.Id_Tipo_Dni = Convert.ToInt32(alumno.EstadoCivil.Selected);
                addalumno.Id_Tipo_Estado_Civil = Convert.ToInt32(alumno.EstadoCivil.Selected);
                addalumno.Id_Tipo_Sexo = Convert.ToInt32(alumno.Sexo.Selected);
                addalumno.Nro_Telefono = alumno.Nro_Telefono;
                addalumno.Nro_Celular = alumno.Nro_Celular;
                addalumno.Provincia = alumno.Provincia;
                addalumno.Localidad = alumno.Localidad;
                addalumno.Barrio = alumno.Barrio;
                addalumno.Calle = alumno.Calle;
                addalumno.Nro = alumno.Nro;
                addalumno.Depto = alumno.Depto;

                return alumnosrepositorio.Agregar(addalumno);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool Modificar(IAlumnosVista alumno)
        {
            try
            {
                IAlumnos addalumno = new Alumno();

                addalumno.Apellido = alumno.Apellido;
                addalumno.Id_Alumno = alumno.Id_Alumno;
                addalumno.Nombre = alumno.Nombre;
                addalumno.Cuil = alumno.Cuil;
                addalumno.Fecha_Nacimiento = alumno.Fecha_Nacimiento;
                addalumno.Nro_Documento = alumno.Nro_Documento;
                addalumno.Nro_Resolucion = alumno.Nro_Resolucion;
                addalumno.Id_Tipo_Dni = Convert.ToInt32(alumno.EstadoCivil.Selected);
                addalumno.Id_Tipo_Estado_Civil = Convert.ToInt32(alumno.EstadoCivil.Selected);
                addalumno.Id_Tipo_Sexo = Convert.ToInt32(alumno.Sexo.Selected);
                addalumno.Nro_Telefono = alumno.Nro_Telefono;
                addalumno.Nro_Celular = alumno.Nro_Celular;
                addalumno.Provincia = alumno.Provincia;
                addalumno.Localidad = alumno.Localidad;
                addalumno.Barrio = alumno.Barrio;
                addalumno.Calle = alumno.Calle;
                addalumno.Nro = alumno.Nro;
                addalumno.Depto = alumno.Depto;

                return alumnosrepositorio.Modificar(addalumno);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool Eliminar(int id_alumno, string nro_resolucion)
        {
            try
            {
                return alumnosrepositorio.Eliminar(id_alumno, nro_resolucion);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool AsiganraGrupo(int id_grupo, int id_alumno, int id_condicion_curso)
        {
            try
            {
                IList<IHorario> ListaHorarios = horarioServicio.GetHorariosByGrupo(id_grupo).ListaHorario;
                IList<IHorario> ListaHorarioAlumno = horarioServicio.GetHorarioByAlumno(id_alumno, 0).ListaHorario;

                int cantidadalumnos = grupoServicio.CountAlumnosGrupo(id_grupo);
                IGrupoVista grupo = grupoServicio.GetGrupo(id_grupo);

                if (grupo.Capacidad <= cantidadalumnos)
                {
                    base.AddError("Se Excede la Capacidad del Grupo");
                    return false;
                }

                if (ListaHorarios.Count > 0)
                {
                    foreach (var horario in ListaHorarioAlumno)
                    {
                        int count = ListaHorarios.Where(c => c.Id_Horario == horario.Id_Horario).Count();

                        if (count > 0)
                        {
                            base.AddError("El Alumno ya se encuentra asignado en este Horario para otro Modulo :" +
                                          horario.Grupo + ", Curso :" + horario.Curso);
                            return false;
                        }
                    }
                    if (alumnosrepositorio.AsiganraGrupo(id_grupo, id_alumno, id_condicion_curso))
                    {

                        foreach (var horario in ListaHorarios)
                        {
                            horarioServicio.AgregarHorarioalAlumno(id_alumno, horario.Id_Horario, id_grupo);
                        }

                        return true;
                    }

                }
                else
                {
                    base.AddError("Ingrese El Hoario del Grupo para asignar los Alumnos");
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool DesasignaraGrupo(int id_grupo, int id_alumno, int id_condicion_curso)
        {
            try
            {
                IList<IHorario> ListaHorarios = horarioServicio.GetHorariosByGrupo(id_grupo).ListaHorario;

                if (alumnosrepositorio.DesasignaraGrupo(id_grupo, id_alumno, id_condicion_curso))
                {
                    foreach (var horario in ListaHorarios)
                    {
                        horarioServicio.SacarHorarioalAlumno(id_alumno, horario.Id_Horario, id_grupo);
                    }

                    return true;
                }

                return true;
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public IAlumnosVista BuscarAlumnos(string nombre, string apellido, string dni, string cuil)
        {
            try
            {
                IAlumnosVista vista = new AlumnosVista();

                var pager = new Pager(alumnosrepositorio.BuscarAlumnos(nombre, apellido, dni, cuil).Count, Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexAlumnos", Aut.GetUrl("IndexPager", "Alumnos"));

                vista.ListaAlumno = alumnosrepositorio.BuscarAlumnos(nombre, apellido, dni, cuil, pager.Skip, pager.PageSize);

                vista.Pager = pager;

                return vista;
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return null;
            }
        }

        public IAlumnosVista BuscarAlumnos(string nombre, string apellido, string dni, string cuil, IPager pager)
        {
            try
            {
                IAlumnosVista vista = new AlumnosVista();

                vista.ListaAlumno = alumnosrepositorio.BuscarAlumnos(nombre, apellido, dni, cuil, pager.Skip, pager.PageSize);

                vista.Pager = pager;

                return vista;
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return null;
            }
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }

        private void CargarTipoDni(IAlumnosVista vista, IList<ITipo_Dni> lista)
        {
            foreach (var est in lista)
            {
                vista.TipoDocumento.Combo.Add(new ComboItem()
                {
                    id = est.Id_TipoDni,
                    description = est.Nombre_TipoDni
                });
            }
        }

        private void CargarTipoSexo(IAlumnosVista vista, IList<ITipo_Sexo> lista)
        {
            foreach (var est in lista)
            {
                vista.Sexo.Combo.Add(new ComboItem()
                {
                    id = est.Id_TipoSexo,
                    description = est.Nombre_TipoSexo
                });
            }
        }

        private void CargarTipoEstadoCivil(IAlumnosVista vista, IList<ITipo_EstadoCivil> lista)
        {
            foreach (var est in lista)
            {
                vista.EstadoCivil.Combo.Add(new ComboItem()
                {
                    id = est.Id_TipoEstadoCivil,
                    description = est.Nombre_TipoEstadoCivil
                });
            }
        }
    }
}
