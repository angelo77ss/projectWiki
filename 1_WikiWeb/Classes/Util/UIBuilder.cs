using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Wiki.Logic.LogicClasses;
using Wiki.Common.Classes;
using System.IO;
using System.Configuration;

namespace Wiki.Web.Classes.Util
{
    public class UIBuilder
    {

        public string LeftTopicsMenu()
        {
            StringBuilder sb = new StringBuilder();
            List<Topic> topicList = new TopicsLogic().GetTopics();

            foreach (Topic topicObject in topicList)
            {
                sb.AppendLine(string.Format("<li class='treeview'><a href='#'><i class='fa fa-fire-extinguisher'></i><span>{0}</span><small class='badge pull-right'>{1}</small><i class='fa fa-angle-left pull-right'></i></a>", topicObject.Name, topicObject.SubTopics.Count));
                sb.AppendLine("<ul class='treeview-menu'>");

                foreach (SubTopic subTopicObject in topicObject.SubTopics)
                {
                    sb.AppendLine(string.Format("<li><a href='{0}pagesPost/PostForSubTopic.aspx?subTopicId={1}'><i class='fa fa-angle-double-right'></i>{2}</a></li>", this.ApplicationRoot, subTopicObject.SubTopicId, subTopicObject.Name));
                }

                sb.AppendLine("</ul>");
                sb.AppendLine("</li>");
            }

            return sb.ToString();
        }

        public string GetPostBySubTopicId(List<Post> postList)
        {
            StringBuilder sb = new StringBuilder();
            string htmlTemplate = this.HtmlBase(templateGetPostBySubTopicId);
            if (postList.Count > 0)
            {
                foreach (Post postObject in postList)
                {
                    sb.AppendLine(string.Format(htmlTemplate, postObject.Title, postObject.Title, postObject.Topic.Name, postObject.SubTopic.Name));
                }
            }
            else
            {
                sb.AppendLine("<div class='row'><div class='col-md-12'><h3 class='box-title'>Sin datos</h3></div></div>");
            }

            return sb.ToString();
        }

        public string ApplicationRoot
        {
            get
            {
                string appPath = HttpContext.Current.Request.ApplicationPath;
                if (!appPath.EndsWith("/"))
                {
                    appPath += "/";
                }
                return appPath;
            }
        }

        public string HtmlBase(string templateName)
        {
            string result = string.Empty;
            string templatePath = Path.Combine(ConfigurationManager.AppSettings["ProjectWiki.RootDirectory"], "innerHtmlTemplates/", templateName);

            //ToDo: Validación de existencia de template y lectura.
            result = File.ReadAllText(templatePath);

            return result;
        }

        private string templateGetPostBySubTopicId = "GetPostBySubTopicId.html";

    }
}