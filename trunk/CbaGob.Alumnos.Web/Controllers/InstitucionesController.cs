using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CbaGob.Alumnos.Web.Controllers
{
    public class InstitucionesController : Controller
    {
        //
        // GET: /Instituciones/

        public ActionResult Index()
        {
            return View("Index");
        }

    }
}
