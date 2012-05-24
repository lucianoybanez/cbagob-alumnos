using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CbaGob.Alumnos.Servicio.Comun;
using CbaGob.Alumnos.Servicio.ServiciosInterface;

namespace CbaGob.Alumnos.Web.Infrastucture
{
    public class AutenticacionServicio : IAutenticacionServicio
    {
        private readonly IHttpContextService m_httpContextService;

        public AutenticacionServicio(IHttpContextService p_httpContextService)
        {
            m_httpContextService = p_httpContextService;
        }

        public void SignIn(string userName, string Userdata)
        {
            SetPersonalizationCookie(userName, Userdata);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public string GetUserData()
        {
            FormsIdentity m_Identity = m_httpContextService.Context.User.Identity as FormsIdentity;
            string userData = string.Empty;
            if (m_Identity != null)
            {
                FormsAuthenticationTicket m_Ticket = m_Identity.Ticket;
                userData = m_Ticket.UserData;
            }
            return userData;
        }


        private void SetPersonalizationCookie(string userName, string UserData)
        {
            HttpResponseBase m_responseBase = m_httpContextService.Context.Response;
            string m_tmpcookie = UserData;

            // Create the cookie that contains the forms authentication ticket 
            HttpCookie m_Cookie = FormsAuthentication.GetAuthCookie(userName, false);

            // Get the FormsAuthenticationTicket out of the encrypted cookie 
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(m_Cookie.Value);

            // Create a new FormsAuthenticationTicket that includes our custom User Data 

            FormsAuthenticationTicket newTicket =
                new FormsAuthenticationTicket
                    (ticket.Version,
                     ticket.Name,
                     ticket.IssueDate,
                     ticket.Expiration,
                     ticket.IsPersistent,
                     m_tmpcookie);

            // Update the authCookie's Value to use the encrypted version of newTicket 
            m_Cookie.Value = FormsAuthentication.Encrypt(newTicket);

            // Security measure javascript will not see thee cookie (controller by some browsers)
            m_Cookie.HttpOnly = true;

            m_Cookie.Secure = FormsAuthentication.RequireSSL;
            m_Cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                m_Cookie.Domain = FormsAuthentication.CookieDomain;
            }
            // Manually add the authCookie to the Cookies collection
            m_responseBase.Cookies.Add(m_Cookie);
        }

        public string GetUrl(string action,string controller)
        {
            UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var result = url.Action(action, controller);
            return result;
        }

    }
}