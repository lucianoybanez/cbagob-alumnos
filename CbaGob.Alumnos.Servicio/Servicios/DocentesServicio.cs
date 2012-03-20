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
    public class DocentesServicio : BaseServicio, IDocentesServicio
    {
        private IDocentesRepositorio docentesrepositorio;
        private ICargosRepositorio cargorepositorio;
        private ITipo_DocentesRepositorio tipodocentesrepositorio;
        private IAutenticacionServicio Aut;
        private IHorarioServicio horarioServicio;


        public DocentesServicio(IDocentesRepositorio docentesrepositorio, ICargosRepositorio cargorepositorio, ITipo_DocentesRepositorio tipodocentesrepositorio, IAutenticacionServicio aut, IHorarioServicio phorarioServicio)
        {
            this.docentesrepositorio = docentesrepositorio;
            this.cargorepositorio = cargorepositorio;
            this.tipodocentesrepositorio = tipodocentesrepositorio;
            Aut = aut;
            horarioServicio = phorarioServicio;
        }

        public IDocentesVista GetTodos()
        {
            try
            {
                IDocentesVista vista = new DocentesVista();

                var pager = new Pager(docentesrepositorio.GetCountDocentes(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexDocentes", Aut.GetUrl("IndexPager", "Docentes"));

                vista.Pager = pager;

                vista.ListaDocentes = docentesrepositorio.GetTodos(pager.Skip, pager.PageSize);

                return vista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IDocentesVista GetIndex()
        {
            try
            {
                IDocentesVista vista = new DocentesVista();

                var pager = new Pager(docentesrepositorio.GetCountDocentes(), Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexDocentes", Aut.GetUrl("IndexPager", "Docentes"));

                vista.Pager = pager;

                vista.ListaDocentes = docentesrepositorio.GetTodos(pager.Skip, pager.PageSize);

                CaragrCargos(vista, cargorepositorio.GetTodosCargos());

                CaragrTipoDocente(vista, tipodocentesrepositorio.GetTiposDocentes());

                return vista;
            }
            catch (Exception)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return null;
            }
        }

        public IDocentesVista GetIndex(IPager page)
        {
            try
            {
                IDocentesVista vista = new DocentesVista();

                vista.Pager = page;

                vista.ListaDocentes = docentesrepositorio.GetTodos(page.Skip, page.PageSize);

                CaragrCargos(vista, cargorepositorio.GetTodosCargos());

                CaragrTipoDocente(vista, tipodocentesrepositorio.GetTiposDocentes());

                return vista;
            }
            catch (Exception)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return null;
            }
        }

        public IDocentesVista GetTodosByRazonSocial(string razonsocial)
        {
            try
            {
                IDocentesVista vista = new DocentesVista();

                vista.ListaDocentes = docentesrepositorio.GetTodosByRazonSocial(razonsocial);

                return vista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IDocentesVista GetUno(int id_docente)
        {
            try
            {
                IDocentesVista vista = new DocentesVista();

                IDocentes docente = docentesrepositorio.GetUno(id_docente);

                vista.Barrio = docente.Barrio;
                vista.Calle = docente.Calle;
                vista.Cuit_Cuil = docente.Cuit_Cuil;
                vista.Provincia = docente.Provincia;
                vista.Localidad = docente.Localidad;
                vista.NombreTipoDocente = docente.NombreTipoDocente;
                vista.Nro = docente.Nro;
                vista.Nro_Resolucion = docente.Nro_Resolucion;
                vista.Reproca = docente.Reproca;
                vista.N_Modalidad = docente.N_Modalidad;
                vista.Id_Cargo = docente.Id_Cargo;
                vista.Id_Docente = docente.Id_Docente;
                vista.id_tipo_docente = docente.id_tipo_docente;
                vista.RazonSoial = docente.RazonSoial;
                vista.Dni = docente.Dni;
                vista.Resolucion_Reproca = docente.Resolucion_Reproca;
                vista.FechaNacimiento = docente.FechaNacimiento;
                vista.Telefono = docente.Telefono;


                CaragrCargos(vista, cargorepositorio.GetTodosCargos());

                CaragrTipoDocente(vista, tipodocentesrepositorio.GetTiposDocentes());

                return vista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Agregar(IDocentesVista docente)
        {
            try
            {
                IDocentes addDocente = new Docentes();

                addDocente.Barrio = docente.Barrio;
                addDocente.Calle = docente.Calle;
                addDocente.Cuit_Cuil = docente.Cuit_Cuil;
                addDocente.RazonSoial = docente.RazonSoial;
                addDocente.Provincia = docente.Provincia;
                addDocente.Localidad = docente.Localidad;
                addDocente.NombreTipoDocente = docente.NombreTipoDocente;
                addDocente.Nro = docente.Nro;
                addDocente.Nro_Resolucion = docente.Nro_Resolucion;
                addDocente.Reproca = docente.Reproca;
                addDocente.N_Modalidad = docente.N_Modalidad;
                addDocente.Id_Cargo = Convert.ToInt32(docente.cargos.Selected);
                addDocente.Id_Docente = docente.Id_Docente;
                addDocente.id_tipo_docente = Convert.ToInt32(docente.TiposDocentes.Selected);
                addDocente.Resolucion_Reproca = docente.Resolucion_Reproca;
                addDocente.Dni = docente.Dni;
                addDocente.FechaNacimiento = docente.FechaNacimiento;
                addDocente.Telefono = docente.Telefono;

                return docentesrepositorio.Agregar(addDocente);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool Modificar(IDocentesVista docente)
        {
            try
            {
                IDocentes addDocente = new Docentes();

                addDocente.Barrio = docente.Barrio;
                addDocente.Calle = docente.Calle;
                addDocente.Cuit_Cuil = docente.Cuit_Cuil;
                addDocente.RazonSoial = docente.RazonSoial;
                addDocente.Provincia = docente.Provincia;
                addDocente.Localidad = docente.Localidad;
                addDocente.NombreTipoDocente = docente.NombreTipoDocente;
                addDocente.Nro = docente.Nro;
                addDocente.Nro_Resolucion = docente.Nro_Resolucion;
                addDocente.Reproca = docente.Reproca;
                addDocente.N_Modalidad = docente.N_Modalidad;
                addDocente.Id_Cargo = Convert.ToInt32(docente.cargos.Selected);
                addDocente.Id_Docente = docente.Id_Docente;
                addDocente.id_tipo_docente = Convert.ToInt32(docente.TiposDocentes.Selected);
                addDocente.Resolucion_Reproca = docente.Resolucion_Reproca;
                addDocente.Dni = docente.Dni;
                addDocente.FechaNacimiento = docente.FechaNacimiento;
                addDocente.Telefono = docente.Telefono;

                return docentesrepositorio.Modificar(addDocente);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public bool Eliminar(int id_docente, string nroresolucion)
        {
            try
            {
                return docentesrepositorio.Eliminar(id_docente, nroresolucion);
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return false;
            }
        }

        public IDocentesVista GetDocentesNotInGrupo(int id_grupo)
        {
            try
            {
                IDocentesVista vista = new DocentesVista();

                vista.ListaDocentes = docentesrepositorio.GetDocentesNotInGrupo(id_grupo);

                return vista;
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return null;
            }
        }

        public IDocentesVista GetDocentesInGrupo(int id_grupo)
        {
            try
            {
                IDocentesVista vista = new DocentesVista();

                vista.ListaDocentes = docentesrepositorio.GetDocentesInGrupo(id_grupo);

                return vista;
            }
            catch (Exception ex)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return null;
            }
        }

        public bool AsignarDocentes(int id_docente, int id_grupo, int id_condicion_curso)
        {
            try
            {
                IList<IHorario> ListaHorarios = horarioServicio.GetHorariosByGrupo(id_grupo).ListaHorario;
                IList<IHorario> ListaHorarioDocentes = horarioServicio.GetHorarioByDocente(id_docente, 0).ListaHorario;


                if (horarioServicio.GetHorariosByGrupo(id_grupo).ListaHorario.Count > 0)
                {

                    foreach (var horario in ListaHorarioDocentes)
                    {
                        int count = ListaHorarios.Where(c => c.Id_Horario == horario.Id_Horario).Count();

                        if (count > 0)
                        {
                            base.AddError("El Docente ya se encuentra asignado en este Horario para otro Modulo :" +
                                          horario.Grupo + ", Curso :" + horario.Curso);
                            return false;
                        }
                    }
                    if (docentesrepositorio.AsignarDocentes(id_docente, id_grupo, id_condicion_curso))
                    {

                        foreach (var horario in ListaHorarios)
                        {
                            horarioServicio.AgregarHorarioalDocente(id_docente, horario.Id_Horario, id_grupo);
                        }

                        return true;
                    }

                }
                else
                {
                    base.AddError("Ingrese El Hoario del Grupo para asignar los Docentes");
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

        public bool DesasignarDocentes(int id_docente, int id_grupo, int id_condicion_curso)
        {
            try
            {
                IList<IHorario> ListaHorarios = horarioServicio.GetHorariosByGrupo(id_grupo).ListaHorario;

                if (docentesrepositorio.DesasignarDocentes(id_docente, id_grupo, id_condicion_curso))
                {
                    foreach (var horario in ListaHorarios)
                    {
                        horarioServicio.SacarHorarioalDocente(id_docente, horario.Id_Horario, id_grupo);
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

        public IDocentesVista BuscarDocente(string razonsocial, string cuit_cuil)
        {
            try
            {
                IDocentesVista vista = new DocentesVista();


                vista.ListaDocentes = docentesrepositorio.BuscarDocente(razonsocial, cuit_cuil);

                var pager = new Pager(vista.ListaDocentes.Count, Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount")), "FormIndexDocentes", Aut.GetUrl("IndexPager", "Docentes"));

                vista.Pager = pager;

                return vista;
            }
            catch (Exception)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return null;
            }
        }

        public IDocentesVista BuscarDocente(IPager page, string razonsocial, string cuit_cuil)
        {
            try
            {
                IDocentesVista vista = new DocentesVista();

                vista.ListaDocentes = docentesrepositorio.BuscarDocente(page.Skip, page.PageSize, razonsocial, cuit_cuil);

                vista.Pager = page;

                return vista;
            }
            catch (Exception)
            {
                base.AddError("Surgio Un Error Vuelva a Intentarlo");
                return null;
            }
        }

        public IList<IErrores> GetErrors()
        {
            return base.Errors;
        }

        private static void CaragrCargos(IDocentesVista vista, IList<ICargos> cargos)
        {
            foreach (var mod in cargos)
            {
                vista.cargos.Combo.Add(new ComboItem()
                {
                    id = mod.Id_Cargo,
                    description = mod.N_Cargo
                });
            }
        }

        private static void CaragrTipoDocente(IDocentesVista vista, IList<ITipo_Docentes> tiposdocentes)
        {
            foreach (var mod in tiposdocentes)
            {
                vista.TiposDocentes.Combo.Add(new ComboItem()
                {
                    id = mod.Id_Tipo_Docente,
                    description = mod.NombreTipoDocente
                });
            }
        }

    }
}
