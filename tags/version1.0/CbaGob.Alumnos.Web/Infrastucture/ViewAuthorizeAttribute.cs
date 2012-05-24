using CbaGob.Alumnos.Infra;
using CbaGob.Alumnos.Modelo.Entities;
using CbaGob.Alumnos.Servicio.Servicios;
using CbaGob.Alumnos.Servicio.ServiciosInterface;
using StructureMap;

namespace System.Web.Mvc
{
    // If this function return false in the web.config is set by default in tag: <authentication mode="Forms">
    // that it should be go to ~/Authentication/Index Action, for this reason I use the session var in this Action
    // for obtain difference beteewn when star application and this function
    // ---For more Information: Read FormsAuthentication---

    public class ViewAuthorizeAttribute : AuthorizeAttribute
    {
        public new RolTipo[] Rol;
        private readonly IUsuarioServicio UsuarioServicio = ObjectFactory.GetInstance<UsuarioServicio>();

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            if (!httpContext.User.Identity.IsAuthenticated)
                return false;

            if (!RolesAcces(httpContext)) return false;

            return true;
        }



        private bool RolesAcces(HttpContextBase httpContext)
        {
            var usuario = UsuarioServicio.GetCookieData();
            bool AccesRol = false;

            if (Rol != null)
            {
                foreach (var item in Rol)
                {
                    if (item.ToString() == usuario.Rol)
                    {
                        AccesRol = true;
                        break;
                    }
                }
                if (AccesRol == false)
                {
                    string m_error = usuario.Rol + " no tiene acceso a esta parte del sistema.";
                    httpContext.Response.Redirect("~/Home/AccesoDenegado?error=" + m_error);
                    return false;
                }
            }
            return true;
        }
    }

    public enum RolTipo
    {
        [StringValue("Supervisor")]
        Supervisor,
        [StringValue("Responsable IFP")]
        ResponsableIFP,
        [StringValue("Capacitador")]
        Capacitador,


    }




}