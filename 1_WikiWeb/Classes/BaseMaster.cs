using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wiki.Web.Classes
{
    public class BaseMaster : System.Web.UI.MasterPage
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

    }
}