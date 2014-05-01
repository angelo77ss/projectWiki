using System;
using Wiki.DataBase.DataBaseClasses;
using Wiki.Common.Classes;
using System.Collections.Generic;

namespace Wiki.Logic.LogicClasses
{
    public class DifficultyLevelLogic : BaseLogic
    {

        private DifficultyLevelDataBase difficultyLevelDB = new DifficultyLevelDataBase();

        public List<DifficultyLevel> GetDifficultyLevel()
        {
            List<DifficultyLevel> difficultyLevels = new List<DifficultyLevel>();
            try
            {
                difficultyLevels = difficultyLevelDB.GetDifficultyLevel();
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return difficultyLevels;
        }

    }
}
