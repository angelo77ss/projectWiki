using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Util;

namespace Wiki.Logic
{
    public class BaseLogic
    {

        public bool LogError(Exception ex)
        {
            return WriteLogManager.WriteLogLogic(ex.ToString());
        }

    }
}
