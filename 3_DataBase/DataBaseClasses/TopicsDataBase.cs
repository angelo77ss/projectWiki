using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Classes;
using System.Data;

namespace Wiki.DataBase.DataBaseClasses
{
    public class TopicsDataBase : BaseDataBase
    {

        public List<Topic> GetTopics()
        {
            DataSet ds = WikiDBAdapter.GetDataSet("GetTopics");
            List<Topic> topics = new List<Topic>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable myTable = ds.Tables[0];
                if (myTable != null && myTable.Rows.Count > 0)
                {
                    var dsm = new DataSetMapper<Topic>();
                    topics = dsm.ConvertFromBackend<List<Topic>>(myTable);
                }
            }
            return topics;
        }

        public List<SubTopic> GetSubTopicsByTopicId(Topic topic)
        {
            DataSet ds = WikiDBAdapter.GetDataSet("GetSubTopicsByTopicId",
            new DataAccessParameter("@TopicId", topic.TopicId, typeof(int), null, ParameterDirection.Input));

            List<SubTopic> subTopics = new List<SubTopic>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable myTable = ds.Tables[0];
                if (myTable != null && myTable.Rows.Count > 0)
                {
                    var dsm = new DataSetMapper<SubTopic>();
                    subTopics = dsm.ConvertFromBackend<List<SubTopic>>(myTable);
                }
            }
            return subTopics;
        }

    }
}
