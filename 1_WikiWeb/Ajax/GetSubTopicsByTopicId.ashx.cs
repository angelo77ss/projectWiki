using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiki.Common.Classes;
using Wiki.Logic.LogicClasses;
using System.Text;

namespace Wiki.Web.Ajax
{
    /// <summary>
    /// Summary description for GetSubTopicsByTopicId
    /// </summary>
    public class GetSubTopicsByTopicId : BaseAjax, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                int topicId = Convert.ToInt32(context.Request.QueryString["topicId"]);
                List<SubTopic> subTopicList = new TopicsLogic().GetSubTopicsByTopicId(new Topic() { TopicId = topicId });

                if (subTopicList.Count > 0)
                {
                    foreach (SubTopic subTopicObject in subTopicList)
                    {
                        sb.AppendLine(string.Format("<option value='{0}'>{1}</option>", subTopicObject.SubTopicId, subTopicObject.Name));
                    }
                }
                else
                {
                    sb.AppendLine("<option value='-1'>No hay opciones disponibles.</option>");
                }

            }
            catch (Exception ex)
            {
                this.LogError(ex);
                sb.AppendLine("<option value='-1'>Ocurrió un error mientras se cargaban los datos</option>");
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}