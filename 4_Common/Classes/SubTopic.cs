using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Util;

namespace Wiki.Common.Classes
{
    public class SubTopic
    {
        [MappingSettings(false)]
        public int SubTopicId { get; set; }

        [MappingSettings(false)]
        public int TopicId { get; set; }

        [MappingSettings(false)]
        public string Name { get; set; }

          /// <summary>
        /// Constructor vacio
        /// </summary>
        public SubTopic()
        {
        }

        /// <summary>
        /// Constructor con ID
        /// </summary>
        /// <param name="id">Id del objeto</param>
        public SubTopic(int id)
        {
            this.SubTopicId = id;
        }
    }
}
