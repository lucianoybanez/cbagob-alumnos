using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.VistasInterface;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class GruposController : Controller
    {
        private IGrupoServicio gruposervicio;

        public GruposController()
        {
            gruposervicio = new GrupoServicio();
        }

        public ActionResult Index()
        {

            IGruposVista gruposvista = gruposervicio.GetAllGrupo();

            return View(gruposvista);
        }

        public ActionResult Agregar()
        {

            IGrupoVista model = new GrupoVista();

            IDocentesServicio docenteServicio = new DocentesServicio();

            model.ListaDocentes = docenteServicio.GetTodos();


            IEstablecimientoServicio establecimientoservicio = new EstablecimientoServicio();

            IEstablecimientosVista establecimientosvista = establecimientoservicio.GetAllEstableciminetoByInstitucion(26);

            model.ListaEstableimiento = establecimientosvista.ListaEstablecimiento;

            return View(model);
        }

        public ActionResult Modificar(int id_grupo)
        {
            IGrupoVista model = new GrupoVista();

            model = gruposervicio.GetGrupo(id_grupo);

            IDocentesServicio docenteServicio = new DocentesServicio();

            model.ListaDocentes = docenteServicio.GetTodos();

            IEstablecimientoServicio establecimientoservicio = new EstablecimientoServicio();

            IEstablecimientosVista establecimientosvista = establecimientoservicio.GetAllEstableciminetoByInstitucion(26);

            model.ListaEstableimiento = establecimientosvista.ListaEstablecimiento;

            return View(model);
        }

        public ActionResult Eliminar(int id_grupo)
        {
            IGrupoVista model = new GrupoVista();

            model = gruposervicio.GetGrupo(id_grupo);

            IDocentesServicio docenteServicio = new DocentesServicio();

            model.ListaDocentes = docenteServicio.GetTodos();

            IEstablecimientoServicio establecimientoservicio = new EstablecimientoServicio();

            IEstablecimientosVista establecimientosvista = establecimientoservicio.GetAllEstableciminetoByInstitucion(26);

            model.ListaEstableimiento = establecimientosvista.ListaEstablecimiento;

            return View(model);
            return View();
        }

        [HttpPost]
        public ActionResult Agregar_Grupo(GrupoVista model)
        {

            model.Id_Condicion_Curso = 1;
            model.Id_Horario = 1;
            bool mRet = gruposervicio.AgregarGrupo(model);

            IGruposVista gruposvista = gruposervicio.GetAllGrupo();

            return View("Index", gruposvista);
        }

        [HttpPost]
        public ActionResult Eliminar_Grupo(GrupoVista model)
        {

           
            bool mRet = gruposervicio.EliminarGrupo(model.Id_Grupo);

            IGruposVista gruposvista = gruposervicio.GetAllGrupo();

            return View("Index", gruposvista);
        }

        [HttpPost]
        public ActionResult Modificar_Grupo(GrupoVista model)
        {

            model.Id_Condicion_Curso = 1;
            model.Id_Horario = 1;
            bool mRet = gruposervicio.ModificarGrupo(model);

            IGruposVista gruposvista = gruposervicio.GetAllGrupo();

            return View("Index", gruposvista);
        }

    }
}
