using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wiki.Web.Classes
{
    public class BasePage : System.Web.UI.Page
    {
        public string ApplicationRoot
        {
            get
            {
                string appPath = HttpContext.Current.Request.ApplicationPath;
                if (!appPath.EndsWith("/"))
                {
                    appPath += "/";
                }
                return appPath;
            }
        }

        /// <summary>
        /// Información del usuario logueado mientras esta con la sesion iniciada.
        /// </summary>
        public WebProfile WebProfile
        {
            get
            {
                if (Context.Session["WebProfile"] == null)
                {
                    Context.Session["WebProfile"] = new WebProfile();
                }
                return (WebProfile)Context.Session["WebProfile"];
            }
        }

        public string MessageDanger(string message)
        {
            string result = "<div class='callout callout-danger'><h4>Error</h4><p>" + message + "</p></div>";
            return result;
        }

        public string MessageInfo(string message)
        {
            string result = "<div class='callout callout-info'><h4>Información</h4><p>" + message + "</p></div>";
            return result;
        }

        public string MessageSuccess(string message)
        {
            string result = "<div class='callout callout-success'><h4>Ok!</h4><p>" + message + "</p></div>";
            return result;
        }
    }
}