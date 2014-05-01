using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiki.Common.Util;

namespace Wiki.Web.Ajax
{
    public class BaseAjax
    {

        public bool LogError(Exception ex)
        {
            return WriteLogManager.WriteLogLogic(ex.ToString());
        }

    }
}