using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Util;

namespace Wiki.Common.Classes
{
    public class User
    {
        [MappingSettings(false)]
        public int UserId { get; set; }

        [MappingSettings(false)]
        public string UserName { get; set; }

        [MappingSettings(false)]
        public string Password { get; set; }

        [MappingSettings(false)]
        public string Mail { get; set; }

        #region Login result

        [MappingSettings(false)]
        public bool LoginResult { get; set; }

        [MappingSettings(false)]
        public string LoginResultMessage { get; set; }

        #endregion        

    }
}
