using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Modelo.Entities.Interfaces;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class DocentesController : Controller
    {
        //
        // GET: /Docentes/

        private IDocentesServicio docentesservicio;
        private IPersonaJuridicaServicio personajuridicaservicio;
        private IDomiciliosServicios domiciliosservicios;
        private ICargosServicio cargosservicio;

        public DocentesController()
        {
            docentesservicio = new DocentesServicio();
            personajuridicaservicio = new PersonaJuridicaServicio();
            domiciliosservicios = new DomiciliosServicios();
            cargosservicio = new CargosServicio();
        }

        public ActionResult Index()
        {
            IDocentesVista model = new DocentesVista();

            model.ListaDocentes = docentesservicio.GetTodos();

            return View(model);
        }

        public ActionResult Agregar()
        {
            DocentesVista model = new DocentesVista();

            model.ListaPersonaJuridica = personajuridicaservicio.GetTodasByRazonSocial("Test");

            model.ListaDomicilios = domiciliosservicios.GetTodosDomicilios();


            var combo = new List<IComboItem>();

            foreach (var comboItem in cargosservicio.GetTodosCargos())
            {
                combo.Add(new ComboItem() { description = comboItem.N_Cargo, id = comboItem.Id_Cargo });
            }

            model.cargos.Combo = combo;

            return View(model);
        }

        public ActionResult Modificar(Int32 id_docente)
        {
            IDocentes docente = docentesservicio.GetUno(id_docente);

            IDocentesVista model = new DocentesVista();

            model.personajuridica = personajuridicaservicio.GetUno(docente.Id_PersonaJuridica);

            model.domicilios = domiciliosservicios.GetUno(docente.Id_Domicilio);

            model.ListaDomicilios = domiciliosservicios.GetTodosDomicilios();

            model.ListaPersonaJuridica = personajuridicaservicio.GetTodasByRazonSocial("");

            var combo = new List<IComboItem>();

            foreach (var comboItem in cargosservicio.GetTodosCargos())
            {
                combo.Add(new ComboItem() { description = comboItem.N_Cargo, id = comboItem.Id_Cargo });
            }

            model.Id_Domicilio = docente.Id_Domicilio;

            model.Id_PersonaJuridica = docente.Id_PersonaJuridica;

            model.cargos.Combo = combo;

            model.N_Modalidad = docente.N_Modalidad;

            model.cargos.Selected = docente.Id_Cargo.ToString();  

            return View("Modificar", model);
        }

        public ActionResult Eliminar(Int32 id_docente)
        {
            IDocentes docente = docentesservicio.GetUno(id_docente);

            IDocentesVista model = new DocentesVista();

            model.personajuridica = personajuridicaservicio.GetUno(docente.Id_PersonaJuridica);

            model.domicilios = domiciliosservicios.GetUno(docente.Id_Domicilio);

            model.ListaDomicilios = domiciliosservicios.GetTodosDomicilios();

            model.ListaPersonaJuridica = personajuridicaservicio.GetTodasByRazonSocial("");

            var combo = new List<IComboItem>();

            foreach (var comboItem in cargosservicio.GetTodosCargos())
            {
                combo.Add(new ComboItem() { description = comboItem.N_Cargo, id = comboItem.Id_Cargo });
            }

            model.Id_Domicilio = docente.Id_Domicilio;

            model.Id_PersonaJuridica = docente.Id_PersonaJuridica;

            model.cargos.Combo = combo;

            model.N_Modalidad = docente.N_Modalidad;

            model.cargos.Selected = docente.Id_Cargo.ToString();

            return View("Eliminar", model);
        }

        [HttpPost]
        public ActionResult Agregar_Docente(DocentesVista model)
        {
            IDocentes docentes = new Docentes();

            docentes.N_Modalidad = model.N_Modalidad;
            docentes.Id_PersonaJuridica = model.Id_PersonaJuridica;
            docentes.Id_Domicilio = model.Id_Domicilio;
            docentes.Id_Cargo = Convert.ToInt32(model.cargos.Selected);

            bool mret = docentesservicio.Agregar(docentes);

            model.ListaDocentes = docentesservicio.GetTodos();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Modificar_Docente(DocentesVista model)
        {
            IDocentes docentes = new Docentes();

            docentes.N_Modalidad = model.N_Modalidad;
            docentes.Id_PersonaJuridica = model.Id_PersonaJuridica;
            docentes.Id_Domicilio = model.Id_Domicilio;
            docentes.Id_Cargo = Convert.ToInt32(model.cargos.Selected);
            docentes.Id_Docente = model.Id_Docente;

            bool mret = docentesservicio.Modificar(docentes);

            model.ListaDocentes = docentesservicio.GetTodos();

            return View("Index", model);
        }

          [HttpPost]
        public ActionResult Eliminar_Docente(DocentesVista model)
        {

            bool mret = docentesservicio.Eliminar(model.Id_Docente);

            model.ListaDocentes = docentesservicio.GetTodos();

            return View("Index", model);
        }
        
    }
}
