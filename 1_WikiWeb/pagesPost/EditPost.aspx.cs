using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wiki.Web.Classes;
using Wiki.Common.Classes;
using Wiki.Logic.LogicClasses;
using Wiki.Common.Util;

namespace Wiki.Web.pagesPost
{
    public partial class EditPost : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[SessionKeys.PostSaveSuccess] != null)
            {
                this.operationResult.InnerHtml = this.MessageSuccess("Tu post se guardo correctamente.");
                Session[SessionKeys.PostSaveSuccess] = null;
            }
            else if (Session[SessionKeys.PostEditSuccess] != null)
            {
                this.operationResult.InnerHtml = this.MessageSuccess("Tu post se editó correctamente.");
                Session[SessionKeys.PostEditSuccess] = null;
            }

            //Obtencion de parametro y almacenado en hidden para poder usarlo luego.            
            int postId = Convert.ToInt32(this.URLParams.DecodeParam(Page.Request.QueryString["postId"]));
            this.encryptedKey.Value = this.URLParams.EncodeParam(postId.ToString());

            //Seteamos los valores en la pantalla
            Post post = new PostLogic().GetPostById(new Post(postId));
            this.txtTitle.Value = post.Title;
            this.txtContent.Text = post.ContentPost;
            this.txtTags.Value = post.Tags;
            this.cboTopic.SelectedValue = post.Topic.TopicId.ToString();

            List<SubTopic> subTopicList = new TopicsLogic().GetSubTopicsByTopicId(post.Topic);
            foreach (SubTopic subTopicObject in subTopicList)
            {
                ListItem lItem = new ListItem(subTopicObject.Name, subTopicObject.SubTopicId.ToString());
                this.cboSubTopics.Items.Add(lItem);
            }
            this.cboSubTopics.SelectedValue = post.SubTopic.SubTopicId.ToString();

            this.cboLevel.SelectedValue = post.DifficultyLevel.DifficultyLevelId.ToString();
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
                try
                {
                    Post post = new Post();
                    post.PostId = Convert.ToInt32(this.URLParams.DecodeParam(this.encryptedKey.Value));

                    post.Title = this.GetParamString(this.txtTitle.UniqueID);
                    post.Tags = this.GetParamString(this.txtTags.UniqueID);
                    post.ContentPost = this.GetParamString(this.txtContent.UniqueID);
                    post.DifficultyLevel = new DifficultyLevel(this.GetParamInt(this.cboLevel.UniqueID));
                    post.Topic = new Topic(this.GetParamInt(this.cboTopic.UniqueID));
                    post.SubTopic = new SubTopic(this.GetParamInt(this.cboSubTopics.UniqueID));
                    post.User = this.WebProfile.User;

                    PostLogic postLogic = new PostLogic();
                    Post resultPost = postLogic.UpdatePost(post, this.WebProfile.User);
                    if (resultPost.OperationResult)
                    {
                        //Si el post se edito, seteo una variable de sesion para y redirigo a la pagina de edición del post.
                        //Con la variable de sesion, muestro el mensaje de OK en la pantalla de edicion
                        Session[SessionKeys.PostEditSuccess] = true;
                        Response.Redirect("~/pagesPost/EditPost.aspx?postId=" + this.URLParams.EncodeParam(post.PostId.ToString()), false);
                    }
                    else
                    {
                        this.operationResult.InnerHtml = this.MessageDanger(resultPost.OperationMessage);
                    }
                }
                catch (Exception ex)
                {
                    this.LogError(ex);
                    this.operationResult.InnerHtml = this.MessageDanger("Algunos de los datos ingresados no son válidos.");
                }
            }
        }

        private bool ValidateImputs()
        {
            //ToDo: Agregar validarciónes
            return true;
        }

    }
}