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


        public DocentesServicio(IDocentesRepositorio docentesrepositorio, ICargosRepositorio cargorepositorio, ITipo_DocentesRepositorio tipodocentesrepositorio)
        {
            this.docentesrepositorio = docentesrepositorio;
            this.cargorepositorio = cargorepositorio;
            this.tipodocentesrepositorio = tipodocentesrepositorio;
        }

        public IDocentesVista GetTodos()
        {
            try
            {
                IDocentesVista vista = new DocentesVista();

                vista.ListaDocentes = docentesrepositorio.GetTodos();

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

                vista.ListaDocentes = docentesrepositorio.GetTodos();

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
                return docentesrepositorio.AsignarDocentes(id_docente, id_grupo, id_condicion_curso);
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
                return docentesrepositorio.DesasignarDocentes(id_docente, id_grupo, id_condicion_curso);
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
