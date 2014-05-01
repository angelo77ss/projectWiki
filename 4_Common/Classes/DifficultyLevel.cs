using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Util;

namespace Wiki.Common.Classes
{
    public class DifficultyLevel
    {

        [MappingSettings(false)]
        public int DifficultyLevelId { get; set; }

        [MappingSettings(false)]
        public string Description { get; set; }

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public DifficultyLevel()
        {
        }

        /// <summary>
        /// Constructor con ID
        /// </summary>
        /// <param name="id">Id del objeto</param>
        public DifficultyLevel(int id)
        {
            this.DifficultyLevelId = id;
        }
    }
}
