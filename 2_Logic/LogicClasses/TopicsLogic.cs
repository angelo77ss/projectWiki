using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.DataBase.DataBaseClasses;
using Wiki.Common.Classes;
using Wiki.Common.Util;

namespace Wiki.Logic.LogicClasses
{
    public class TopicsLogic : BaseLogic
    {
        private TopicsDataBase topicDB = new TopicsDataBase();

        public List<Topic> GetTopics()
        {
            List<Topic> topics = new List<Topic>();
            try
            {
                topics = topicDB.GetTopics();
                foreach (Topic topicObject in topics)
                {
                    topicObject.SubTopics = topicDB.GetSubTopicsByTopicId(topicObject);
                }
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return topics;
        }

        public List<SubTopic> GetSubTopicsByTopicId(Topic topicObject)
        {
            List<SubTopic> subTopics = new List<SubTopic>();
            try
            {
                subTopics = topicDB.GetSubTopicsByTopicId(topicObject);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return subTopics;
        }
    }
}
