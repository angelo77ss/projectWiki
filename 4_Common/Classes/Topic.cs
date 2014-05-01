using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Util;

namespace Wiki.Common.Classes
{
    public class Topic
    {
        [MappingSettings(false)]
        public int TopicId { get; set; }

        [MappingSettings(false)]
        public string Name { get; set; }

        [MappingSettings(false)]
        public List<SubTopic> SubTopics { get; set; }

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Topic()
        {
        }

        /// <summary>
        /// Constructor con ID
        /// </summary>
        /// <param name="id">Id del objeto</param>
        public Topic(int id)
        {
            this.TopicId = id;
        }
    }
}
