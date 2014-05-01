using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Classes;
using System.Data;

namespace Wiki.DataBase.DataBaseClasses
{
    public class DifficultyLevelDataBase : BaseDataBase
    {

        public List<DifficultyLevel> GetDifficultyLevel()
        {
            DataSet ds = WikiDBAdapter.GetDataSet("GetDifficultyLevel");
            List<DifficultyLevel> difficultyLevels = new List<DifficultyLevel>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable myTable = ds.Tables[0];
                if (myTable != null && myTable.Rows.Count > 0)
                {
                    var dsm = new DataSetMapper<DifficultyLevel>();
                    difficultyLevels = dsm.ConvertFromBackend<List<DifficultyLevel>>(myTable);
                }
            }
            return difficultyLevels;
        }

    }
}
