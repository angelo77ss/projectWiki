using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wiki.Web.Classes;
using Wiki.Common.Classes;
using Wiki.Logic.LogicClasses;

namespace Wiki.Web.pagesPost
{
    public partial class AddPost : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<Topic> GetTopics()
        {
            List<Topic> topicList = new TopicsLogic().GetTopics();
            Topic firstItem = new Topic() { Name = "[Seleccione]", TopicId = -1 };
            topicList.Insert(0, firstItem);
            return topicList;
        }

        public List<DifficultyLevel> GetLevels()
        {
            List<DifficultyLevel> difficultyLevels = new DifficultyLevelLogic().GetDifficultyLevel();
            return difficultyLevels;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (ValidateImputs())
                {
                    Post post = new Post();
                    post.Title = this.GetParamString(this.txtTitle.UniqueID);
                    post.Tags = this.GetParamString(this.txtTags.UniqueID);
                    post.ContentPost = this.GetParamString(this.txtContent.UniqueID);
                    post.DifficultyLevel = new DifficultyLevel(this.GetParamInt(this.cboLevel.UniqueID));
                    post.Topic = new Topic(this.GetParamInt(this.cboTopic.UniqueID));
                    post.SubTopic = new SubTopic(this.GetParamInt(this.cboSubTopics.UniqueID));
                    post.User = this.WebProfile.User;
                    
                    PostLogic postLogic = new PostLogic();
                    post = postLogic.InsertPost(post); 
                    if (post.OperationResult)                    
                    {
                        //Si el post se guardo, seteo una variable de sesion para y redirigo a la pagina de edición del post.
                        //Con la variable de sesion, muestro el mensaje de OK en la pantalla de edicion
                        Session[SessionKeys.PostSaveSuccess] = true;
                        Response.Redirect("~/pagesPost/EditPost.aspx?postId=" + post.PostId, false);                        
                    }
                    else
                    {
                        this.operationResult.InnerHtml = this.MessageDanger(post.OperationMessage);
                    }
                }
                else
                {
                    this.operationResult.InnerHtml = this.MessageDanger("Algunos de los datos ingresados no son válidos.");
                }
            }
        }

        private bool ValidateImputs()
        {
            //ToDo: Agregar validaciones
            return true;
        }

    }
}