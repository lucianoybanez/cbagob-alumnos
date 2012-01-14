using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbaGob.Alumnos.Servicio.Comun;

namespace JLY.Hotel.Web.Controllers
{
    public class BaseController : Controller
    {
        public void AddError(IList<IErrores> errors)
        {
            foreach (var item in errors)
            {
                ModelState.AddModelError(string.Empty,item.Message);
            }
        }
    }
}