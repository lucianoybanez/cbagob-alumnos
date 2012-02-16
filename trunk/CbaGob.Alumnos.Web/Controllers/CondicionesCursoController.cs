using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.Vistas;
using CbaGob.Alumnos.Servicio.Vistas.Shared;
using CbaGob.Alumnos.Servicio.VistasInterface.Shared;
using JLY.Hotel.Web.Controllers;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class CondicionesCursoController : BaseController
    {
        //
        // GET: /CondicionesCurso/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar()
        {
            CondicionCursoVista model = new CondicionCursoVista();
            model.NombeInstitucion = " escuela normal";
            var combo = new List<IComboItem>();
            combo.Add(new ComboItem(){description = "telas",id = 1});
            combo.Add(new ComboItem(){description = "Ropa",id = 2});
            model.Curso.Combo = combo;
            model.Curso.Selected = "2";
            return View("Agregar", model);
        }

    }
}
