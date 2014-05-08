using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiki.Common.Util;
using Wiki.Web.Classes.Util;

namespace Wiki.Web.Classes
{
    public class BasePage : System.Web.UI.Page
    {

        public SessionKeys SessionKeys { get { return new SessionKeys(); } }
        public URLParams URLParams { get { return new URLParams(); } }

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

        public bool LogError(Exception ex)
        {
            return WriteLogManager.WriteLogFrontEnd(ex.ToString());
        }

        #region Utilidades HTML

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

        #endregion      

        #region Lectura de parametros desde formularios

        //Obtenemos el valor de esta manera ya que al cargar por ajax no lo hace de la otra forma. (Combo subTopic)

        public string GetParamString(string UniqueId)
        {
            return Page.Request.Params[UniqueId].ToString();
        }

        public int GetParamInt(string UniqueId)
        {
            return Convert.ToInt32(Page.Request.Params[UniqueId].ToString());
        }

        #endregion

        #region Validar parametros

        //ToDo: Agregar

        #endregion
    }
}