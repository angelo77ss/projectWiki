using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wiki.Web.Classes;
using Wiki.Logic.LogicClasses;
using Wiki.Common.Classes;

namespace Wiki.Web.pagesPost
{
    public partial class ViewPost : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int postId = Convert.ToInt32(Page.Request.QueryString["postId"]);
            Post post = new PostLogic().GetPostById(new Post(postId));
            this.lblTitle.InnerHtml = post.Title;
            this.lblTopic.InnerHtml = post.Topic.Name;
            this.lblSubTopic.InnerHtml = post.SubTopic.Name;
            this.lblLevel.InnerHtml = post.DifficultyLevel.Description;
            operationResult.InnerHtml = post.ContentPost;
        }
    }
}