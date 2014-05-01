using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wiki.Web.Classes.Util;
using Wiki.Web.Classes;

namespace Wiki.Web
{
    public partial class SiteMaster : BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.leftMenu.InnerHtml = new UIBuilder().LeftTopicsMenu();
        }
    }
}
