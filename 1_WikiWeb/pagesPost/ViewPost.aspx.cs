using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wiki.Web.Classes;
using Wiki.Logic.LogicClasses;
using Wiki.Common.Classes;
using Wiki.Common.Util;

namespace Wiki.Web.pagesPost
{
    public partial class ViewPost : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtencion de parametro y objeto desde base de datos
            int postId = Convert.ToInt32( this.URLParams.DecodeParam(Page.Request.QueryString["postId"]));
            Post post = new PostLogic().GetPostById(new Post(postId));
            this.encryptedKey.Value = this.URLParams.EncodeParam(postId.ToString());

            //Logica si el usuario es propietario.
            if (post.User.UserId.Equals(this.WebProfile.User.UserId))
            {
                this.btnFavorite.Visible = false;
                this.btnDelete.Visible = true;
                this.btnEdit.Visible = true;
                this.btnEdit.HRef = "~/pagesPost/EditPost.aspx?postId=" + this.URLParams.EncodeParam(postId.ToString());
            }
            else
            {
                this.btnFavorite.Visible = true;
                this.btnDelete.Visible = false;
                this.btnEdit.Visible = false;
            }

            //Seteo de valores en la pantalla
            this.lblTitle.InnerHtml = post.Title;
            this.lblTopic.InnerHtml = post.Topic.Name;
            this.lblSubTopic.InnerHtml = post.SubTopic.Name;
            this.lblLevel.InnerHtml = post.DifficultyLevel.Description;
            operationResult.InnerHtml = post.ContentPost;
        }

    }
}