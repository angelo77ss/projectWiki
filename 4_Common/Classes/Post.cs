using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Util;

namespace Wiki.Common.Classes
{
    public class Post
    {
        [MappingSettings(false)]
        public int PostId { get; set; }

        [MappingSettings(false, MappingSettingsAttribute.MappingType.Complex)]
        public Topic Topic { get; set; }

        [MappingSettings(false, MappingSettingsAttribute.MappingType.Complex)]
        public SubTopic SubTopic { get; set; }

        [MappingSettings(false, MappingSettingsAttribute.MappingType.Complex)]
        public DifficultyLevel DifficultyLevel { get; set; }

        [MappingSettings(false, MappingSettingsAttribute.MappingType.Complex)]
        public User User { get; set; }

        [MappingSettings(false)]
        public string Title { get; set; }

        [MappingSettings(false)]
        public string Tags { get; set; }

        [MappingSettings(false)]
        public string ContentPost { get; set; }

        [MappingSettings(false)]
        public string ContentPostResume
        {
            get
            {
                string result = string.Empty;
                if (!string.IsNullOrEmpty(this.ContentPost))
                {
                    //ToDo: Quitar partes de html?
                    result = this.ContentPost;
                    if (result.Length > 200)
                    {
                        result = result.Substring(0, 200);
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
                return result;
            }
        }

        [MappingSettings(false)]
        public bool Active { get; set; }

        [MappingSettings(false)]
        public DateTime CreatedDate { get; set; }

        [MappingSettings(false)]
        public DateTime EditedDate { get; set; }

        [MappingSettings(false)]
        public DateTime DeletedDate { get; set; }

        #region Resultados para operaciones

        [MappingSettings(false)]
        public bool OperationResult { get; set; }

        [MappingSettings(false)]
        public string OperationMessage { get; set; }

        #endregion

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Post()
        {
            this.User = new User();
            this.DifficultyLevel = new DifficultyLevel();
            this.Topic = new Topic();
            this.SubTopic = new SubTopic();
        }

        /// <summary>
        /// Constructor con ID
        /// </summary>
        /// <param name="id">Id del objeto</param>
        public Post(int id)
        {
            this.PostId = id;
            this.User = new User();
            this.DifficultyLevel = new DifficultyLevel();
            this.Topic = new Topic();
            this.SubTopic = new SubTopic();
        }
    }
}
