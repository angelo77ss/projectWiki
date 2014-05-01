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
                    post.Title = this.txtTitle.Value;
                    post.Tags = this.txtTags.Value;
                    post.ContentPost = this.txtContent.Text;
                    post.DifficultyLevel = new DifficultyLevel(Convert.ToInt32(cboLevel.SelectedValue));
                    post.Topic = new Topic(Convert.ToInt32(cboTopic.SelectedValue));
                    //Obtenemos el valor de esta manera ya uqe al cargar por ajax no lo hace de la otra forma. (Combo subTopic)
                    post.SubTopic = new SubTopic(Convert.ToInt32(Page.Request.Params[cboSubTopics.UniqueID]));
                    post.User = this.WebProfile.User;

                    PostLogic postLogic = new PostLogic();
                    if (postLogic.InsertPost(post))
                    {
                        this.operationResult.InnerHtml = this.MessageSuccess("Elemento guardado correctamente.");
                    }
                    else
                    {
                        this.operationResult.InnerHtml = this.MessageDanger("Ocurrio un error guardando el nuevo item.");
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
            return true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
        }

    }
}