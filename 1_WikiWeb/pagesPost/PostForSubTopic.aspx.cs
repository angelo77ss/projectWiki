using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wiki.Logic.LogicClasses;
using Wiki.Common.Classes;
using System.Text;
using Wiki.Web.Classes;
using Wiki.Web.Classes.Util;

namespace Wiki.Web.pagesPost
{
    public partial class PostForSubTopic : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //toDo: Chequear que venga el parametro QueryString["subTopicId"]

            int subTopicId = Convert.ToInt32(Request.QueryString["subTopicId"]);
            StringBuilder sb = new StringBuilder();
            List<Post> postList = new PostLogic().GetPostBySubTopicId(new SubTopic() { SubTopicId = subTopicId });

            this.content.InnerHtml = new UIBuilder().GetPostBySubTopicId(postList);
        }
    }
}